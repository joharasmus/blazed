// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if NASM
using System;

namespace UnitTests.Intel.FormatterTests {
	static class OptionsParser {
		static readonly char[] kvseps = new char[] { '=' };
		public static (OptionsProps property, object value) ParseOption(string keyValue) {
			var kv = keyValue.Split(kvseps, 2);
			if (kv.Length != 2)
				throw new InvalidOperationException($"Expected key=value: '{keyValue}'");
			var valueStr = kv[1].Trim();
			var prop = ToEnumConverter.GetOptionsProps(kv[0].Trim());
			object value;
			switch (prop) {
			case OptionsProps.AddLeadingZeroToHexNumbers:
			case OptionsProps.AlwaysShowScale:
			case OptionsProps.AlwaysShowSegmentRegister:
			case OptionsProps.BranchLeadingZeros:
			case OptionsProps.DisplacementLeadingZeros:
			case OptionsProps.LeadingZeros:
			case OptionsProps.NasmShowSignExtendedImmediateSize:
			case OptionsProps.PreferST0:
			case OptionsProps.RipRelativeAddresses:
			case OptionsProps.ScaleBeforeIndex:
			case OptionsProps.ShowBranchSize:
			case OptionsProps.ShowSymbolAddress:
			case OptionsProps.ShowZeroDisplacements:
			case OptionsProps.SignedImmediateOperands:
			case OptionsProps.SignedMemoryDisplacements:
			case OptionsProps.SmallHexNumbersInDecimal:
			case OptionsProps.SpaceAfterMemoryBracket:
			case OptionsProps.SpaceAfterOperandSeparator:
			case OptionsProps.SpaceBetweenMemoryAddOperators:
			case OptionsProps.SpaceBetweenMemoryMulOperators:
			case OptionsProps.UppercaseAll:
			case OptionsProps.UppercaseDecorators:
			case OptionsProps.UppercaseHex:
			case OptionsProps.UppercaseKeywords:
			case OptionsProps.UppercaseMnemonics:
			case OptionsProps.UppercasePrefixes:
			case OptionsProps.UppercaseRegisters:
			case OptionsProps.UsePseudoOps:
			case OptionsProps.ShowUselessPrefixes:
				value = NumberConverter.ToBoolean(valueStr);
				break;

			case OptionsProps.BinaryDigitGroupSize:
			case OptionsProps.DecimalDigitGroupSize:
			case OptionsProps.FirstOperandCharIndex:
			case OptionsProps.HexDigitGroupSize:
			case OptionsProps.OctalDigitGroupSize:
			case OptionsProps.TabSize:
				value = NumberConverter.ToInt32(valueStr);
				break;

			case OptionsProps.IP:
				value = NumberConverter.ToUInt64(valueStr);
				break;

			case OptionsProps.BinaryPrefix:
			case OptionsProps.BinarySuffix:
			case OptionsProps.DecimalPrefix:
			case OptionsProps.DecimalSuffix:
			case OptionsProps.DigitSeparator:
			case OptionsProps.HexPrefix:
			case OptionsProps.HexSuffix:
			case OptionsProps.OctalPrefix:
			case OptionsProps.OctalSuffix:
				value = valueStr == "<null>" ? null : valueStr;
				break;

			case OptionsProps.MemorySizeOptions:
				value = ToEnumConverter.GetMemorySizeOptions(valueStr);
				break;

			case OptionsProps.NumberBase:
#if NASM
				value = ToEnumConverter.GetNumberBase(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_b:
#if NASM
				value = ToEnumConverter.GetCC_b(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_ae:
#if NASM
				value = ToEnumConverter.GetCC_ae(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_e:
#if NASM
				value = ToEnumConverter.GetCC_e(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_ne:
#if NASM
				value = ToEnumConverter.GetCC_ne(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_be:
#if NASM
				value = ToEnumConverter.GetCC_be(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_a:
#if NASM
				value = ToEnumConverter.GetCC_a(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_p:
#if NASM
				value = ToEnumConverter.GetCC_p(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_np:
#if NASM
				value = ToEnumConverter.GetCC_np(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_l:
#if NASM
				value = ToEnumConverter.GetCC_l(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_ge:
#if NASM
				value = ToEnumConverter.GetCC_ge(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_le:
#if NASM
				value = ToEnumConverter.GetCC_le(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.CC_g:
#if NASM
				value = ToEnumConverter.GetCC_g(valueStr);
#else
				value = new object();			
#endif			
				break;

			case OptionsProps.DecoderOptions:
				value = ToEnumConverter.GetDecoderOptions(valueStr);
				break;

			default:
				throw new InvalidOperationException();
			}
			return (prop, value);
		}
	}
}
#endif
