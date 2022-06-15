// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

// ⚠️This file was generated by GENERATOR!🦹‍♂️

#nullable enable

#if INSTR_INFO
namespace Blazed.Intel.InstructionInfoInternal {
	static partial class CpuidFeatureInternalData {
		static System.ReadOnlySpan<byte> GetGetCpuidFeaturesData() =>
			new byte[] {
				// Header
				0x00,
				0x00,
				0x01,
				0x80,
				0xFD,
				0x3F,
				0x00,
				0x00,
				0x10,
				0xE0,
				0x00,
				0x00,
				0x10,
				0x00,
				0x00,
				0x10,
				0x80,
				0x6D,
				0x00,
				0x00,
				0x00,
				0x01,
				0x01,

				0x00,// INTEL8086
				0x01,// INTEL8086_ONLY
				0x02,// INTEL186
				0x03,// INTEL286
				0x04,// INTEL286_ONLY
				0x05,// INTEL386
				0x06,// INTEL386_ONLY
				0x07,// INTEL386_A0_ONLY
				0x08,// INTEL486
				0x09,// INTEL486_A_ONLY
				0x0A,// UMOV
				0x0B,// IA64
				0x0C,// X64
				0x0D,// ADX
				0x0E,// AES
				0x0F,// AVX
				0x0E, 0x0F,// AES_and_AVX
				0x10,// AVX2
				0x11,// AVX512_4FMAPS
				0x12,// AVX512_4VNNIW
				0x14,// AVX512_BITALG
				0x15,// AVX512_IFMA
				0x16,// AVX512_VBMI
				0x17,// AVX512_VBMI2
				0x18,// AVX512_VNNI
				0x1A,// AVX512_VPOPCNTDQ
				0x1B,// AVX512BW
				0x1C,// AVX512CD
				0x1D,// AVX512DQ
				0x1E,// AVX512ER
				0x1F,// AVX512F
				0x1F, 0x13,// AVX512F_and_AVX512_BF16
				0x1F, 0x19,// AVX512F_and_AVX512_VP2INTERSECT
				0x20,// AVX512PF
				0x21, 0x13,// AVX512VL_and_AVX512_BF16
				0x21, 0x14,// AVX512VL_and_AVX512_BITALG
				0x21, 0x15,// AVX512VL_and_AVX512_IFMA
				0x21, 0x16,// AVX512VL_and_AVX512_VBMI
				0x21, 0x17,// AVX512VL_and_AVX512_VBMI2
				0x21, 0x18,// AVX512VL_and_AVX512_VNNI
				0x21, 0x19,// AVX512VL_and_AVX512_VP2INTERSECT
				0x21, 0x1A,// AVX512VL_and_AVX512_VPOPCNTDQ
				0x21, 0x1B,// AVX512VL_and_AVX512BW
				0x21, 0x1C,// AVX512VL_and_AVX512CD
				0x21, 0x1D,// AVX512VL_and_AVX512DQ
				0x21, 0x1F,// AVX512VL_and_AVX512F
				0x22,// BMI1
				0x23,// BMI2
				0x24,// CET_IBT
				0x25,// CET_SS
				0x26,// CL1INVMB
				0x27,// CLDEMOTE
				0x28,// CLFLUSHOPT
				0x29,// CLFSH
				0x2A,// CLWB
				0x2B,// CLZERO
				0x2C,// CMOV
				0x2D,// CMPXCHG16B
				0x2E,// CPUID
				0x2F,// CX8
				0x30,// D3NOW
				0x31,// D3NOWEXT
				0x32,// OSS
				0x33,// ENQCMD
				0x34,// F16C
				0x35,// FMA
				0x36,// FMA4
				0x37,// FPU
				0x37, 0x2C,// FPU_and_CMOV
				0x38,// FPU287
				0x39,// FPU287XL_ONLY
				0x3A,// FPU387
				0x3B,// FPU387SL_ONLY
				0x3C,// FSGSBASE
				0x3D,// FXSR
				0x3E,// CYRIX_D3NOW
				0x3F,// GFNI
				0x0F, 0x3F,// AVX_and_GFNI
				0x1F, 0x3F,// AVX512F_and_GFNI
				0x21, 0x3F,// AVX512VL_and_GFNI
				0x41,// HLE_or_RTM
				0x43,// INVPCID
				0x45,// LWP
				0x46,// LZCNT
				0x47,// MCOMMIT
				0x48,// MMX
				0x49,// MONITOR
				0x4A,// MONITORX
				0x4B,// MOVBE
				0x4C,// MOVDIR64B
				0x4D,// MOVDIRI
				0x4E,// MPX
				0x4F,// MSR
				0x50,// MULTIBYTENOP
				0x51,// PADLOCK_ACE
				0x52,// PADLOCK_PHE
				0x53,// PADLOCK_PMM
				0x54,// PADLOCK_RNG
				0x55,// PAUSE
				0x56,// PCLMULQDQ
				0x56, 0x0F,// PCLMULQDQ_and_AVX
				0x57,// PCOMMIT
				0x58,// PCONFIG
				0x59,// PKU
				0x5A,// POPCNT
				0x5B,// PREFETCHW
				0x5C,// PREFETCHWT1
				0x5D,// PTWRITE
				0x5E,// RDPID
				0x5F,// RDPMC
				0x60,// RDPRU
				0x61,// RDRAND
				0x62,// RDSEED
				0x63,// RDTSCP
				0x64,// RTM
				0x65,// SEP
				0x66,// SGX1
				0x67,// SHA
				0x69,// SKINIT_or_SVM
				0x6A,// SMAP
				0x6B,// SMX
				0x6C,// SSE
				0x6D,// SSE2
				0x6E,// SSE3
				0x37, 0x6E,// FPU_and_SSE3
				0x6F,// SSE4_1
				0x70,// SSE4_2
				0x71,// SSE4A
				0x72,// SSSE3
				0x73,// SVM
				0x74,// SEV_ES
				0x75,// SYSCALL
				0x76,// TBM
				0x77,// TSC
				0x78,// VAES
				0x1F, 0x78,// AVX512F_and_VAES
				0x21, 0x78,// AVX512VL_and_VAES
				0x79,// VMX
				0x79, 0x42,// VMX_and_INVEPT
				0x79, 0x44,// VMX_and_INVVPID
				0x7A,// VPCLMULQDQ
				0x1F, 0x7A,// AVX512F_and_VPCLMULQDQ
				0x21, 0x7A,// AVX512VL_and_VPCLMULQDQ
				0x7B,// WAITPKG
				0x7C,// WBNOINVD
				0x7D,// XOP
				0x7E,// XSAVE
				0x7F,// XSAVEC
				0x80,// XSAVEOPT
				0x81,// XSAVES
				0x82,// SEV_SNP
				0x83,// SERIALIZE
				0x84,// TSXLDTRK
				0x85,// INVLPGB
				0x86,// AMX_BF16
				0x87,// AMX_TILE
				0x88,// AMX_INT8
				0x89,// CYRIX_FPU
				0x8A,// CYRIX_SMM
				0x8B,// CYRIX_SMINT
				0x8C,// CYRIX_SMINT_0F7E
				0x8D,// CYRIX_SHR
				0x8E,// CENTAUR_AIS
				0x8F,// MOV_TR
				0x90,// SMM
				0x91,// TDX
				0x92,// KL
				0x93,// AESKLE
				0x93, 0x94,// AESKLE_and_WIDE_KL
				0x95,// UINTR
				0x96,// HRESET
				0x97,// AVX_VNNI
				0x98,// PADLOCK_GMI
				0x99,// FRED
				0x9A,// LKGS
				0x9B,// AVX512_FP16
				0x21, 0x9B,// AVX512VL_and_AVX512_FP16
				0x9C,// UDBG
				0x9D,// KNC
				0x9E,// PADLOCK_UNDOC
			};
	}
}
#endif
