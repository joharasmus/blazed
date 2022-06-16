// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if INSTR_INFO
using System;
using System.Collections.Generic;
using Blazed.Intel;

namespace UnitTests.Intel;

static partial class ToEnumConverter {
	public static bool TryCpuidFeature(string value, out CpuidFeature cpuidFeature) => cpuidFeatureDict.TryGetValue(value, out cpuidFeature);
	public static CpuidFeature GetCpuidFeature(string value) => TryCpuidFeature(value, out var cpuidFeature) ? cpuidFeature : throw new InvalidOperationException($"Invalid CpuidFeature value: {value}");

	static readonly Dictionary<string, CpuidFeature> cpuidFeatureDict =
		// GENERATOR-BEGIN: CpuidFeatureHash
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		new Dictionary<string, CpuidFeature>(146, StringComparer.Ordinal) {
			{ "INTEL8086", CpuidFeature.INTEL8086 },
			{ "INTEL8086_ONLY", CpuidFeature.INTEL8086_ONLY },
			{ "INTEL186", CpuidFeature.INTEL186 },
			{ "INTEL286", CpuidFeature.INTEL286 },
			{ "INTEL286_ONLY", CpuidFeature.INTEL286_ONLY },
			{ "INTEL386", CpuidFeature.INTEL386 },
			{ "INTEL386_ONLY", CpuidFeature.INTEL386_ONLY },
			{ "INTEL386_A0_ONLY", CpuidFeature.INTEL386_A0_ONLY },
			{ "INTEL486", CpuidFeature.INTEL486 },
			{ "INTEL486_A_ONLY", CpuidFeature.INTEL486_A_ONLY },
			{ "UMOV", CpuidFeature.UMOV },
			{ "IA64", CpuidFeature.IA64 },
			{ "X64", CpuidFeature.X64 },
			{ "ADX", CpuidFeature.ADX },
			{ "AES", CpuidFeature.AES },
			{ "AVX", CpuidFeature.AVX },
			{ "AVX2", CpuidFeature.AVX2 },
			{ "AVX512_4FMAPS", CpuidFeature.AVX512_4FMAPS },
			{ "AVX512_4VNNIW", CpuidFeature.AVX512_4VNNIW },
			{ "AVX512_BF16", CpuidFeature.AVX512_BF16 },
			{ "AVX512_BITALG", CpuidFeature.AVX512_BITALG },
			{ "AVX512_IFMA", CpuidFeature.AVX512_IFMA },
			{ "AVX512_VBMI", CpuidFeature.AVX512_VBMI },
			{ "AVX512_VBMI2", CpuidFeature.AVX512_VBMI2 },
			{ "AVX512_VNNI", CpuidFeature.AVX512_VNNI },
			{ "AVX512_VP2INTERSECT", CpuidFeature.AVX512_VP2INTERSECT },
			{ "AVX512_VPOPCNTDQ", CpuidFeature.AVX512_VPOPCNTDQ },
			{ "AVX512BW", CpuidFeature.AVX512BW },
			{ "AVX512CD", CpuidFeature.AVX512CD },
			{ "AVX512DQ", CpuidFeature.AVX512DQ },
			{ "AVX512ER", CpuidFeature.AVX512ER },
			{ "AVX512F", CpuidFeature.AVX512F },
			{ "AVX512PF", CpuidFeature.AVX512PF },
			{ "AVX512VL", CpuidFeature.AVX512VL },
			{ "BMI1", CpuidFeature.BMI1 },
			{ "BMI2", CpuidFeature.BMI2 },
			{ "CET_IBT", CpuidFeature.CET_IBT },
			{ "CET_SS", CpuidFeature.CET_SS },
			{ "CL1INVMB", CpuidFeature.CL1INVMB },
			{ "CLDEMOTE", CpuidFeature.CLDEMOTE },
			{ "CLFLUSHOPT", CpuidFeature.CLFLUSHOPT },
			{ "CLFSH", CpuidFeature.CLFSH },
			{ "CLWB", CpuidFeature.CLWB },
			{ "CLZERO", CpuidFeature.CLZERO },
			{ "CMOV", CpuidFeature.CMOV },
			{ "CMPXCHG16B", CpuidFeature.CMPXCHG16B },
			{ "CPUID", CpuidFeature.CPUID },
			{ "CX8", CpuidFeature.CX8 },
			{ "D3NOW", CpuidFeature.D3NOW },
			{ "D3NOWEXT", CpuidFeature.D3NOWEXT },
			{ "OSS", CpuidFeature.OSS },
			{ "ENQCMD", CpuidFeature.ENQCMD },
			{ "F16C", CpuidFeature.F16C },
			{ "FMA", CpuidFeature.FMA },
			{ "FMA4", CpuidFeature.FMA4 },
			{ "FPU", CpuidFeature.FPU },
			{ "FPU287", CpuidFeature.FPU287 },
			{ "FPU287XL_ONLY", CpuidFeature.FPU287XL_ONLY },
			{ "FPU387", CpuidFeature.FPU387 },
			{ "FPU387SL_ONLY", CpuidFeature.FPU387SL_ONLY },
			{ "FSGSBASE", CpuidFeature.FSGSBASE },
			{ "FXSR", CpuidFeature.FXSR },
			{ "GFNI", CpuidFeature.GFNI },
			{ "HLE", CpuidFeature.HLE },
			{ "HLE_or_RTM", CpuidFeature.HLE_or_RTM },
			{ "INVEPT", CpuidFeature.INVEPT },
			{ "INVPCID", CpuidFeature.INVPCID },
			{ "INVVPID", CpuidFeature.INVVPID },
			{ "LWP", CpuidFeature.LWP },
			{ "LZCNT", CpuidFeature.LZCNT },
			{ "MCOMMIT", CpuidFeature.MCOMMIT },
			{ "MMX", CpuidFeature.MMX },
			{ "MONITOR", CpuidFeature.MONITOR },
			{ "MONITORX", CpuidFeature.MONITORX },
			{ "MOVBE", CpuidFeature.MOVBE },
			{ "MOVDIR64B", CpuidFeature.MOVDIR64B },
			{ "MOVDIRI", CpuidFeature.MOVDIRI },
			{ "MPX", CpuidFeature.MPX },
			{ "MSR", CpuidFeature.MSR },
			{ "MULTIBYTENOP", CpuidFeature.MULTIBYTENOP },
			{ "PAUSE", CpuidFeature.PAUSE },
			{ "PCLMULQDQ", CpuidFeature.PCLMULQDQ },
			{ "PCOMMIT", CpuidFeature.PCOMMIT },
			{ "PCONFIG", CpuidFeature.PCONFIG },
			{ "PKU", CpuidFeature.PKU },
			{ "POPCNT", CpuidFeature.POPCNT },
			{ "PREFETCHW", CpuidFeature.PREFETCHW },
			{ "PREFETCHWT1", CpuidFeature.PREFETCHWT1 },
			{ "PTWRITE", CpuidFeature.PTWRITE },
			{ "RDPID", CpuidFeature.RDPID },
			{ "RDPMC", CpuidFeature.RDPMC },
			{ "RDPRU", CpuidFeature.RDPRU },
			{ "RDRAND", CpuidFeature.RDRAND },
			{ "RDSEED", CpuidFeature.RDSEED },
			{ "RDTSCP", CpuidFeature.RDTSCP },
			{ "RTM", CpuidFeature.RTM },
			{ "SEP", CpuidFeature.SEP },
			{ "SGX1", CpuidFeature.SGX1 },
			{ "SHA", CpuidFeature.SHA },
			{ "SKINIT", CpuidFeature.SKINIT },
			{ "SKINIT_or_SVM", CpuidFeature.SKINIT_or_SVM },
			{ "SMAP", CpuidFeature.SMAP },
			{ "SMX", CpuidFeature.SMX },
			{ "SSE", CpuidFeature.SSE },
			{ "SSE2", CpuidFeature.SSE2 },
			{ "SSE3", CpuidFeature.SSE3 },
			{ "SSE4_1", CpuidFeature.SSE4_1 },
			{ "SSE4_2", CpuidFeature.SSE4_2 },
			{ "SSE4A", CpuidFeature.SSE4A },
			{ "SSSE3", CpuidFeature.SSSE3 },
			{ "SVM", CpuidFeature.SVM },
			{ "SEV_ES", CpuidFeature.SEV_ES },
			{ "SYSCALL", CpuidFeature.SYSCALL },
			{ "TBM", CpuidFeature.TBM },
			{ "TSC", CpuidFeature.TSC },
			{ "VAES", CpuidFeature.VAES },
			{ "VMX", CpuidFeature.VMX },
			{ "VPCLMULQDQ", CpuidFeature.VPCLMULQDQ },
			{ "WAITPKG", CpuidFeature.WAITPKG },
			{ "WBNOINVD", CpuidFeature.WBNOINVD },
			{ "XOP", CpuidFeature.XOP },
			{ "XSAVE", CpuidFeature.XSAVE },
			{ "XSAVEC", CpuidFeature.XSAVEC },
			{ "XSAVEOPT", CpuidFeature.XSAVEOPT },
			{ "XSAVES", CpuidFeature.XSAVES },
			{ "SEV_SNP", CpuidFeature.SEV_SNP },
			{ "SERIALIZE", CpuidFeature.SERIALIZE },
			{ "TSXLDTRK", CpuidFeature.TSXLDTRK },
			{ "INVLPGB", CpuidFeature.INVLPGB },
			{ "AMX_BF16", CpuidFeature.AMX_BF16 },
			{ "AMX_TILE", CpuidFeature.AMX_TILE },
			{ "AMX_INT8", CpuidFeature.AMX_INT8 },
			{ "CENTAUR_AIS", CpuidFeature.CENTAUR_AIS },
			{ "MOV_TR", CpuidFeature.MOV_TR },
			{ "SMM", CpuidFeature.SMM },
			{ "TDX", CpuidFeature.TDX },
			{ "KL", CpuidFeature.KL },
			{ "AESKLE", CpuidFeature.AESKLE },
			{ "WIDE_KL", CpuidFeature.WIDE_KL },
			{ "UINTR", CpuidFeature.UINTR },
			{ "HRESET", CpuidFeature.HRESET },
			{ "AVX_VNNI", CpuidFeature.AVX_VNNI },
			{ "FRED", CpuidFeature.FRED },
			{ "LKGS", CpuidFeature.LKGS },
			{ "AVX512_FP16", CpuidFeature.AVX512_FP16 },
			{ "UDBG", CpuidFeature.UDBG },
		};
		// GENERATOR-END: CpuidFeatureHash
}
#endif
