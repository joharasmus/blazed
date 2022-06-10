// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

// ⚠️This file was generated by GENERATOR!🦹‍♂️

#nullable enable

#if ENCODER && OPCODE_INFO
namespace Iced.Intel {
	/// <summary>Operand kind</summary>
	public enum OpCodeOperandKind {
		/// <summary>No operand</summary>
		None = 0,
		/// <summary>Far branch 16-bit offset, 16-bit segment/selector</summary>
		farbr2_2 = 1,
		/// <summary>Far branch 32-bit offset, 16-bit segment/selector</summary>
		farbr4_2 = 2,
		/// <summary>Memory offset without a modrm byte (eg. <c>MOV AL,[offset]</c>)</summary>
		mem_offs = 3,
		/// <summary>Memory (modrm)</summary>
		mem = 4,
		/// <summary>Memory (modrm), MPX:<br/>
		/// <br/>
		/// 16/32-bit mode: must be 32-bit addressing<br/>
		/// <br/>
		/// 64-bit mode: 64-bit addressing is forced and must not be RIP relative</summary>
		mem_mpx = 5,
		/// <summary>Memory (modrm), MPX:<br/>
		/// <br/>
		/// 16/32-bit mode: must be 32-bit addressing<br/>
		/// <br/>
		/// 64-bit mode: 64-bit addressing is forced and must not be RIP relative</summary>
		mem_mib = 6,
		/// <summary>Memory (modrm), vsib32, <c>XMM</c> registers</summary>
		mem_vsib32x = 7,
		/// <summary>Memory (modrm), vsib64, <c>XMM</c> registers</summary>
		mem_vsib64x = 8,
		/// <summary>Memory (modrm), vsib32, <c>YMM</c> registers</summary>
		mem_vsib32y = 9,
		/// <summary>Memory (modrm), vsib64, <c>YMM</c> registers</summary>
		mem_vsib64y = 10,
		/// <summary>Memory (modrm), vsib32, <c>ZMM</c> registers</summary>
		mem_vsib32z = 11,
		/// <summary>Memory (modrm), vsib64, <c>ZMM</c> registers</summary>
		mem_vsib64z = 12,
		/// <summary>8-bit GPR or memory</summary>
		r8_or_mem = 13,
		/// <summary>16-bit GPR or memory</summary>
		r16_or_mem = 14,
		/// <summary>32-bit GPR or memory</summary>
		r32_or_mem = 15,
		/// <summary>32-bit GPR or memory, MPX: 16/32-bit mode: must be 32-bit addressing, 64-bit mode: 64-bit addressing is forced</summary>
		r32_or_mem_mpx = 16,
		/// <summary>64-bit GPR or memory</summary>
		r64_or_mem = 17,
		/// <summary>64-bit GPR or memory, MPX: 16/32-bit mode: must be 32-bit addressing, 64-bit mode: 64-bit addressing is forced</summary>
		r64_or_mem_mpx = 18,
		/// <summary><c>MM</c> register or memory</summary>
		mm_or_mem = 19,
		/// <summary><c>XMM</c> register or memory</summary>
		xmm_or_mem = 20,
		/// <summary><c>YMM</c> register or memory</summary>
		ymm_or_mem = 21,
		/// <summary><c>ZMM</c> register or memory</summary>
		zmm_or_mem = 22,
		/// <summary><c>BND</c> register or memory, MPX: 16/32-bit mode: must be 32-bit addressing, 64-bit mode: 64-bit addressing is forced</summary>
		bnd_or_mem_mpx = 23,
		/// <summary><c>K</c> register or memory</summary>
		k_or_mem = 24,
		/// <summary>8-bit GPR encoded in the <c>reg</c> field of the modrm byte</summary>
		r8_reg = 25,
		/// <summary>8-bit GPR encoded in the low 3 bits of the opcode</summary>
		r8_opcode = 26,
		/// <summary>16-bit GPR encoded in the <c>reg</c> field of the modrm byte</summary>
		r16_reg = 27,
		/// <summary>16-bit GPR encoded in the <c>reg</c> field of the modrm byte. This is a memory operand and it uses the address size prefix (<c>67h</c>) not the operand size prefix (<c>66h</c>).</summary>
		r16_reg_mem = 28,
		/// <summary>16-bit GPR encoded in the <c>mod + r/m</c> fields of the modrm byte</summary>
		r16_rm = 29,
		/// <summary>16-bit GPR encoded in the low 3 bits of the opcode</summary>
		r16_opcode = 30,
		/// <summary>32-bit GPR encoded in the <c>reg</c> field of the modrm byte</summary>
		r32_reg = 31,
		/// <summary>32-bit GPR encoded in the <c>reg</c> field of the modrm byte. This is a memory operand and it uses the address size prefix (<c>67h</c>) not the operand size prefix (<c>66h</c>).</summary>
		r32_reg_mem = 32,
		/// <summary>32-bit GPR encoded in the <c>mod + r/m</c> fields of the modrm byte</summary>
		r32_rm = 33,
		/// <summary>32-bit GPR encoded in the low 3 bits of the opcode</summary>
		r32_opcode = 34,
		/// <summary>32-bit GPR encoded in the the <c>V&apos;vvvv</c> field (VEX/EVEX/XOP)</summary>
		r32_vvvv = 35,
		/// <summary>64-bit GPR encoded in the <c>reg</c> field of the modrm byte</summary>
		r64_reg = 36,
		/// <summary>64-bit GPR encoded in the <c>reg</c> field of the modrm byte. This is a memory operand and it uses the address size prefix (<c>67h</c>) not the operand size prefix (<c>66h</c>).</summary>
		r64_reg_mem = 37,
		/// <summary>64-bit GPR encoded in the <c>mod + r/m</c> fields of the modrm byte</summary>
		r64_rm = 38,
		/// <summary>64-bit GPR encoded in the low 3 bits of the opcode</summary>
		r64_opcode = 39,
		/// <summary>64-bit GPR encoded in the the <c>V&apos;vvvv</c> field (VEX/EVEX/XOP)</summary>
		r64_vvvv = 40,
		/// <summary>Segment register encoded in the <c>reg</c> field of the modrm byte</summary>
		seg_reg = 41,
		/// <summary><c>K</c> register encoded in the <c>reg</c> field of the modrm byte</summary>
		k_reg = 42,
		/// <summary><c>K</c> register (+1) encoded in the <c>reg</c> field of the modrm byte</summary>
		kp1_reg = 43,
		/// <summary><c>K</c> register encoded in the <c>mod + r/m</c> fields of the modrm byte</summary>
		k_rm = 44,
		/// <summary><c>K</c> register encoded in the the <c>V&apos;vvvv</c> field (VEX/EVEX/MVEX/XOP)</summary>
		k_vvvv = 45,
		/// <summary><c>MM</c> register encoded in the <c>reg</c> field of the modrm byte</summary>
		mm_reg = 46,
		/// <summary><c>MM</c> register encoded in the <c>mod + r/m</c> fields of the modrm byte</summary>
		mm_rm = 47,
		/// <summary><c>XMM</c> register encoded in the <c>reg</c> field of the modrm byte</summary>
		xmm_reg = 48,
		/// <summary><c>XMM</c> register encoded in the <c>mod + r/m</c> fields of the modrm byte</summary>
		xmm_rm = 49,
		/// <summary><c>XMM</c> register encoded in the the <c>V&apos;vvvv</c> field (VEX/EVEX/XOP)</summary>
		xmm_vvvv = 50,
		/// <summary><c>XMM</c> register (+3) encoded in the the <c>V&apos;vvvv</c> field (VEX/EVEX/XOP)</summary>
		xmmp3_vvvv = 51,
		/// <summary><c>XMM</c> register encoded in the the high 4 bits of the last 8-bit immediate (VEX/XOP only so only <c>XMM0</c>-<c>XMM15</c>)</summary>
		xmm_is4 = 52,
		/// <summary><c>XMM</c> register encoded in the the high 4 bits of the last 8-bit immediate (VEX/XOP only so only <c>XMM0</c>-<c>XMM15</c>)</summary>
		xmm_is5 = 53,
		/// <summary><c>YMM</c> register encoded in the <c>reg</c> field of the modrm byte</summary>
		ymm_reg = 54,
		/// <summary><c>YMM</c> register encoded in the <c>mod + r/m</c> fields of the modrm byte</summary>
		ymm_rm = 55,
		/// <summary><c>YMM</c> register encoded in the the <c>V&apos;vvvv</c> field (VEX/EVEX/XOP)</summary>
		ymm_vvvv = 56,
		/// <summary><c>YMM</c> register encoded in the the high 4 bits of the last 8-bit immediate (VEX/XOP only so only <c>YMM0</c>-<c>YMM15</c>)</summary>
		ymm_is4 = 57,
		/// <summary><c>YMM</c> register encoded in the the high 4 bits of the last 8-bit immediate (VEX/XOP only so only <c>YMM0</c>-<c>YMM15</c>)</summary>
		ymm_is5 = 58,
		/// <summary><c>ZMM</c> register encoded in the <c>reg</c> field of the modrm byte</summary>
		zmm_reg = 59,
		/// <summary><c>ZMM</c> register encoded in the <c>mod + r/m</c> fields of the modrm byte</summary>
		zmm_rm = 60,
		/// <summary><c>ZMM</c> register encoded in the the <c>V&apos;vvvv</c> field (VEX/EVEX/MVEX/XOP)</summary>
		zmm_vvvv = 61,
		/// <summary><c>ZMM</c> register (+3) encoded in the the <c>V&apos;vvvv</c> field (VEX/EVEX/XOP)</summary>
		zmmp3_vvvv = 62,
		/// <summary><c>CR</c> register encoded in the <c>reg</c> field of the modrm byte</summary>
		cr_reg = 63,
		/// <summary><c>DR</c> register encoded in the <c>reg</c> field of the modrm byte</summary>
		dr_reg = 64,
		/// <summary><c>TR</c> register encoded in the <c>reg</c> field of the modrm byte</summary>
		tr_reg = 65,
		/// <summary><c>BND</c> register encoded in the <c>reg</c> field of the modrm byte</summary>
		bnd_reg = 66,
		/// <summary><c>ES</c> register</summary>
		es = 67,
		/// <summary><c>CS</c> register</summary>
		cs = 68,
		/// <summary><c>SS</c> register</summary>
		ss = 69,
		/// <summary><c>DS</c> register</summary>
		ds = 70,
		/// <summary><c>FS</c> register</summary>
		fs = 71,
		/// <summary><c>GS</c> register</summary>
		gs = 72,
		/// <summary><c>AL</c> register</summary>
		al = 73,
		/// <summary><c>CL</c> register</summary>
		cl = 74,
		/// <summary><c>AX</c> register</summary>
		ax = 75,
		/// <summary><c>DX</c> register</summary>
		dx = 76,
		/// <summary><c>EAX</c> register</summary>
		eax = 77,
		/// <summary><c>RAX</c> register</summary>
		rax = 78,
		/// <summary><c>ST(0)</c> register</summary>
		st0 = 79,
		/// <summary><c>ST(i)</c> register encoded in the low 3 bits of the opcode</summary>
		sti_opcode = 80,
		/// <summary>4-bit immediate (m2z field, low 4 bits of the /is5 immediate, eg. <c>VPERMIL2PS</c>)</summary>
		imm4_m2z = 81,
		/// <summary>8-bit immediate</summary>
		imm8 = 82,
		/// <summary>Constant 1 (8-bit immediate)</summary>
		imm8_const_1 = 83,
		/// <summary>8-bit immediate sign extended to 16 bits</summary>
		imm8sex16 = 84,
		/// <summary>8-bit immediate sign extended to 32 bits</summary>
		imm8sex32 = 85,
		/// <summary>8-bit immediate sign extended to 64 bits</summary>
		imm8sex64 = 86,
		/// <summary>16-bit immediate</summary>
		imm16 = 87,
		/// <summary>32-bit immediate</summary>
		imm32 = 88,
		/// <summary>32-bit immediate sign extended to 64 bits</summary>
		imm32sex64 = 89,
		/// <summary>64-bit immediate</summary>
		imm64 = 90,
		/// <summary><c>seg:[rSI]</c> memory operand (string instructions)</summary>
		seg_rSI = 91,
		/// <summary><c>es:[rDI]</c> memory operand (string instructions)</summary>
		es_rDI = 92,
		/// <summary><c>seg:[rDI]</c> memory operand (<c>(V)MASKMOVQ</c> instructions)</summary>
		seg_rDI = 93,
		/// <summary><c>seg:[rBX+al]</c> memory operand (<c>XLATB</c> instruction)</summary>
		seg_rBX_al = 94,
		/// <summary>16-bit branch, 1-byte signed relative offset</summary>
		br16_1 = 95,
		/// <summary>32-bit branch, 1-byte signed relative offset</summary>
		br32_1 = 96,
		/// <summary>64-bit branch, 1-byte signed relative offset</summary>
		br64_1 = 97,
		/// <summary>16-bit branch, 2-byte signed relative offset</summary>
		br16_2 = 98,
		/// <summary>32-bit branch, 4-byte signed relative offset</summary>
		br32_4 = 99,
		/// <summary>64-bit branch, 4-byte signed relative offset</summary>
		br64_4 = 100,
		/// <summary><c>XBEGIN</c>, 2-byte signed relative offset</summary>
		xbegin_2 = 101,
		/// <summary><c>XBEGIN</c>, 4-byte signed relative offset</summary>
		xbegin_4 = 102,
		/// <summary>2-byte branch offset (<c>JMPE</c> instruction)</summary>
		brdisp_2 = 103,
		/// <summary>4-byte branch offset (<c>JMPE</c> instruction)</summary>
		brdisp_4 = 104,
		/// <summary>Memory (modrm) and the sib byte must be present</summary>
		sibmem = 105,
		/// <summary><c>TMM</c> register encoded in the <c>reg</c> field of the modrm byte</summary>
		tmm_reg = 106,
		/// <summary><c>TMM</c> register encoded in the <c>mod + r/m</c> fields of the modrm byte</summary>
		tmm_rm = 107,
		/// <summary><c>TMM</c> register encoded in the the <c>V&apos;vvvv</c> field (VEX/EVEX/XOP)</summary>
		tmm_vvvv = 108,
	}
}
#endif