// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using Xunit;

namespace UnitTests.Intel.FormatterTests {
	public sealed class OpIndexTests2 : OpIndexTests {
		[Fact]
		void Test() => TestBase(FormatterFactory.Create());
	}
}
