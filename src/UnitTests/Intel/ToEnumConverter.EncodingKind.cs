// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if DECODER || ENCODER || INSTR_INFO
using System;
using System.Collections.Generic;
using Blazed.Intel;

namespace UnitTests.Intel;

static partial class ToEnumConverter {
	public static bool TryEncodingKind(string value, out EncodingKind encodingKind) => encodingKindDict.TryGetValue(value, out encodingKind);
	public static EncodingKind GetEncodingKind(string value) => TryEncodingKind(value, out var encodingKind) ? encodingKind : throw new InvalidOperationException($"Invalid EncodingKind value: {value}");

	static readonly Dictionary<string, EncodingKind> encodingKindDict =
		// GENERATOR-BEGIN: EncodingKindHash
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		new Dictionary<string, EncodingKind>(6, StringComparer.Ordinal) {
			{ "Legacy", EncodingKind.Legacy },
			{ "VEX", EncodingKind.VEX },
			{ "EVEX", EncodingKind.EVEX },
			{ "XOP", EncodingKind.XOP },
			{ "D3NOW", EncodingKind.D3NOW },
			{ "MVEX", EncodingKind.MVEX },
		};
		// GENERATOR-END: EncodingKindHash
}
#endif