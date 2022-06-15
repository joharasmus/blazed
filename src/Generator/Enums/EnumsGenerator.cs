// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

namespace Generator.Enums {
	abstract class EnumsGenerator {
		protected readonly GenTypes genTypes;

		protected EnumsGenerator(GenTypes genTypes) =>
			this.genTypes = genTypes;

		public virtual void GenerateBegin() {}
		public abstract void Generate(EnumType enumType);
		public virtual void GenerateEnd() {}

		public void Generate() {
			var allEnums = new EnumType[] {
				genTypes[TypeIds.Code],
				genTypes[TypeIds.CodeSize],
				genTypes[TypeIds.ConditionCode],
				genTypes[TypeIds.CpuidFeature],
				genTypes[TypeIds.DecoderError],
				genTypes[TypeIds.DecoderOptions],
				genTypes[TypeIds.DecoderTestOptions],
				genTypes[TypeIds.EvexOpCodeHandlerKind],
				genTypes[TypeIds.HandlerFlags],
				genTypes[TypeIds.LegacyHandlerFlags],
				genTypes[TypeIds.MemorySize],
				genTypes[TypeIds.LegacyOpCodeHandlerKind],
				genTypes[TypeIds.PseudoOpsKind],
				genTypes[TypeIds.Register],
				genTypes[TypeIds.SerializedDataKind],
				genTypes[TypeIds.TupleType],
				genTypes[TypeIds.VexOpCodeHandlerKind],
				genTypes[TypeIds.Mnemonic],
				genTypes[TypeIds.FormatterFlowControl],
				genTypes[TypeIds.CtorKind],
				genTypes[TypeIds.SignExtendInfo],
				genTypes[TypeIds.SizeOverride],
				genTypes[TypeIds.BranchSizeInfo],
				genTypes[TypeIds.InstrOpInfoFlags],
				genTypes[TypeIds.MemorySizeInfo],
				genTypes[TypeIds.FarMemorySizeInfo],
				genTypes[TypeIds.InstrOpKind],
				genTypes[TypeIds.MemorySizeOptions],
				genTypes[TypeIds.NumberBase],
				genTypes[TypeIds.FormatMnemonicOptions],
				genTypes[TypeIds.PrefixKind],
				genTypes[TypeIds.DecoratorKind],
				genTypes[TypeIds.NumberKind],
				genTypes[TypeIds.FormatterTextKind],
				genTypes[TypeIds.SymbolFlags],
				genTypes[TypeIds.OptionsProps],
				genTypes[TypeIds.CC_b],
				genTypes[TypeIds.CC_ae],
				genTypes[TypeIds.CC_e],
				genTypes[TypeIds.CC_ne],
				genTypes[TypeIds.CC_be],
				genTypes[TypeIds.CC_a],
				genTypes[TypeIds.CC_p],
				genTypes[TypeIds.CC_np],
				genTypes[TypeIds.CC_l],
				genTypes[TypeIds.CC_ge],
				genTypes[TypeIds.CC_le],
				genTypes[TypeIds.CC_g],
				genTypes[TypeIds.RoundingControl],
				genTypes[TypeIds.OpKind],
				genTypes[TypeIds.InstrScale],
				genTypes[TypeIds.InstrFlags1],
				genTypes[TypeIds.VectorLength],
				genTypes[TypeIds.MandatoryPrefixByte],
				genTypes[TypeIds.StateFlags],
				genTypes[TypeIds.OpSize],
				genTypes[TypeIds.EncodingKind],
				genTypes[TypeIds.FlowControl],
				genTypes[TypeIds.OpCodeOperandKind],
				genTypes[TypeIds.RflagsBits],
				genTypes[TypeIds.OpAccess],
				genTypes[TypeIds.MemorySizeFlags],
				genTypes[TypeIds.RegisterFlags],
				genTypes[TypeIds.LegacyOpCodeTable],
				genTypes[TypeIds.VexOpCodeTable],
				genTypes[TypeIds.XopOpCodeTable],
				genTypes[TypeIds.EvexOpCodeTable],
				genTypes[TypeIds.MandatoryPrefix],
				genTypes[TypeIds.OpCodeTableKind],
				genTypes[TypeIds.DisplSize],
				genTypes[TypeIds.ImmSize],
				genTypes[TypeIds.EncoderFlags],
				genTypes[TypeIds.WBit],
				genTypes[TypeIds.LBit],
				genTypes[TypeIds.LKind],
				genTypes[TypeIds.RepPrefixKind],
				genTypes[TypeIds.RelocKind],
				genTypes[TypeIds.BlockEncoderOptions],
				genTypes[TypeIds.EncFlags2],
				genTypes[TypeIds.EncFlags3],
				genTypes[TypeIds.OpCodeInfoFlags1],
				genTypes[TypeIds.OpCodeInfoFlags2],
				genTypes[TypeIds.DecOptionValue],
				genTypes[TypeIds.InstrStrFmtOption],
				genTypes[TypeIds.CodeAsmMemoryOperandSize],
				genTypes[TypeIds.TestInstrFlags]
			};

			GenerateBegin();
			foreach (var enumType in allEnums)
				Generate(enumType);
			GenerateEnd();
		}
	}
}
