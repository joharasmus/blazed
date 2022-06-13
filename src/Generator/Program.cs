// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
		method.Invoke(instance, null);
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

			// It's not much of an improvement in speed at the moment.
			// Group by lang since different lang gens don't write to the same files.
			Parallel.ForEach(Filter(GetGenerators()).GroupBy(a => a.Language).Select(a => a.ToArray()), genInfos => {
				foreach (var genInfo in genInfos)
					genInfo.Invoke(generatorContext);
			});

			return 0;
		}
		catch (Exception ex) {
			Console.WriteLine(ex.ToString());
			Debug.Fail("Exception:\n\n" + ex.ToString());
			return 1;
		}
	}

	static IEnumerable<GeneratorInfo> Filter(List<GeneratorInfo> genInfos) {
		foreach (var genInfo in genInfos) {
			yield return genInfo;
		}
	}

	static void Help() => Console.WriteLine(@"
Generates code and data

Options:

-h, --help
    Show this message
--no-formatter
    Don't include any formatter
--no-intel
    Don't include the Intel (XED) formatter
--no-masm
    Don't include the masm formatter
--no-nasm
    Don't include the nasm formatter
--no-fast-fmt
    Don't include the fast formatter
--no-vex
    Don't include VEX instructions
--no-evex
    Don't include EVEX instructions
--no-xop
    Don't include XOP instructions
--no-3dnow
    Don't include 3DNow! instructions
--no-mvex
    Don't include MVEX instructions
--no-knc
    Don't include KNC instructions (MVEX + KNC VEX)
--no-padlock
    Don't include Centaur (VIA) PadLock instructions
--no-cyrix
    Don't include Cyrix / AMD Geode GX/LX instructions
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

			case "--no-formatter":
				options.GeneratorFlags |= GeneratorFlags.NoFormatter;
				break;

			case "--no-intel":
				options.GeneratorFlags |= GeneratorFlags.NoIntelFormatter;
				break;

			case "--no-masm":
				options.GeneratorFlags |= GeneratorFlags.NoMasmFormatter;
				break;

			case "--no-nasm":
				options.GeneratorFlags |= GeneratorFlags.NoNasmFormatter;
				break;

			case "--no-fast-fmt":
				options.GeneratorFlags |= GeneratorFlags.NoFastFormatter;
				break;

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

			case "--no-mvex":
				options.GeneratorFlags |= GeneratorFlags.NoMVEX;
				break;

			case "--no-knc":
				options.GeneratorFlags |= GeneratorFlags.NoMVEX;
				options.ExcludeCpuid.Add(nameof(CpuidFeature.KNC));
				break;

			case "--no-padlock":
				options.ExcludeCpuid.Add(nameof(CpuidFeature.PADLOCK_ACE));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.PADLOCK_PHE));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.PADLOCK_PMM));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.PADLOCK_RNG));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.PADLOCK_GMI));
				break;

			case "--no-cyrix":
				// Don't include CYRIX_D3NOW. They must be removed by --no-3dnow because the 3DNow! opcode handler has refs to all 3DNow! Code values
				options.ExcludeCpuid.Add(nameof(CpuidFeature.CYRIX_FPU));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.CYRIX_SMM));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.CYRIX_SMINT));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.CYRIX_SMINT_0F7E));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.CYRIX_SHR));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.CYRIX_DDI));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.CYRIX_EMMI));
				options.ExcludeCpuid.Add(nameof(CpuidFeature.CYRIX_DMI));
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
