// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if NASM
using System;
using System.Collections.Generic;
using UnitTests.Intel.FormatterTests;

namespace UnitTests.Intel;

static partial class ToEnumConverter {
	public static bool TryOptionsProps(string value, out OptionsProps optionsProps) => optionsPropsDict.TryGetValue(value, out optionsProps);
	public static OptionsProps GetOptionsProps(string value) => TryOptionsProps(value, out var optionsProps) ? optionsProps : throw new InvalidOperationException($"Invalid OptionsProps value: {value}");

	static readonly Dictionary<string, OptionsProps> optionsPropsDict =
		// GENERATOR-BEGIN: OptionsPropsHash
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		new Dictionary<string, OptionsProps>(60, StringComparer.Ordinal) {
			{ "AddLeadingZeroToHexNumbers", OptionsProps.AddLeadingZeroToHexNumbers },
			{ "AlwaysShowScale", OptionsProps.AlwaysShowScale },
			{ "AlwaysShowSegmentRegister", OptionsProps.AlwaysShowSegmentRegister },
			{ "BinaryDigitGroupSize", OptionsProps.BinaryDigitGroupSize },
			{ "BinaryPrefix", OptionsProps.BinaryPrefix },
			{ "BinarySuffix", OptionsProps.BinarySuffix },
			{ "BranchLeadingZeros", OptionsProps.BranchLeadingZeros },
			{ "DecimalDigitGroupSize", OptionsProps.DecimalDigitGroupSize },
			{ "DecimalPrefix", OptionsProps.DecimalPrefix },
			{ "DecimalSuffix", OptionsProps.DecimalSuffix },
			{ "DigitSeparator", OptionsProps.DigitSeparator },
			{ "DisplacementLeadingZeros", OptionsProps.DisplacementLeadingZeros },
			{ "FirstOperandCharIndex", OptionsProps.FirstOperandCharIndex },
			{ "HexDigitGroupSize", OptionsProps.HexDigitGroupSize },
			{ "HexPrefix", OptionsProps.HexPrefix },
			{ "HexSuffix", OptionsProps.HexSuffix },
			{ "IP", OptionsProps.IP },
			{ "LeadingZeros", OptionsProps.LeadingZeros },
			{ "MemorySizeOptions", OptionsProps.MemorySizeOptions },
			{ "NasmShowSignExtendedImmediateSize", OptionsProps.NasmShowSignExtendedImmediateSize },
			{ "NumberBase", OptionsProps.NumberBase },
			{ "OctalDigitGroupSize", OptionsProps.OctalDigitGroupSize },
			{ "OctalPrefix", OptionsProps.OctalPrefix },
			{ "OctalSuffix", OptionsProps.OctalSuffix },
			{ "PreferST0", OptionsProps.PreferST0 },
			{ "RipRelativeAddresses", OptionsProps.RipRelativeAddresses },
			{ "ScaleBeforeIndex", OptionsProps.ScaleBeforeIndex },
			{ "ShowBranchSize", OptionsProps.ShowBranchSize },
			{ "ShowSymbolAddress", OptionsProps.ShowSymbolAddress },
			{ "ShowZeroDisplacements", OptionsProps.ShowZeroDisplacements },
			{ "SignedImmediateOperands", OptionsProps.SignedImmediateOperands },
			{ "SignedMemoryDisplacements", OptionsProps.SignedMemoryDisplacements },
			{ "SmallHexNumbersInDecimal", OptionsProps.SmallHexNumbersInDecimal },
			{ "SpaceAfterMemoryBracket", OptionsProps.SpaceAfterMemoryBracket },
			{ "SpaceAfterOperandSeparator", OptionsProps.SpaceAfterOperandSeparator },
			{ "SpaceBetweenMemoryAddOperators", OptionsProps.SpaceBetweenMemoryAddOperators },
			{ "SpaceBetweenMemoryMulOperators", OptionsProps.SpaceBetweenMemoryMulOperators },
			{ "TabSize", OptionsProps.TabSize },
			{ "UppercaseAll", OptionsProps.UppercaseAll },
			{ "UppercaseDecorators", OptionsProps.UppercaseDecorators },
			{ "UppercaseHex", OptionsProps.UppercaseHex },
			{ "UppercaseKeywords", OptionsProps.UppercaseKeywords },
			{ "UppercaseMnemonics", OptionsProps.UppercaseMnemonics },
			{ "UppercasePrefixes", OptionsProps.UppercasePrefixes },
			{ "UppercaseRegisters", OptionsProps.UppercaseRegisters },
			{ "UsePseudoOps", OptionsProps.UsePseudoOps },
			{ "CC_b", OptionsProps.CC_b },
			{ "CC_ae", OptionsProps.CC_ae },
			{ "CC_e", OptionsProps.CC_e },
			{ "CC_ne", OptionsProps.CC_ne },
			{ "CC_be", OptionsProps.CC_be },
			{ "CC_a", OptionsProps.CC_a },
			{ "CC_p", OptionsProps.CC_p },
			{ "CC_np", OptionsProps.CC_np },
			{ "CC_l", OptionsProps.CC_l },
			{ "CC_ge", OptionsProps.CC_ge },
			{ "CC_le", OptionsProps.CC_le },
			{ "CC_g", OptionsProps.CC_g },
			{ "DecoderOptions", OptionsProps.DecoderOptions },
			{ "ShowUselessPrefixes", OptionsProps.ShowUselessPrefixes },
		};
		// GENERATOR-END: OptionsPropsHash
}
#endif
