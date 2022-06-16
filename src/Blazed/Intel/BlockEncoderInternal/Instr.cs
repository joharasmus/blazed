// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if ENCODER && BLOCK_ENCODER
using System;
using System.Diagnostics;

namespace Blazed.Intel.BlockEncoderInternal {
	abstract class Instr {
		public readonly Block Block;
		public uint Size;
		public ulong IP;
		public readonly ulong OrigIP;
		// If it can't be optimized, this will be set to true
		public bool Done;

		// 6 = FF 15 XXXXXXXX = call qword ptr [rip+mem_target]
		protected const uint CallOrJmpPointerDataInstructionSize64 = 6;

		protected Instr(Block block, ulong origIp) {
			OrigIP = origIp;
			Block = block;
		}

		/// <summary>
		/// Initializes the target address and tries to optimize the instruction
		/// </summary>
		public abstract void Initialize(BlockEncoder blockEncoder);

		/// <summary>
		/// Returns <see langword="true"/> if the instruction was updated to a shorter instruction, <see langword="false"/> if nothing changed
		/// </summary>
		/// <returns></returns>
		public abstract bool Optimize(ulong gained);

		public abstract string? TryEncode(Encoder encoder, out ConstantOffsets constantOffsets, out bool isOriginalInstruction);

		protected static string CreateErrorMessage(string errorMessage, in Instruction instruction) =>
			$"{errorMessage} : 0x{instruction.IP:X} {instruction.ToString()}";

		public static Instr Create(BlockEncoder blockEncoder, Block block, in Instruction instruction) {
			switch (instruction.Code) {
			// GENERATOR-BEGIN: JccInstr
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			case Code.Jo_rel8_16:
			case Code.Jo_rel8_32:
			case Code.Jo_rel8_64:
			case Code.Jno_rel8_16:
			case Code.Jno_rel8_32:
			case Code.Jno_rel8_64:
			case Code.Jb_rel8_16:
			case Code.Jb_rel8_32:
			case Code.Jb_rel8_64:
			case Code.Jae_rel8_16:
			case Code.Jae_rel8_32:
			case Code.Jae_rel8_64:
			case Code.Je_rel8_16:
			case Code.Je_rel8_32:
			case Code.Je_rel8_64:
			case Code.Jne_rel8_16:
			case Code.Jne_rel8_32:
			case Code.Jne_rel8_64:
			case Code.Jbe_rel8_16:
			case Code.Jbe_rel8_32:
			case Code.Jbe_rel8_64:
			case Code.Ja_rel8_16:
			case Code.Ja_rel8_32:
			case Code.Ja_rel8_64:
			case Code.Js_rel8_16:
			case Code.Js_rel8_32:
			case Code.Js_rel8_64:
			case Code.Jns_rel8_16:
			case Code.Jns_rel8_32:
			case Code.Jns_rel8_64:
			case Code.Jp_rel8_16:
			case Code.Jp_rel8_32:
			case Code.Jp_rel8_64:
			case Code.Jnp_rel8_16:
			case Code.Jnp_rel8_32:
			case Code.Jnp_rel8_64:
			case Code.Jl_rel8_16:
			case Code.Jl_rel8_32:
			case Code.Jl_rel8_64:
			case Code.Jge_rel8_16:
			case Code.Jge_rel8_32:
			case Code.Jge_rel8_64:
			case Code.Jle_rel8_16:
			case Code.Jle_rel8_32:
			case Code.Jle_rel8_64:
			case Code.Jg_rel8_16:
			case Code.Jg_rel8_32:
			case Code.Jg_rel8_64:
			case Code.Jo_rel16:
			case Code.Jo_rel32_32:
			case Code.Jo_rel32_64:
			case Code.Jno_rel16:
			case Code.Jno_rel32_32:
			case Code.Jno_rel32_64:
			case Code.Jb_rel16:
			case Code.Jb_rel32_32:
			case Code.Jb_rel32_64:
			case Code.Jae_rel16:
			case Code.Jae_rel32_32:
			case Code.Jae_rel32_64:
			case Code.Je_rel16:
			case Code.Je_rel32_32:
			case Code.Je_rel32_64:
			case Code.Jne_rel16:
			case Code.Jne_rel32_32:
			case Code.Jne_rel32_64:
			case Code.Jbe_rel16:
			case Code.Jbe_rel32_32:
			case Code.Jbe_rel32_64:
			case Code.Ja_rel16:
			case Code.Ja_rel32_32:
			case Code.Ja_rel32_64:
			case Code.Js_rel16:
			case Code.Js_rel32_32:
			case Code.Js_rel32_64:
			case Code.Jns_rel16:
			case Code.Jns_rel32_32:
			case Code.Jns_rel32_64:
			case Code.Jp_rel16:
			case Code.Jp_rel32_32:
			case Code.Jp_rel32_64:
			case Code.Jnp_rel16:
			case Code.Jnp_rel32_32:
			case Code.Jnp_rel32_64:
			case Code.Jl_rel16:
			case Code.Jl_rel32_32:
			case Code.Jl_rel32_64:
			case Code.Jge_rel16:
			case Code.Jge_rel32_32:
			case Code.Jge_rel32_64:
			case Code.Jle_rel16:
			case Code.Jle_rel32_32:
			case Code.Jle_rel32_64:
			case Code.Jg_rel16:
			case Code.Jg_rel32_32:
			case Code.Jg_rel32_64:
				return new JccInstr(blockEncoder, block, instruction);
			// GENERATOR-END: JccInstr

			// GENERATOR-BEGIN: SimpleBranchInstr
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			case Code.Loopne_rel8_16_CX:
			case Code.Loopne_rel8_32_CX:
			case Code.Loopne_rel8_16_ECX:
			case Code.Loopne_rel8_32_ECX:
			case Code.Loopne_rel8_64_ECX:
			case Code.Loopne_rel8_16_RCX:
			case Code.Loopne_rel8_64_RCX:
			case Code.Loope_rel8_16_CX:
			case Code.Loope_rel8_32_CX:
			case Code.Loope_rel8_16_ECX:
			case Code.Loope_rel8_32_ECX:
			case Code.Loope_rel8_64_ECX:
			case Code.Loope_rel8_16_RCX:
			case Code.Loope_rel8_64_RCX:
			case Code.Loop_rel8_16_CX:
			case Code.Loop_rel8_32_CX:
			case Code.Loop_rel8_16_ECX:
			case Code.Loop_rel8_32_ECX:
			case Code.Loop_rel8_64_ECX:
			case Code.Loop_rel8_16_RCX:
			case Code.Loop_rel8_64_RCX:
			case Code.Jcxz_rel8_16:
			case Code.Jcxz_rel8_32:
			case Code.Jecxz_rel8_16:
			case Code.Jecxz_rel8_32:
			case Code.Jecxz_rel8_64:
			case Code.Jrcxz_rel8_16:
			case Code.Jrcxz_rel8_64:
				return new SimpleBranchInstr(blockEncoder, block, instruction);
			// GENERATOR-END: SimpleBranchInstr

			// GENERATOR-BEGIN: CallInstr
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			case Code.Call_rel16:
			case Code.Call_rel32_32:
			case Code.Call_rel32_64:
				return new CallInstr(blockEncoder, block, instruction);
			// GENERATOR-END: CallInstr

			// GENERATOR-BEGIN: JmpInstr
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			case Code.Jmp_rel16:
			case Code.Jmp_rel32_32:
			case Code.Jmp_rel32_64:
			case Code.Jmp_rel8_16:
			case Code.Jmp_rel8_32:
			case Code.Jmp_rel8_64:
				return new JmpInstr(blockEncoder, block, instruction);
			// GENERATOR-END: JmpInstr

			// GENERATOR-BEGIN: XbeginInstr
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			case Code.Xbegin_rel16:
			case Code.Xbegin_rel32:
				return new XbeginInstr(blockEncoder, block, instruction);
			// GENERATOR-END: XbeginInstr
			default:
				break;
			}

			if (blockEncoder.Bitness == 64) {
				int ops = instruction.OpCount;
				for (int i = 0; i < ops; i++) {
					if (instruction.GetOpKind(i) == OpKind.Memory) {
						if (instruction.IsIPRelativeMemoryOperand)
							return new IpRelMemOpInstr(blockEncoder, block, instruction);
						break;
					}
				}
			}

			return new SimpleInstr(blockEncoder, block, instruction);
		}

