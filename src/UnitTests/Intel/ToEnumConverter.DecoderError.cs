// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using Blazed.Intel;

namespace UnitTests.Intel;

static partial class ToEnumConverter {
	public static bool TryDecoderError(string value, out DecoderError decoderError) => decoderErrorDict.TryGetValue(value, out decoderError);

	static readonly Dictionary<string, DecoderError> decoderErrorDict =
		// GENERATOR-BEGIN: DecoderErrorHash
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		new Dictionary<string, DecoderError>(3, StringComparer.Ordinal) {
			{ "None", DecoderError.None },
			{ "InvalidInstruction", DecoderError.InvalidInstruction },
			{ "NoMoreBytes", DecoderError.NoMoreBytes },
		};
		// GENERATOR-END: DecoderErrorHash
}
