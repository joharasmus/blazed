// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if NASM
using System;
using System.Collections.Generic;
using Blazed.Intel;

namespace UnitTests.Intel;

static partial class ToEnumConverter {
	public static bool TryNumberBase(string value, out NumberBase numberBase) => numberBaseDict.TryGetValue(value, out numberBase);
	public static NumberBase GetNumberBase(string value) => TryNumberBase(value, out var numberBase) ? numberBase : throw new InvalidOperationException($"Invalid NumberBase value: {value}");
	public static int NumberBaseCount => numberBaseDict.Count;
	public static IEnumerable<NumberBase> GetNumberBaseValues() => numberBaseDict.Values;

	static readonly Dictionary<string, NumberBase> numberBaseDict =
		// GENERATOR-BEGIN: NumberBaseHash
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		new Dictionary<string, NumberBase>(4, StringComparer.Ordinal) {
			{ "Hexadecimal", NumberBase.Hexadecimal },
			{ "Decimal", NumberBase.Decimal },
			{ "Octal", NumberBase.Octal },
			{ "Binary", NumberBase.Binary },
		};
		// GENERATOR-END: NumberBaseHash
}
#endif
