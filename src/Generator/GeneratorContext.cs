// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using System.IO;

namespace Generator;

[Flags]
enum GeneratorFlags {
	None				= 0,
	NoVEX				= 0x0000_0040,
	NoEVEX				= 0x0000_0080,
	NoXOP				= 0x0000_0100,
	No3DNow				= 0x0000_0200,
	NoMVEX				= 0x0000_0400,
}

sealed class GeneratorOptions {
	public bool IncludeVEX { get; }
	public bool IncludeEVEX { get; }
	public bool IncludeXOP { get; }
	public bool Include3DNow { get; }
	public bool IncludeMVEX { get; }
	public HashSet<string> IncludeCpuid { get; }
	public HashSet<string> ExcludeCpuid { get; }

	public GeneratorOptions(GeneratorFlags flags, HashSet<string> includeCpuid, HashSet<string> excludeCpuid) {
		IncludeVEX = (flags & GeneratorFlags.NoVEX) == 0;
		IncludeEVEX = (flags & GeneratorFlags.NoEVEX) == 0;
		IncludeXOP = (flags & GeneratorFlags.NoXOP) == 0;
		Include3DNow = (flags & GeneratorFlags.No3DNow) == 0;
		IncludeMVEX = (flags & GeneratorFlags.NoMVEX) == 0;
		IncludeCpuid = includeCpuid;
		ExcludeCpuid = excludeCpuid;
	}
}

sealed class GeneratorDirs {
	public string UnitTestsDir { get; }
	public string CSharpDir => langDirs[(int)TargetLanguage.CSharp];
	public string CSharpTestsDir { get; }
	public string GeneratorDir { get; }
	readonly string[] langDirs;

	public GeneratorDirs(string baseDir) {
		UnitTestsDir = GetAndVerifyPath(baseDir, "UnitTests");
		GeneratorDir = GetAndVerifyPath(baseDir, "src", "Generator");
		langDirs = new string[Enum.GetValues<TargetLanguage>().Length];
		for (int i = 0; i < langDirs.Length; i++) {
			string path = (TargetLanguage)i switch {
				TargetLanguage.Other => string.Empty,
				TargetLanguage.CSharp => GetAndVerifyPath(baseDir, "src", "Blazed"),
				_ => throw new InvalidOperationException(),
			};
			langDirs[i] = path;
		}
		CSharpTestsDir = GetAndVerifyPath(baseDir, "src", "UnitTests");
	}

	static string GetAndVerifyPath(params string[] paths) {
		var path = Path.Combine(paths);
		if (!Directory.Exists(path))
			throw new InvalidOperationException($"Directory {path} doesn't exist");
		return path;
	}

	public string GetUnitTestFilename(params string[] names) => Path.Combine(UnitTestsDir, Path.Combine(names));
	public string GetCSharpTestFilename(params string[] names) => Path.Combine(CSharpTestsDir, Path.Combine(names));
	public string GetGeneratorFilename(params string[] names) => Path.Combine(GeneratorDir, Path.Combine(names));
}

sealed class GeneratorContext {
	public GenTypes Types { get; }

	public GeneratorContext(string baseDir, GeneratorFlags flags, HashSet<string> includeCpuid, HashSet<string> excludeCpuid) =>
		Types = new GenTypes(new GeneratorOptions(flags, includeCpuid, excludeCpuid), new GeneratorDirs(baseDir));
}
