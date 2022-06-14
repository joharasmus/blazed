// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System.Diagnostics;

namespace Blazed.Intel.FormatterInternal {
	readonly struct FormatterString {
		readonly string lower;
		readonly string upper;

		public int Length => lower.Length;

		public FormatterString(string lower) {
			Debug.Assert(lower.ToLowerInvariant() == lower);
			this.lower = lower;
			upper = string.Intern(lower.ToUpperInvariant());
		}

		public static FormatterString[] Create(string[] strings) {
			var res = new FormatterString[strings.Length];
			for (int i = 0; i < strings.Length; i++)
				res[i] = new FormatterString(strings[i]);
			return res;
		}

		public string Get(bool upper) =>
			upper ? this.upper : lower;
	}
}