		protected string? EncodeBranchToPointerData(Encoder encoder, bool isCall, ulong ip, BlockData pointerData, out uint size, uint minSize) {
			if (minSize > int.MaxValue)
				throw new ArgumentOutOfRangeException(nameof(minSize));

			var instr = new Instruction();
			instr.Op0Kind = OpKind.Memory;
			instr.MemoryDisplSize = encoder.Bitness / 8;
			RelocKind relocKind;
			switch (encoder.Bitness) {
			case 64:
				instr.InternalSetCodeNoCheck(isCall ? Code.Call_rm64 : Code.Jmp_rm64);
				instr.MemoryBase = Register.RIP;

				var nextRip = ip + CallOrJmpPointerDataInstructionSize64;
				long diff = (long)(pointerData.Address - nextRip);
				if (!(int.MinValue <= diff && diff <= int.MaxValue)) {
					size = 0;
					return "Block is too big";
				}

				instr.MemoryDisplacement64 = pointerData.Address;
				relocKind = RelocKind.Offset64;
				break;

			default:
				throw new InvalidOperationException();
			}

			if (!encoder.TryEncode(instr, ip, out size, out var errorMessage))
				return errorMessage;
			if (Block.CanAddRelocInfos && relocKind != RelocKind.Offset64) {
				var constantOffsets = encoder.GetConstantOffsets();
				if (!constantOffsets.HasDisplacement)
					return "Internal error: no displ";
				Block.AddRelocInfo(new RelocInfo(relocKind, IP + constantOffsets.DisplacementOffset));
			}
			while (size < minSize) {
				size++;
				Block.CodeWriter.WriteByte(0x90);
			}
			return null;
		}

		protected static long CorrectDiff(bool inBlock, long diff, ulong gained) {
			if (inBlock && diff >= 0) {
				Debug.Assert((ulong)diff >= gained);
				return diff - (long)gained;
			}
			else
				return diff;
		}
	}
}
#endif
