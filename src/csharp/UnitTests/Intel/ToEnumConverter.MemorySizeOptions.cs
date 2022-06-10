// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if GAS || INTEL || MASM || NASM || FAST_FMT
using System;
using System.Collections.Generic;
using Iced.Intel;

namespace UnitTests.Intel {
	static partial class ToEnumConverter {
		public static bool TryMemorySizeOptions(string value, out MemorySizeOptions memorySizeOptions) => memorySizeOptionsDict.TryGetValue(value, out memorySizeOptions);
		public static MemorySizeOptions GetMemorySizeOptions(string value) => TryMemorySizeOptions(value, out var memorySizeOptions) ? memorySizeOptions : throw new InvalidOperationException($"Invalid MemorySizeOptions value: {value}");
		public static IEnumerable<MemorySizeOptions> GetMemorySizeOptionsValues() => memorySizeOptionsDict.Values;

		static readonly Dictionary<string, MemorySizeOptions> memorySizeOptionsDict =
			// GENERATOR-BEGIN: MemorySizeOptionsHash
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			new Dictionary<string, MemorySizeOptions>(4, StringComparer.Ordinal) {
				{ "Default", MemorySizeOptions.Default },
				{ "Always", MemorySizeOptions.Always },
				{ "Minimal", MemorySizeOptions.Minimal },
				{ "Never", MemorySizeOptions.Never },
			};
			// GENERATOR-END: MemorySizeOptionsHash
	}
}
#endif
