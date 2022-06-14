// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using Blazed.Intel;
using UnitTests.Intel.DecoderTests;
using Xunit;

namespace UnitTests.Intel.FormatterTests {
	public sealed class MiscTests2 {
		[Fact]
		void Make_sure_all_Code_values_are_formatted() {
			var tested = new byte[BlazedConstants.CodeEnumCount];

			var allArgs = new (int bitness, bool isMisc)[] {
				(16, false),
				(32, false),
				(64, false),
				(16, true),
				(32, true),
				(64, true),
			};
			foreach (var args in allArgs) {
				var data = FormatterTestCases.GetInstructionInfos(args.bitness, args.isMisc);
				foreach (var info in data.infos)
					tested[(int)info.Code] = 1;
			}
#if ENCODER
			foreach (var info in NonDecodedInstructions.GetTests())
				tested[(int)info.instruction.Code] = 1;
#else
			foreach (var code in CodeValueTests.NonDecodedCodeValues1632)
				tested[(int)code] = 1;
			foreach (var code in CodeValueTests.NonDecodedCodeValues)
				tested[(int)code] = 1;
#endif

			var sb = new System.Text.StringBuilder();
			int missing = 0;
			var codeNames = ToEnumConverter.GetCodeNames();
			for (int i = 0; i < tested.Length; i++) {
				if (tested[i] != 1 && !CodeUtils.IsIgnored(codeNames[i])) {
					sb.Append(codeNames[i] + " ");
					missing++;
				}
			}
			Assert.Equal("Fmt: 0 ins ", $"Fmt: {missing} ins " + sb.ToString());
		}

		[Fact]
		void Instruction_ToString() {
			var decoder = Decoder.Create(64, new byte[] { 0x00, 0xCE }, DecoderOptions.None);
			var instr = decoder.Decode();
			string expected = "add dh,cl";
			var actual = instr.ToString();
			Assert.Equal(expected, actual);
		}
	}
}
