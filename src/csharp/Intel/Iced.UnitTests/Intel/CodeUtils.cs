// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;

namespace Iced.UnitTests.Intel {
	static class CodeUtils {
		// GENERATOR-BEGIN: IgnoredCode
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		static readonly HashSet<string> ignored = new HashSet<string>(0, StringComparer.Ordinal) {
		};
		// GENERATOR-END: IgnoredCode

		public static bool IsIgnored(string name) {
#if NO_VEX
			if (name.StartsWith("VEX_"))
				return true;
#endif
#if NO_EVEX
			if (name.StartsWith("EVEX_"))
				return true;
#endif
#if NO_XOP
			if (name.StartsWith("XOP_"))
				return true;
#endif
#if NO_D3NOW
			if (name.StartsWith("D3NOW_"))
				return true;
#endif
#if !MVEX
			if (name.StartsWith("MVEX_"))
				return true;
#endif

			return ignored.Contains(name);
		}
	}
}
