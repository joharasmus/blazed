// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Generator.Enums.InstructionInfo;

namespace Generator; 
sealed class GeneratorInfoComparer : IComparer<GeneratorInfo> {
	public int Compare([AllowNull] GeneratorInfo x, [AllowNull] GeneratorInfo y) {
		int c = GetOrder(x!.Language).CompareTo(GetOrder(y!.Language));
		if (c != 0) return c;
		return StringComparer.Ordinal.Compare(x.TypeName, y.TypeName);
	}

	static int GetOrder(TargetLanguage language) => (int)language;
}

sealed class GeneratorInfo {
	const string InvokeMethodName = "Generate";
	readonly ConstructorInfo ctor;
	readonly MethodInfo method;

	public TargetLanguage Language { get; }
	public string TypeName { get; }

	public GeneratorInfo(TargetLanguage language, Type type) {
		Language = language;
		TypeName = type.FullName ?? throw new InvalidOperationException();

		var ctor = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Standard, new[] { typeof(GeneratorContext) }, null);
		if (ctor is null)
			throw new InvalidOperationException($"Generator {type.FullName} doesn't have a constructor that takes a {nameof(GeneratorContext)} argument");
		this.ctor = ctor;
		var method = type.GetMethod(InvokeMethodName, 0, BindingFlags.Public | BindingFlags.Instance, null, CallingConventions.Standard, Array.Empty<Type>(), null);
		if (method is null || method.ReturnType != typeof(void))
			throw new InvalidOperationException($"Generator {type.FullName} doesn't have a public void {InvokeMethodName}() method");
		this.method = method;
	}

	public void Invoke(GeneratorContext generatorContext) {

		var instance = ctor.Invoke(new[] { generatorContext }) ?? throw new InvalidOperationException();
		var flag = BindingFlags.Default;
		method.Invoke(instance, flag, null, null, null);
		return;
	}
}

sealed class CommandLineOptions {
	public GeneratorFlags GeneratorFlags = GeneratorFlags.None;
	public readonly HashSet<string> IncludeCpuid = new(StringComparer.OrdinalIgnoreCase);
	public readonly HashSet<string> ExcludeCpuid = new(StringComparer.OrdinalIgnoreCase);
}

static class Program {
	static int Main(string[] args) {
		try {
			if (!TryParseCommandLine(args, out var options, out var error)) {
				Help();
				if (error != string.Empty) {
					Console.WriteLine();
					Console.WriteLine(error);
				}
				return 1;
			}

			var generatorContext = CreateGeneratorContext(options.GeneratorFlags, options.IncludeCpuid, options.ExcludeCpuid);

			CodeComments.AddComments(generatorContext.Types);

			var generatorInfos = GetGenerators();
			foreach(var genInfo in generatorInfos) {
				genInfo.Invoke(generatorContext);
				Console.WriteLine($"{genInfo.TypeName} has executed successfully.");
			}

			return 0;
		}
		catch (Exception ex) {
			Console.WriteLine(ex.ToString());
			Debug.Fail("Exception:\n\n" + ex.ToString());
			return 1;
		}
	}

	static void Help() => Console.WriteLine(@"
Generates code and data

Options:

-h, --help
    Show this message
--no-vex
    Don't include VEX instructions
--no-evex
    Don't include EVEX instructions
--no-xop
    Don't include XOP instructions
--no-3dnow
    Don't include 3DNow! instructions
--include-cpuid <name>
    Include instructions with these CPUID features, remove everything else
    eg. --include-cpuid intel8086;intel186;intel286;intel386;intel486;x64;wbnoinvd
--exclude-cpuid <name>
    Don't include instructions with CPUID feature <name>, ;-separated. See CpuidFeature enum
");

	static bool TryParseCommandLine(string[] args, [NotNullWhen(true)] out CommandLineOptions? options, [NotNullWhen(false)] out string? error) {
		if (Enum.GetValues<TargetLanguage>().Length != 2)
			throw new InvalidOperationException("Enum updated, update help message and this method");
		options = new CommandLineOptions();

		for (int i = 0; i < args.Length; i++) {
			var arg = args[i];
			var value = i + 1 < args.Length ? args[i + 1] : null;

			switch (arg) {
			case "-h":
			case "--help":
				error = string.Empty;
				return false;

			case "--no-vex":
				options.GeneratorFlags |= GeneratorFlags.NoVEX;
				break;

			case "--no-evex":
				options.GeneratorFlags |= GeneratorFlags.NoEVEX;
				break;

			case "--no-xop":
				options.GeneratorFlags |= GeneratorFlags.NoXOP;
				break;

			case "--no-3dnow":
				options.GeneratorFlags |= GeneratorFlags.No3DNow;
				// Remove FEMMS too
				options.ExcludeCpuid.Add(nameof(CpuidFeature.D3NOW));
				break;

			case "--include-cpuid":
				if (value is null) {
					error = "Missing cpuid feature name";
					return false;
				}
				i++;
				foreach (var v in value.Split(seps, StringSplitOptions.RemoveEmptyEntries))
					options.IncludeCpuid.Add(v);
				break;

			case "--exclude-cpuid":
				if (value is null) {
					error = "Missing cpuid feature name";
					return false;
				}
				i++;
				foreach (var v in value.Split(seps, StringSplitOptions.RemoveEmptyEntries))
					options.ExcludeCpuid.Add(v);
				break;

			default:
				error = $"Unknown option: {value}";
				return false;
			}
		}
		error = null;
		return true;
	}
	static readonly char[] seps = new char[] { ',', ';' };

	static GeneratorContext CreateGeneratorContext(GeneratorFlags flags, HashSet<string> includeCpuid, HashSet<string> excludeCpuid) {
		var dir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(typeof(Program).Assembly.Location))))));
		if (dir is null || !File.Exists(Path.Combine(dir, "src", "Blazed.sln")))
			throw new InvalidOperationException();
		return new GeneratorContext(dir, flags, includeCpuid, excludeCpuid);
	}

	static List<GeneratorInfo> GetGenerators() {
		var result = new List<GeneratorInfo>();
		foreach (var type in typeof(Program).Assembly.GetTypes()) {
			var attr = (GeneratorAttribute?)type.GetCustomAttribute(typeof(GeneratorAttribute));
			if (attr is null)
				continue;
			result.Add(new GeneratorInfo(attr.Language, type));
		}
		result.Sort(new GeneratorInfoComparer());
		return result;
	}
}
