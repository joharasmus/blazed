// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System.Collections.Generic;
using Blazed.Intel;
using Xunit;

namespace UnitTests.Intel.FormatterTests {
	public sealed class RegisterTests2 : RegisterTests {
		[Theory]
		[MemberData(nameof(Format_Data))]
		void Format(Register register, string formattedString) => FormatBase(register, formattedString, FormatterFactory.Create_Registers());
		public static IEnumerable<object[]> Format_Data => GetFormatData("RegisterTests2");
	}
}
