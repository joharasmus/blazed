// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if MASM || NASM
using System;
using System.Collections.Generic;
using Blazed.Intel;

namespace UnitTests.Intel.FormatterTests {
	// GENERATOR-BEGIN: OptionsProps
	// ⚠️This was generated by GENERATOR!🦹‍♂️
	enum OptionsProps {
		AddLeadingZeroToHexNumbers,
		AlwaysShowScale,
		AlwaysShowSegmentRegister,
		BinaryDigitGroupSize,
		BinaryPrefix,
		BinarySuffix,
		BranchLeadingZeros,
		DecimalDigitGroupSize,
		DecimalPrefix,
		DecimalSuffix,
		DigitSeparator,
		DisplacementLeadingZeros,
		FirstOperandCharIndex,
		HexDigitGroupSize,
		HexPrefix,
		HexSuffix,
		IP,
		LeadingZeros,
		MasmAddDsPrefix32,
		MemorySizeOptions,
		NasmShowSignExtendedImmediateSize,
		NumberBase,
		OctalDigitGroupSize,
		OctalPrefix,
		OctalSuffix,
		PreferST0,
		RipRelativeAddresses,
		ScaleBeforeIndex,
		ShowBranchSize,
		ShowSymbolAddress,
		ShowZeroDisplacements,
		SignedImmediateOperands,
		SignedMemoryDisplacements,
		SmallHexNumbersInDecimal,
		SpaceAfterMemoryBracket,
		SpaceAfterOperandSeparator,
		SpaceBetweenMemoryAddOperators,
		SpaceBetweenMemoryMulOperators,
		TabSize,
		UppercaseAll,
		UppercaseDecorators,
		UppercaseHex,
		UppercaseKeywords,
		UppercaseMnemonics,
		UppercasePrefixes,
		UppercaseRegisters,
		UsePseudoOps,
		CC_b,
		CC_ae,
		CC_e,
		CC_ne,
		CC_be,
		CC_a,
		CC_p,
		CC_np,
		CC_l,
		CC_ge,
		CC_le,
		CC_g,
		DecoderOptions,
		ShowUselessPrefixes,
	}
	// GENERATOR-END: OptionsProps

