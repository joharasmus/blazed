// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if INSTR_INFO
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Iced.Intel {
	/// <summary>
	/// Contains the FPU <c>TOP</c> increment, whether it's conditional and whether the instruction writes to <c>TOP</c>
	/// </summary>
	public readonly struct FpuStackIncrementInfo {
		/// <summary>
		/// Used if <see cref="WritesTop"/> is <see langword="true"/>:<br/>
		/// <br/>
		/// Value added to <c>TOP</c>.<br/>
		/// <br/>
		/// This is negative if it pushes one or more values and positive if it pops one or more values
		/// and <c>0</c> if it writes to <c>TOP</c> (eg. <c>FLDENV</c>, etc) without pushing/popping anything.
		/// </summary>
		public readonly int Increment;

		/// <summary>
		/// <see langword="true"/> if it's a conditional push/pop (eg. <c>FPTAN</c> or <c>FSINCOS</c>)
		/// </summary>
		public readonly bool Conditional;

		/// <summary>
		/// <see langword="true"/> if <c>TOP</c> is written (it's a conditional/unconditional push/pop, <c>FNSAVE</c>, <c>FLDENV</c>, etc)
		/// </summary>
		public readonly bool WritesTop;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="increment"></param>
		/// <param name="conditional"></param>
		/// <param name="writesTop"></param>
		public FpuStackIncrementInfo(int increment, bool conditional, bool writesTop) {
			Increment = increment;
			Conditional = conditional;
			WritesTop = writesTop;
		}
	}

	partial struct Instruction {
		/// <summary>
		/// Gets the number of bytes added to <c>SP</c>/<c>ESP</c>/<c>RSP</c> or 0 if it's not an instruction that pushes or pops data. This method assumes
		/// the instruction doesn't change the privilege level (eg. <c>IRET/D/Q</c>). If it's the <c>LEAVE</c> instruction, this method returns 0.
		/// </summary>
		/// <returns></returns>
		public readonly int StackPointerIncrement {
			get {
				switch (Code) {
				// GENERATOR-BEGIN: StackPointerIncrementTable
				// ⚠️This was generated by GENERATOR!🦹‍♂️
				case Code.Pushad:
					return -32;
				case Code.Pushaw:
				case Code.Call_m1664:
					return -16;
				case Code.Push_r64:
				case Code.Pushq_imm32:
				case Code.Pushq_imm8:
				case Code.Call_ptr1632:
				case Code.Pushfq:
				case Code.Call_rel32_64:
				case Code.Call_rm64:
				case Code.Call_m1632:
				case Code.Push_rm64:
				case Code.Pushq_FS:
				case Code.Pushq_GS:
					return -8;
				case Code.Pushd_ES:
				case Code.Pushd_CS:
				case Code.Pushd_SS:
				case Code.Pushd_DS:
				case Code.Push_r32:
				case Code.Pushd_imm32:
				case Code.Pushd_imm8:
				case Code.Call_ptr1616:
				case Code.Pushfd:
				case Code.Call_rel32_32:
				case Code.Call_rm32:
				case Code.Call_m1616:
				case Code.Push_rm32:
				case Code.Pushd_FS:
				case Code.Pushd_GS:
					return -4;
				case Code.Pushw_ES:
				case Code.Pushw_CS:
				case Code.Pushw_SS:
				case Code.Pushw_DS:
				case Code.Push_r16:
				case Code.Push_imm16:
				case Code.Pushw_imm8:
				case Code.Pushfw:
				case Code.Call_rel16:
				case Code.Call_rm16:
				case Code.Push_rm16:
				case Code.Pushw_FS:
				case Code.Pushw_GS:
					return -2;
				case Code.Popw_ES:
				case Code.Popw_CS:
				case Code.Popw_SS:
				case Code.Popw_DS:
				case Code.Pop_r16:
				case Code.Pop_rm16:
				case Code.Popfw:
				case Code.Retnw:
				case Code.Popw_FS:
				case Code.Popw_GS:
					return 2;
				case Code.Popd_ES:
				case Code.Popd_SS:
				case Code.Popd_DS:
				case Code.Pop_r32:
				case Code.Pop_rm32:
				case Code.Popfd:
				case Code.Retnd:
				case Code.Retfw:
				case Code.Popd_FS:
				case Code.Popd_GS:
					return 4;
				case Code.Pop_r64:
				case Code.Pop_rm64:
				case Code.Popfq:
				case Code.Retnq:
				case Code.Retfd:
				case Code.Popq_FS:
				case Code.Popq_GS:
					return 8;
				case Code.Popaw:
				case Code.Retfq:
					return 16;
				case Code.Uiret:
					return 24;
				case Code.Popad:
					return 32;
				case Code.Iretq:
				case Code.Eretu:
				case Code.Erets:
					return 40;
				case Code.Enterw_imm16_imm8:
					return -(2 + (Immediate8_2nd & 0x1F) * 2 + Immediate16);
				case Code.Enterd_imm16_imm8:
					return -(4 + (Immediate8_2nd & 0x1F) * 4 + Immediate16);
				case Code.Enterq_imm16_imm8:
					return -(8 + (Immediate8_2nd & 0x1F) * 8 + Immediate16);
				case Code.Iretw:
					return CodeSize == CodeSize.Code64 ? 2 * 5 : 2 * 3;
				case Code.Iretd:
					return CodeSize == CodeSize.Code64 ? 4 * 5 : 4 * 3;
				case Code.Retnw_imm16:
					return 2 + Immediate16;
				case Code.Retnd_imm16:
				case Code.Retfw_imm16:
					return 4 + Immediate16;
				case Code.Retnq_imm16:
				case Code.Retfd_imm16:
					return 8 + Immediate16;
				case Code.Retfq_imm16:
					return 16 + Immediate16;
				// GENERATOR-END: StackPointerIncrementTable
				default:
					return 0;
				}
			}
		}

		/// <summary>
		/// Gets the FPU status word's <c>TOP</c> increment and whether it's a conditional or unconditional push/pop
		/// and whether <c>TOP</c> is written.
		/// </summary>
		/// <returns></returns>
		public readonly FpuStackIncrementInfo GetFpuStackIncrementInfo() {
			switch (Code) {
			// GENERATOR-BEGIN: FpuStackIncrementInfoTable
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			case Code.Fld_m32fp:
			case Code.Fld_sti:
			case Code.Fld1:
			case Code.Fldl2t:
			case Code.Fldl2e:
			case Code.Fldpi:
			case Code.Fldlg2:
			case Code.Fldln2:
			case Code.Fldz:
			case Code.Fxtract:
			case Code.Fdecstp:
			case Code.Fild_m32int:
			case Code.Fld_m80fp:
			case Code.Fld_m64fp:
			case Code.Fild_m16int:
			case Code.Fbld_m80bcd:
			case Code.Fild_m64int:
				return new FpuStackIncrementInfo(-1, false, true);
			case Code.Fptan:
			case Code.Fsincos:
				return new FpuStackIncrementInfo(-1, true, true);
			case Code.Fldenv_m14byte:
			case Code.Fldenv_m28byte:
			case Code.Fninit:
			case Code.Finit:
			case Code.Frstor_m94byte:
			case Code.Frstor_m108byte:
			case Code.Fnsave_m94byte:
			case Code.Fsave_m94byte:
			case Code.Fnsave_m108byte:
			case Code.Fsave_m108byte:
				return new FpuStackIncrementInfo(0, false, true);
			case Code.Fcomp_m32fp:
			case Code.Fcomp_st0_sti:
			case Code.Fstp_m32fp:
			case Code.Fstpnce_sti:
			case Code.Fyl2x:
			case Code.Fpatan:
			case Code.Fincstp:
			case Code.Fyl2xp1:
			case Code.Ficomp_m32int:
			case Code.Fisttp_m32int:
			case Code.Fistp_m32int:
			case Code.Fstp_m80fp:
			case Code.Fcomp_m64fp:
			case Code.Fcomp_st0_sti_DCD8:
			case Code.Fisttp_m64int:
			case Code.Fstp_m64fp:
			case Code.Fstp_sti:
			case Code.Fucomp_st0_sti:
			case Code.Ficomp_m16int:
			case Code.Faddp_sti_st0:
			case Code.Fmulp_sti_st0:
			case Code.Fcomp_st0_sti_DED0:
			case Code.Fsubrp_sti_st0:
			case Code.Fsubp_sti_st0:
			case Code.Fdivrp_sti_st0:
			case Code.Fdivp_sti_st0:
			case Code.Fisttp_m16int:
			case Code.Fistp_m16int:
			case Code.Fbstp_m80bcd:
			case Code.Fistp_m64int:
			case Code.Ffreep_sti:
			case Code.Fstp_sti_DFD0:
			case Code.Fstp_sti_DFD8:
			case Code.Fucomip_st0_sti:
			case Code.Fcomip_st0_sti:
			case Code.Ftstp:
				return new FpuStackIncrementInfo(1, false, true);
			case Code.Fucompp:
			case Code.Fcompp:
				return new FpuStackIncrementInfo(2, false, true);
			// GENERATOR-END: FpuStackIncrementInfoTable
			default:
				return default;
			}
		}

		/// <summary>
		/// Instruction encoding, eg. Legacy, 3DNow!, VEX, EVEX, XOP
		/// </summary>
		public readonly EncodingKind Encoding {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.Encoding();
		}

		/// <summary>
		/// Gets the CPU or CPUID feature flags
		/// </summary>
		public readonly CpuidFeature[] CpuidFeatures {
			get {
				var code = Code;
				uint flags2 = InstructionInfoInternal.InstrInfoTable.Data[(int)code * 2 + 1];
				var cpuidFeature = (InstructionInfoInternal.CpuidFeatureInternal)(flags2 >> (int)InstructionInfoInternal.InfoFlags2.CpuidFeatureInternalShift & (uint)InstructionInfoInternal.InfoFlags2.CpuidFeatureInternalMask);
				return InstructionInfoInternal.CpuidFeatureInternalData.ToCpuidFeatures[(int)cpuidFeature];
			}
		}

		/// <summary>
		/// Control flow info
		/// </summary>
		public readonly FlowControl FlowControl {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.FlowControl();
		}

		/// <summary>
		/// <see langword="true"/> if it's a privileged instruction (all CPL=0 instructions (except <c>VMCALL</c>) and IOPL instructions <c>IN</c>, <c>INS</c>, <c>OUT</c>, <c>OUTS</c>, <c>CLI</c>, <c>STI</c>)
		/// </summary>
		public readonly bool IsPrivileged {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsPrivileged();
		}

		/// <summary>
		/// <see langword="true"/> if this is an instruction that implicitly uses the stack pointer (<c>SP</c>/<c>ESP</c>/<c>RSP</c>), eg. <c>CALL</c>, <c>PUSH</c>, <c>POP</c>, <c>RET</c>, etc.
		/// See also <see cref="StackPointerIncrement"/>
		/// </summary>
		public readonly bool IsStackInstruction {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsStackInstruction();
		}

		/// <summary>
		/// <see langword="true"/> if it's an instruction that saves or restores too many registers (eg. <c>FXRSTOR</c>, <c>XSAVE</c>, etc).
		/// </summary>
		public readonly bool IsSaveRestoreInstruction {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsSaveRestoreInstruction();
		}

		readonly InstructionInfoInternal.RflagsInfo GetRflagsInfo() {
			var flags1 = InstructionInfoInternal.InstrInfoTable.Data[(int)Code << 1];
			var impliedAccess = (InstructionInfoInternal.ImpliedAccess)((flags1 >> (int)InstructionInfoInternal.InfoFlags1.ImpliedAccessShift) & (uint)InstructionInfoInternal.InfoFlags1.ImpliedAccessMask);
			Static.Assert(InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9 + 1 == InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD11 ? 0 : -1);
			Static.Assert(InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9 + 2 == InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1F ? 0 : -1);
			Static.Assert(InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9 + 3 == InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK3F ? 0 : -1);
			Static.Assert(InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9 + 4 == InstructionInfoInternal.ImpliedAccess.Clear_rflags ? 0 : -1);
			var result = (InstructionInfoInternal.RflagsInfo)((flags1 >> (int)InstructionInfoInternal.InfoFlags1.RflagsInfoShift) & (uint)InstructionInfoInternal.InfoFlags1.RflagsInfoMask);
			var e = (uint)(impliedAccess - InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9);
			switch (e) {
			case InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9 - InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9:
			case InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD11 - InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9:
				var m = e == InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9 - InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9 ? 9 : 17;
				switch ((Immediate8 & 0x1F) % m) {
				case 0:
					return InstructionInfoInternal.RflagsInfo.None;
				case 1:
					return InstructionInfoInternal.RflagsInfo.R_c_W_co;
				}
				break;

			case InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1F - InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9:
			case InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK3F - InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9:
				var mask = e == InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1F - InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9 ? 0x1F : 0x3F;
				switch (Immediate8 & mask) {
				case 0:
					return InstructionInfoInternal.RflagsInfo.None;
				case 1:
					if (result == InstructionInfoInternal.RflagsInfo.W_c_U_o)
						return InstructionInfoInternal.RflagsInfo.W_co;
					else if (result == InstructionInfoInternal.RflagsInfo.R_c_W_c_U_o)
						return InstructionInfoInternal.RflagsInfo.R_c_W_co;
					else {
						Debug.Assert(result == InstructionInfoInternal.RflagsInfo.W_cpsz_U_ao);
						return InstructionInfoInternal.RflagsInfo.W_copsz_U_a;
					}
				}
				break;

			case InstructionInfoInternal.ImpliedAccess.Clear_rflags - InstructionInfoInternal.ImpliedAccess.Shift_Ib_MASK1FMOD9:
				if (Op0Register != Op1Register)
					break;
				if (Op0Kind != OpKind.Register || Op1Kind != OpKind.Register)
					break;
				if (Mnemonic == Mnemonic.Xor)
					return InstructionInfoInternal.RflagsInfo.C_cos_S_pz_U_a;
				else
					return InstructionInfoInternal.RflagsInfo.C_acos_S_pz;
			}
			return result;
		}

		/// <summary>
		/// All flags that are read by the CPU when executing the instruction. See also <see cref="RflagsModified"/>
		/// </summary>
		public readonly RflagsBits RflagsRead {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get {
				// If the method call is used without a temp index, the jitter generates worse code.
				// It stores the array in a temp local, then it calls the method, and then it reads
				// the temp local and checks if we can read the array.
				int index = (int)GetRflagsInfo();
				return (RflagsBits)InstructionInfoInternal.RflagsInfoConstants.flagsRead[index];
			}
		}

		/// <summary>
		/// All flags that are written by the CPU, except those flags that are known to be undefined, always set or always cleared. See also <see cref="RflagsModified"/>
		/// </summary>
		public readonly RflagsBits RflagsWritten {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get {
				// See RflagsRead for the reason why a temp index is used here
				int index = (int)GetRflagsInfo();
				return (RflagsBits)InstructionInfoInternal.RflagsInfoConstants.flagsWritten[index];
			}
		}

		/// <summary>
		/// All flags that are always cleared by the CPU. See also <see cref="RflagsModified"/>
		/// </summary>
		public readonly RflagsBits RflagsCleared {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get {
				// See RflagsRead for the reason why a temp index is used here
				int index = (int)GetRflagsInfo();
				return (RflagsBits)InstructionInfoInternal.RflagsInfoConstants.flagsCleared[index];
			}
		}

		/// <summary>
		/// All flags that are always set by the CPU. See also <see cref="RflagsModified"/>
		/// </summary>
		public readonly RflagsBits RflagsSet {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get {
				// See RflagsRead for the reason why a temp index is used here
				int index = (int)GetRflagsInfo();
				return (RflagsBits)InstructionInfoInternal.RflagsInfoConstants.flagsSet[index];
			}
		}

		/// <summary>
		/// All flags that are undefined after executing the instruction. See also <see cref="RflagsModified"/>
		/// </summary>
		public readonly RflagsBits RflagsUndefined {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get {
				// See RflagsRead for the reason why a temp index is used here
				int index = (int)GetRflagsInfo();
				return (RflagsBits)InstructionInfoInternal.RflagsInfoConstants.flagsUndefined[index];
			}
		}

		/// <summary>
		/// All flags that are modified by the CPU. This is <see cref="RflagsWritten"/> + <see cref="RflagsCleared"/> + <see cref="RflagsSet"/> + <see cref="RflagsUndefined"/>
		/// </summary>
		public readonly RflagsBits RflagsModified {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get {
				// See RflagsRead for the reason why a temp index is used here
				int index = (int)GetRflagsInfo();
				return (RflagsBits)InstructionInfoInternal.RflagsInfoConstants.flagsModified[index];
			}
		}

		/// <summary>
		/// Checks if it's a <c>Jcc SHORT</c> or <c>Jcc NEAR</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJccShortOrNear {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJccShortOrNear();
		}

		/// <summary>
		/// Checks if it's a <c>Jcc NEAR</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJccNear {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJccNear();
		}

		/// <summary>
		/// Checks if it's a <c>Jcc SHORT</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJccShort {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJccShort();
		}

		/// <summary>
		/// Checks if it's a <c>JMP SHORT</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJmpShort {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJmpShort();
		}

		/// <summary>
		/// Checks if it's a <c>JMP NEAR</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJmpNear {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJmpNear();
		}

		/// <summary>
		/// Checks if it's a <c>JMP SHORT</c> or a <c>JMP NEAR</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJmpShortOrNear {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJmpShortOrNear();
		}

		/// <summary>
		/// Checks if it's a <c>JMP FAR</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJmpFar {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJmpFar();
		}

		/// <summary>
		/// Checks if it's a <c>CALL NEAR</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsCallNear {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsCallNear();
		}

		/// <summary>
		/// Checks if it's a <c>CALL FAR</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsCallFar {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsCallFar();
		}

		/// <summary>
		/// Checks if it's a <c>JMP NEAR reg/[mem]</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJmpNearIndirect {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJmpNearIndirect();
		}

		/// <summary>
		/// Checks if it's a <c>JMP FAR [mem]</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJmpFarIndirect {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJmpFarIndirect();
		}

		/// <summary>
		/// Checks if it's a <c>CALL NEAR reg/[mem]</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsCallNearIndirect {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsCallNearIndirect();
		}

		/// <summary>
		/// Checks if it's a <c>CALL FAR [mem]</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsCallFarIndirect {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsCallFarIndirect();
		}

