// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if DECODER || ENCODER
using System;
using System.Collections.Generic;
using Iced.Intel;

namespace UnitTests.Intel {
	static partial class ToEnumConverter {
		public static bool TryTupleType(string value, out TupleType tupleType) => tupleTypeDict.TryGetValue(value, out tupleType);
		public static TupleType GetTupleType(string value) => TryTupleType(value, out var tupleType) ? tupleType : throw new InvalidOperationException($"Invalid TupleType value: {value}");

		static readonly Dictionary<string, TupleType> tupleTypeDict =
			// GENERATOR-BEGIN: TupleTypeHash
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			new Dictionary<string, TupleType>(19, StringComparer.Ordinal) {
				{ "N1", TupleType.N1 },
				{ "N2", TupleType.N2 },
				{ "N4", TupleType.N4 },
				{ "N8", TupleType.N8 },
				{ "N16", TupleType.N16 },
				{ "N32", TupleType.N32 },
				{ "N64", TupleType.N64 },
				{ "N8b4", TupleType.N8b4 },
				{ "N16b4", TupleType.N16b4 },
				{ "N32b4", TupleType.N32b4 },
				{ "N64b4", TupleType.N64b4 },
				{ "N16b8", TupleType.N16b8 },
				{ "N32b8", TupleType.N32b8 },
				{ "N64b8", TupleType.N64b8 },
				{ "N4b2", TupleType.N4b2 },
				{ "N8b2", TupleType.N8b2 },
				{ "N16b2", TupleType.N16b2 },
				{ "N32b2", TupleType.N32b2 },
				{ "N64b2", TupleType.N64b2 },
			};
			// GENERATOR-END: TupleTypeHash
	}
}
#endif