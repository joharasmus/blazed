// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if INTEL || MASM || NASM || FAST_FMT
using System;
using System.Collections.Generic;
using Blazed.Intel;

namespace UnitTests.Intel.FormatterTests {
	static class Utils {
#if INTEL || MASM || NASM
		public static IEnumerable<Formatter> GetAllFormatters() {
#if INTEL
			yield return new IntelFormatter();
#endif
#if MASM
			yield return new MasmFormatter();
#endif
#if NASM
			yield return new NasmFormatter();
#endif
		}
#endif

		public static string[] Filter(string[] strings, HashSet<int> removed) {
			if (removed.Count == 0)
				return strings;
			var res = new string[strings.Length - removed.Count];
			int w = 0;
			for (int i = 0; i < strings.Length; i++) {
				if (!removed.Contains(i))
					res[w++] = strings[i];
			}
			if (w != res.Length)
				throw new InvalidOperationException();
			return res;
		}
	}
}
#endif
