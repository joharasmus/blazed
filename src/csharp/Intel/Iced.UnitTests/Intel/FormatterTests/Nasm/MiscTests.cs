/*
Copyright (C) 2018-2019 de4dot@gmail.com

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

#if NASM
using System.Collections.Generic;
using Iced.Intel;
using Iced.Intel.NasmFormatterInternal;
using Xunit;

namespace Iced.UnitTests.Intel.FormatterTests.Nasm {
	public sealed class MiscTests {
		[Fact]
		void Register_is_not_too_big() {
			const int maxValue = IcedConstants.RegisterEnumCount - 1 + Registers.ExtraRegisters;
			Static.Assert(maxValue < (1 << InstrOpInfo.TEST_RegisterBits) ? 0 : -1);
			Static.Assert(maxValue >= (1 << (InstrOpInfo.TEST_RegisterBits - 1)) ? 0 : -1);
		}

		[Fact]
		void Verify_default_formatter_options() {
			var options = FormatterOptions.CreateNasm();
			Assert.False(options.UppercasePrefixes);
			Assert.False(options.UppercaseMnemonics);
			Assert.False(options.UppercaseRegisters);
			Assert.False(options.UppercaseKeywords);
			Assert.False(options.UppercaseDecorators);
			Assert.False(options.UppercaseAll);
			Assert.Equal(0, options.FirstOperandCharIndex);
			Assert.Equal(0, options.TabSize);
			Assert.False(options.SpaceAfterOperandSeparator);
			Assert.False(options.SpaceAfterMemoryBracket);
			Assert.False(options.SpaceBetweenMemoryAddOperators);
			Assert.False(options.SpaceBetweenMemoryMulOperators);
			Assert.False(options.ScaleBeforeIndex);
			Assert.False(options.AlwaysShowScale);
			Assert.False(options.AlwaysShowSegmentRegister);
			Assert.False(options.ShowZeroDisplacements);
			Assert.Null(options.HexPrefix);
			Assert.Equal("h", options.HexSuffix);
			Assert.Equal(4, options.HexDigitGroupSize);
			Assert.Null(options.DecimalPrefix);
			Assert.Null(options.DecimalSuffix);
			Assert.Equal(3, options.DecimalDigitGroupSize);
			Assert.Null(options.OctalPrefix);
			Assert.Equal("o", options.OctalSuffix);
			Assert.Equal(4, options.OctalDigitGroupSize);
			Assert.Null(options.BinaryPrefix);
			Assert.Equal("b", options.BinarySuffix);
			Assert.Equal(4, options.BinaryDigitGroupSize);
			Assert.Null(options.DigitSeparator);
			Assert.False(options.LeadingZeroes);
			Assert.True(options.UppercaseHex);
			Assert.True(options.SmallHexNumbersInDecimal);
			Assert.True(options.AddLeadingZeroToHexNumbers);
			Assert.Equal(NumberBase.Hexadecimal, options.NumberBase);
			Assert.True(options.BranchLeadingZeroes);
			Assert.False(options.SignedImmediateOperands);
			Assert.True(options.SignedMemoryDisplacements);
			Assert.False(options.DisplacementLeadingZeroes);
			Assert.Equal(MemorySizeOptions.Default, options.MemorySizeOptions);
			Assert.False(options.RipRelativeAddresses);
			Assert.True(options.ShowBranchSize);
			Assert.True(options.UsePseudoOps);
			Assert.False(options.ShowSymbolAddress);
			Assert.False(options.PreferST0);
			Assert.Equal(CC_b.b, options.CC_b);
			Assert.Equal(CC_ae.ae, options.CC_ae);
			Assert.Equal(CC_e.e, options.CC_e);
			Assert.Equal(CC_ne.ne, options.CC_ne);
			Assert.Equal(CC_be.be, options.CC_be);
			Assert.Equal(CC_a.a, options.CC_a);
			Assert.Equal(CC_p.p, options.CC_p);
			Assert.Equal(CC_np.np, options.CC_np);
			Assert.Equal(CC_l.l, options.CC_l);
			Assert.Equal(CC_ge.ge, options.CC_ge);
			Assert.Equal(CC_le.le, options.CC_le);
			Assert.Equal(CC_g.g, options.CC_g);
			Assert.False(options.ShowUselessPrefixes);
			Assert.False(options.GasNakedRegisters);
			Assert.False(options.GasShowMnemonicSizeSuffix);
			Assert.False(options.GasSpaceAfterMemoryOperandComma);
			Assert.True(options.MasmAddDsPrefix32);
			Assert.True(options.MasmSymbolDisplInBrackets);
			Assert.True(options.MasmDisplInBrackets);
			Assert.False(options.NasmShowSignExtendedImmediateSize);
		}

		[Theory]
		[MemberData(nameof(FormatMnemonicOptions_Data))]
		void FormatMnemonicOptions(string hexBytes, Code code, int bitness, string formattedString, FormatMnemonicOptions options) {
			var decoder = Decoder.Create(bitness, new ByteArrayCodeReader(hexBytes));
			decoder.Decode(out var instruction);
			Assert.Equal(code, instruction.Code);
			var formatter = FormatterFactory.Create();
			var output = new StringOutput();
			formatter.FormatMnemonic(instruction, output, options);
			var actualFormattedString = output.ToStringAndReset();
#pragma warning disable xUnit2006 // Do not use invalid string equality check
			// Show the full string without ellipses by using Equal<string>() instead of Equal()
			Assert.Equal<string>(formattedString, actualFormattedString);
#pragma warning restore xUnit2006 // Do not use invalid string equality check
		}
		public static IEnumerable<object[]> FormatMnemonicOptions_Data {
			get {
				var filename = PathUtils.GetTestTextFilename("MnemonicOptions.txt", "Formatter", "Nasm");
				foreach (var tc in MnemonicOptionsTestsReader.ReadFile(filename))
					yield return new object[5] { tc.HexBytes, tc.Code, tc.Bitness, tc.FormattedString, tc.Flags };
			}
		}

		[Fact]
		void TestFormattingWithDefaultFormatterCtor() => FormatterTestUtils.TestFormatterDoesNotThrow(new NasmFormatter());

		[Fact]
		void TestFormattingWithDefaultFormatterCtor2() => FormatterTestUtils.TestFormatterDoesNotThrow(new NasmFormatter((ISymbolResolver)null));
	}
}
#endif