	static class OptionsPropsUtils {
		public static DecoderOptions GetDecoderOptions(IList<(OptionsProps property, object value)> props) {
			var options = DecoderOptions.None;
			foreach (var (prop, value) in props) {
				if (prop == OptionsProps.DecoderOptions)
					options |= (DecoderOptions)value;
			}
			return options;
		}

#if MASM || NASM
		public static void Initialize(FormatterOptions options, OptionsProps property, object value) {
			switch (property) {
			case OptionsProps.AddLeadingZeroToHexNumbers: options.AddLeadingZeroToHexNumbers = (bool)value; break;
			case OptionsProps.AlwaysShowScale: options.AlwaysShowScale = (bool)value; break;
			case OptionsProps.AlwaysShowSegmentRegister: options.AlwaysShowSegmentRegister = (bool)value; break;
			case OptionsProps.BinaryDigitGroupSize: options.BinaryDigitGroupSize = (int)value; break;
			case OptionsProps.BinaryPrefix: options.BinaryPrefix = (string)value; break;
			case OptionsProps.BinarySuffix: options.BinarySuffix = (string)value; break;
			case OptionsProps.BranchLeadingZeros: options.BranchLeadingZeros = (bool)value; break;
			case OptionsProps.DecimalDigitGroupSize: options.DecimalDigitGroupSize = (int)value; break;
			case OptionsProps.DecimalPrefix: options.DecimalPrefix = (string)value; break;
			case OptionsProps.DecimalSuffix: options.DecimalSuffix = (string)value; break;
			case OptionsProps.DigitSeparator: options.DigitSeparator = (string)value; break;
			case OptionsProps.DisplacementLeadingZeros: options.DisplacementLeadingZeros = (bool)value; break;
			case OptionsProps.FirstOperandCharIndex: options.FirstOperandCharIndex = (int)value; break;
			case OptionsProps.HexDigitGroupSize: options.HexDigitGroupSize = (int)value; break;
			case OptionsProps.HexPrefix: options.HexPrefix = (string)value; break;
			case OptionsProps.HexSuffix: options.HexSuffix = (string)value; break;
			case OptionsProps.LeadingZeros: options.LeadingZeros = (bool)value; break;
			case OptionsProps.MasmAddDsPrefix32: options.MasmAddDsPrefix32 = (bool)value; break;
			case OptionsProps.MemorySizeOptions: options.MemorySizeOptions = (MemorySizeOptions)value; break;
			case OptionsProps.NasmShowSignExtendedImmediateSize: options.NasmShowSignExtendedImmediateSize = (bool)value; break;
			case OptionsProps.NumberBase: options.NumberBase = (NumberBase)value; break;
			case OptionsProps.OctalDigitGroupSize: options.OctalDigitGroupSize = (int)value; break;
			case OptionsProps.OctalPrefix: options.OctalPrefix = (string)value; break;
			case OptionsProps.OctalSuffix: options.OctalSuffix = (string)value; break;
			case OptionsProps.PreferST0: options.PreferST0 = (bool)value; break;
			case OptionsProps.RipRelativeAddresses: options.RipRelativeAddresses = (bool)value; break;
			case OptionsProps.ScaleBeforeIndex: options.ScaleBeforeIndex = (bool)value; break;
			case OptionsProps.ShowBranchSize: options.ShowBranchSize = (bool)value; break;
			case OptionsProps.ShowSymbolAddress: options.ShowSymbolAddress = (bool)value; break;
			case OptionsProps.ShowZeroDisplacements: options.ShowZeroDisplacements = (bool)value; break;
			case OptionsProps.SignedImmediateOperands: options.SignedImmediateOperands = (bool)value; break;
			case OptionsProps.SignedMemoryDisplacements: options.SignedMemoryDisplacements = (bool)value; break;
			case OptionsProps.SmallHexNumbersInDecimal: options.SmallHexNumbersInDecimal = (bool)value; break;
			case OptionsProps.SpaceAfterMemoryBracket: options.SpaceAfterMemoryBracket = (bool)value; break;
			case OptionsProps.SpaceAfterOperandSeparator: options.SpaceAfterOperandSeparator = (bool)value; break;
			case OptionsProps.SpaceBetweenMemoryAddOperators: options.SpaceBetweenMemoryAddOperators = (bool)value; break;
			case OptionsProps.SpaceBetweenMemoryMulOperators: options.SpaceBetweenMemoryMulOperators = (bool)value; break;
			case OptionsProps.TabSize: options.TabSize = (int)value; break;
			case OptionsProps.UppercaseAll: options.UppercaseAll = (bool)value; break;
			case OptionsProps.UppercaseDecorators: options.UppercaseDecorators = (bool)value; break;
			case OptionsProps.UppercaseHex: options.UppercaseHex = (bool)value; break;
			case OptionsProps.UppercaseKeywords: options.UppercaseKeywords = (bool)value; break;
			case OptionsProps.UppercaseMnemonics: options.UppercaseMnemonics = (bool)value; break;
			case OptionsProps.UppercasePrefixes: options.UppercasePrefixes = (bool)value; break;
			case OptionsProps.UppercaseRegisters: options.UppercaseRegisters = (bool)value; break;
			case OptionsProps.UsePseudoOps: options.UsePseudoOps = (bool)value; break;
			case OptionsProps.CC_b: options.CC_b = (CC_b)value; break;
			case OptionsProps.CC_ae: options.CC_ae = (CC_ae)value; break;
			case OptionsProps.CC_e: options.CC_e = (CC_e)value; break;
			case OptionsProps.CC_ne: options.CC_ne = (CC_ne)value; break;
			case OptionsProps.CC_be: options.CC_be = (CC_be)value; break;
			case OptionsProps.CC_a: options.CC_a = (CC_a)value; break;
			case OptionsProps.CC_p: options.CC_p = (CC_p)value; break;
			case OptionsProps.CC_np: options.CC_np = (CC_np)value; break;
			case OptionsProps.CC_l: options.CC_l = (CC_l)value; break;
			case OptionsProps.CC_ge: options.CC_ge = (CC_ge)value; break;
			case OptionsProps.CC_le: options.CC_le = (CC_le)value; break;
			case OptionsProps.CC_g: options.CC_g = (CC_g)value; break;
			case OptionsProps.ShowUselessPrefixes: options.ShowUselessPrefixes = (bool)value; break;
			case OptionsProps.IP:
			case OptionsProps.DecoderOptions:
				break;
			default: throw new InvalidOperationException();
			}
		}

		public static void Initialize(FormatterOptions options, IEnumerable<(OptionsProps property, object value)> properties) {
			foreach (var info in properties)
				Initialize(options, info.property, info.value);
		}
#endif

		public static void Initialize(Decoder decoder, OptionsProps property, object value) {
			switch (property) {
			case OptionsProps.IP:
				decoder.IP = (ulong)value;
				break;
			}
		}

		public static void Initialize(Decoder decoder, IEnumerable<(OptionsProps property, object value)> properties) {
			foreach (var info in properties)
				Initialize(decoder, info.property, info.value);
		}
	}

	public readonly struct OptionsInstructionInfo {
		public readonly int Bitness;
		public readonly string HexBytes;
		public readonly ulong IP;
		public readonly Code Code;
		public readonly DecoderOptions DecoderOptions;
		readonly List<(OptionsProps property, object value)> properties;
		internal OptionsInstructionInfo(int bitness, string hexBytes, ulong ip, Code code, List<(OptionsProps property, object value)> properties) {
			Bitness = bitness;
			HexBytes = hexBytes;
			IP = ip;
			Code = code;
			this.properties = properties;
			DecoderOptions = OptionsPropsUtils.GetDecoderOptions(properties);
		}

#if MASM || NASM
		internal void Initialize(FormatterOptions options) => OptionsPropsUtils.Initialize(options, properties);
#endif

		internal void Initialize(Decoder decoder) => OptionsPropsUtils.Initialize(decoder, properties);
	}
}
#endif
