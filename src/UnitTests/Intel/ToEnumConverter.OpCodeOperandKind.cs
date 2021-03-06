// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if ENCODER && OPCODE_INFO
using System;
using System.Collections.Generic;
using Blazed.Intel;

namespace UnitTests.Intel;

static partial class ToEnumConverter {
	public static bool TryOpCodeOperandKind(string value, out OpCodeOperandKind opCodeOperandKind) => opCodeOperandKindDict.TryGetValue(value, out opCodeOperandKind);

	static readonly Dictionary<string, OpCodeOperandKind> opCodeOperandKindDict =
		// GENERATOR-BEGIN: OpCodeOperandKindHash
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		new Dictionary<string, OpCodeOperandKind>(109, StringComparer.Ordinal) {
			{ "None", OpCodeOperandKind.None },
			{ "farbr2_2", OpCodeOperandKind.farbr2_2 },
			{ "farbr4_2", OpCodeOperandKind.farbr4_2 },
			{ "mem_offs", OpCodeOperandKind.mem_offs },
			{ "mem", OpCodeOperandKind.mem },
			{ "mem_mpx", OpCodeOperandKind.mem_mpx },
			{ "mem_mib", OpCodeOperandKind.mem_mib },
			{ "mem_vsib32x", OpCodeOperandKind.mem_vsib32x },
			{ "mem_vsib64x", OpCodeOperandKind.mem_vsib64x },
			{ "mem_vsib32y", OpCodeOperandKind.mem_vsib32y },
			{ "mem_vsib64y", OpCodeOperandKind.mem_vsib64y },
			{ "mem_vsib32z", OpCodeOperandKind.mem_vsib32z },
			{ "mem_vsib64z", OpCodeOperandKind.mem_vsib64z },
			{ "r8_or_mem", OpCodeOperandKind.r8_or_mem },
			{ "r16_or_mem", OpCodeOperandKind.r16_or_mem },
			{ "r32_or_mem", OpCodeOperandKind.r32_or_mem },
			{ "r32_or_mem_mpx", OpCodeOperandKind.r32_or_mem_mpx },
			{ "r64_or_mem", OpCodeOperandKind.r64_or_mem },
			{ "r64_or_mem_mpx", OpCodeOperandKind.r64_or_mem_mpx },
			{ "mm_or_mem", OpCodeOperandKind.mm_or_mem },
			{ "xmm_or_mem", OpCodeOperandKind.xmm_or_mem },
			{ "ymm_or_mem", OpCodeOperandKind.ymm_or_mem },
			{ "zmm_or_mem", OpCodeOperandKind.zmm_or_mem },
			{ "bnd_or_mem_mpx", OpCodeOperandKind.bnd_or_mem_mpx },
			{ "k_or_mem", OpCodeOperandKind.k_or_mem },
			{ "r8_reg", OpCodeOperandKind.r8_reg },
			{ "r8_opcode", OpCodeOperandKind.r8_opcode },
			{ "r16_reg", OpCodeOperandKind.r16_reg },
			{ "r16_reg_mem", OpCodeOperandKind.r16_reg_mem },
			{ "r16_rm", OpCodeOperandKind.r16_rm },
			{ "r16_opcode", OpCodeOperandKind.r16_opcode },
			{ "r32_reg", OpCodeOperandKind.r32_reg },
			{ "r32_reg_mem", OpCodeOperandKind.r32_reg_mem },
			{ "r32_rm", OpCodeOperandKind.r32_rm },
			{ "r32_opcode", OpCodeOperandKind.r32_opcode },
			{ "r32_vvvv", OpCodeOperandKind.r32_vvvv },
			{ "r64_reg", OpCodeOperandKind.r64_reg },
			{ "r64_reg_mem", OpCodeOperandKind.r64_reg_mem },
			{ "r64_rm", OpCodeOperandKind.r64_rm },
			{ "r64_opcode", OpCodeOperandKind.r64_opcode },
			{ "r64_vvvv", OpCodeOperandKind.r64_vvvv },
			{ "seg_reg", OpCodeOperandKind.seg_reg },
			{ "k_reg", OpCodeOperandKind.k_reg },
			{ "kp1_reg", OpCodeOperandKind.kp1_reg },
			{ "k_rm", OpCodeOperandKind.k_rm },
			{ "k_vvvv", OpCodeOperandKind.k_vvvv },
			{ "mm_reg", OpCodeOperandKind.mm_reg },
			{ "mm_rm", OpCodeOperandKind.mm_rm },
			{ "xmm_reg", OpCodeOperandKind.xmm_reg },
			{ "xmm_rm", OpCodeOperandKind.xmm_rm },
			{ "xmm_vvvv", OpCodeOperandKind.xmm_vvvv },
			{ "xmmp3_vvvv", OpCodeOperandKind.xmmp3_vvvv },
			{ "xmm_is4", OpCodeOperandKind.xmm_is4 },
			{ "xmm_is5", OpCodeOperandKind.xmm_is5 },
			{ "ymm_reg", OpCodeOperandKind.ymm_reg },
			{ "ymm_rm", OpCodeOperandKind.ymm_rm },
			{ "ymm_vvvv", OpCodeOperandKind.ymm_vvvv },
			{ "ymm_is4", OpCodeOperandKind.ymm_is4 },
			{ "ymm_is5", OpCodeOperandKind.ymm_is5 },
			{ "zmm_reg", OpCodeOperandKind.zmm_reg },
			{ "zmm_rm", OpCodeOperandKind.zmm_rm },
			{ "zmm_vvvv", OpCodeOperandKind.zmm_vvvv },
			{ "zmmp3_vvvv", OpCodeOperandKind.zmmp3_vvvv },
			{ "cr_reg", OpCodeOperandKind.cr_reg },
			{ "dr_reg", OpCodeOperandKind.dr_reg },
			{ "tr_reg", OpCodeOperandKind.tr_reg },
			{ "bnd_reg", OpCodeOperandKind.bnd_reg },
			{ "es", OpCodeOperandKind.es },
			{ "cs", OpCodeOperandKind.cs },
			{ "ss", OpCodeOperandKind.ss },
			{ "ds", OpCodeOperandKind.ds },
			{ "fs", OpCodeOperandKind.fs },
			{ "gs", OpCodeOperandKind.gs },
			{ "al", OpCodeOperandKind.al },
			{ "cl", OpCodeOperandKind.cl },
			{ "ax", OpCodeOperandKind.ax },
			{ "dx", OpCodeOperandKind.dx },
			{ "eax", OpCodeOperandKind.eax },
			{ "rax", OpCodeOperandKind.rax },
			{ "st0", OpCodeOperandKind.st0 },
			{ "sti_opcode", OpCodeOperandKind.sti_opcode },
			{ "imm4_m2z", OpCodeOperandKind.imm4_m2z },
			{ "imm8", OpCodeOperandKind.imm8 },
			{ "imm8_const_1", OpCodeOperandKind.imm8_const_1 },
			{ "imm8sex16", OpCodeOperandKind.imm8sex16 },
			{ "imm8sex32", OpCodeOperandKind.imm8sex32 },
			{ "imm8sex64", OpCodeOperandKind.imm8sex64 },
			{ "imm16", OpCodeOperandKind.imm16 },
			{ "imm32", OpCodeOperandKind.imm32 },
			{ "imm32sex64", OpCodeOperandKind.imm32sex64 },
			{ "imm64", OpCodeOperandKind.imm64 },
			{ "seg_rSI", OpCodeOperandKind.seg_rSI },
			{ "es_rDI", OpCodeOperandKind.es_rDI },
			{ "seg_rDI", OpCodeOperandKind.seg_rDI },
			{ "seg_rBX_al", OpCodeOperandKind.seg_rBX_al },
			{ "br16_1", OpCodeOperandKind.br16_1 },
			{ "br32_1", OpCodeOperandKind.br32_1 },
			{ "br64_1", OpCodeOperandKind.br64_1 },
			{ "br16_2", OpCodeOperandKind.br16_2 },
			{ "br32_4", OpCodeOperandKind.br32_4 },
			{ "br64_4", OpCodeOperandKind.br64_4 },
			{ "xbegin_2", OpCodeOperandKind.xbegin_2 },
			{ "xbegin_4", OpCodeOperandKind.xbegin_4 },
			{ "brdisp_2", OpCodeOperandKind.brdisp_2 },
			{ "brdisp_4", OpCodeOperandKind.brdisp_4 },
			{ "sibmem", OpCodeOperandKind.sibmem },
			{ "tmm_reg", OpCodeOperandKind.tmm_reg },
			{ "tmm_rm", OpCodeOperandKind.tmm_rm },
			{ "tmm_vvvv", OpCodeOperandKind.tmm_vvvv },
		};
		// GENERATOR-END: OpCodeOperandKindHash
}
#endif
