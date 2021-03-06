// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System.Collections.Generic;
using Blazed.Intel;
using Xunit;

namespace UnitTests.Intel.FormatterTests {
	public sealed class OptionsTests2 : OptionsTests {
		[Theory]
		[MemberData(nameof(FormatCommon_Data))]
		void FormatCommon(int index, OptionsInstructionInfo info, string formattedString) => FormatBase(index, info, formattedString, FormatterFactory.Create_Options());
		public static IEnumerable<object[]> FormatCommon_Data => OptionsTestsUtils.GetFormatData_Common("OptionsResult.Common");

		[Theory]
		[MemberData(nameof(FormatAll_Data))]
		void FormatAll(int index, OptionsInstructionInfo info, string formattedString) => FormatBase(index, info, formattedString, FormatterFactory.Create_Options());
		public static IEnumerable<object[]> FormatAll_Data => OptionsTestsUtils.GetFormatData_All("OptionsResult");

		[Theory]
		[MemberData(nameof(Format2_Data))]
		void Format2(int index, OptionsInstructionInfo info, string formattedString) => FormatBase(index, info, formattedString, FormatterFactory.Create_Options());
		public static IEnumerable<object[]> Format2_Data => OptionsTestsUtils.GetFormatData("OptionsResult2", "Options2");

		[Fact]
		public void TestOptions() {
			var options = FormatterOptions.CreateFormatterOptions();
			TestOptionsBase(options);
		}
	}
}
