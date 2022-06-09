// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

// ⚠️This file was generated by GENERATOR!🦹‍♂️

#nullable enable

#if INSTR_INFO
namespace Iced.Intel {
	/// <summary>Control flow</summary>
	public enum FlowControl {
		/// <summary>The next instruction that will be executed is the next instruction in the instruction stream</summary>
		Next = 0,
		/// <summary>It&apos;s an unconditional branch instruction: <c>JMP NEAR</c>, <c>JMP FAR</c></summary>
		UnconditionalBranch = 1,
		/// <summary>It&apos;s an unconditional indirect branch: <c>JMP NEAR reg</c>, <c>JMP NEAR [mem]</c>, <c>JMP FAR [mem]</c></summary>
		IndirectBranch = 2,
		/// <summary>It&apos;s a conditional branch instruction: <c>Jcc SHORT</c>, <c>Jcc NEAR</c>, <c>LOOP</c>, <c>LOOPcc</c>, <c>JRCXZ</c>, <c>JKccD SHORT</c>, <c>JKccD NEAR</c></summary>
		ConditionalBranch = 3,
		/// <summary>It&apos;s a return instruction: <c>RET NEAR</c>, <c>RET FAR</c>, <c>IRET</c>, <c>SYSRET</c>, <c>SYSEXIT</c>, <c>RSM</c>, <c>SKINIT</c>, <c>RDM</c>, <c>UIRET</c></summary>
		Return = 4,
		/// <summary>It&apos;s a call instruction: <c>CALL NEAR</c>, <c>CALL FAR</c>, <c>SYSCALL</c>, <c>SYSENTER</c>, <c>VMLAUNCH</c>, <c>VMRESUME</c>, <c>VMCALL</c>, <c>VMMCALL</c>, <c>VMGEXIT</c>, <c>VMRUN</c>, <c>TDCALL</c>, <c>SEAMCALL</c>, <c>SEAMRET</c></summary>
		Call = 5,
		/// <summary>It&apos;s an indirect call instruction: <c>CALL NEAR reg</c>, <c>CALL NEAR [mem]</c>, <c>CALL FAR [mem]</c></summary>
		IndirectCall = 6,
		/// <summary>It&apos;s an interrupt instruction: <c>INT n</c>, <c>INT3</c>, <c>INT1</c>, <c>INTO</c>, <c>SMINT</c>, <c>DMINT</c></summary>
		Interrupt = 7,
		/// <summary>It&apos;s <c>XBEGIN</c></summary>
		XbeginXabortXend = 8,
		/// <summary>It&apos;s an invalid instruction, eg. <see cref="Code.INVALID"/>, <c>UD0</c>, <c>UD1</c>, <c>UD2</c></summary>
		Exception = 9,
	}
}
#endif