#if MVEX
		/// <summary>
		/// Checks if it's a <c>JKccD SHORT</c> or <c>JKccD NEAR</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJkccShortOrNear {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJkccShortOrNear();
		}

		/// <summary>
		/// Checks if it's a <c>JKccD NEAR</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJkccNear {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJkccNear();
		}

		/// <summary>
		/// Checks if it's a <c>JKccD SHORT</c> instruction
		/// </summary>
		/// <returns></returns>
		public readonly bool IsJkccShort {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsJkccShort();
		}
#endif

		/// <summary>
		/// Negates the condition code, eg. <c>JE</c> -> <c>JNE</c>. Can be used if it's <c>Jcc</c>, <c>SETcc</c>, <c>CMOVcc</c>, <c>LOOPcc</c>
		/// and does nothing if the instruction doesn't have a condition code.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void NegateConditionCode() => Code = Code.NegateConditionCode();

		/// <summary>
		/// Converts <c>Jcc/JMP NEAR</c> to <c>Jcc/JMP SHORT</c> and does nothing if it's not a <c>Jcc/JMP NEAR</c> instruction
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ToShortBranch() => Code = Code.ToShortBranch();

		/// <summary>
		/// Converts <c>Jcc/JMP SHORT</c> to <c>Jcc/JMP NEAR</c> and does nothing if it's not a <c>Jcc/JMP SHORT</c> instruction
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ToNearBranch() => Code = Code.ToNearBranch();

		/// <summary>
		/// Gets the condition code if it's <c>Jcc</c>, <c>SETcc</c>, <c>CMOVcc</c>, <c>LOOPcc</c> else <see cref="ConditionCode.None"/> is returned
		/// </summary>
		public readonly ConditionCode ConditionCode {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.ConditionCode();
		}

		/// <summary>
		/// Checks if it's a string instruction such as <c>MOVS</c>, <c>LODS</c>, <c>STOS</c>, etc.
		/// </summary>
		/// <returns></returns>
		public readonly bool IsStringInstruction {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => Code.IsStringInstruction();
		}
	}
}
#endif
