// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using Blazed.Intel;

namespace UnitTests.Intel.FormatterTests {
	static class Utils {
		public static IEnumerable<Formatter> GetAllFormatters() {
			yield return new Formatter();
		}

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
