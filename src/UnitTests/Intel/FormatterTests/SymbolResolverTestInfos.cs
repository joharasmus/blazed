// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if MASM || NASM
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Intel.FormatterTests {
	static class SymbolResolverTestInfos {
		public static readonly (SymbolResolverTestCase[] testCases, HashSet<int> ignored) AllInfos = GetTests();

		static (SymbolResolverTestCase[] testCases, HashSet<int> ignored) GetTests() {
			var filename = PathUtils.GetTestTextFilename("SymbolResolverTests.txt", "Formatter");
			var ignored = new HashSet<int>();
			return (SymbolResolverTestsReader.ReadFile(filename, ignored).ToArray(), ignored);
		}
	}
}
#endif
