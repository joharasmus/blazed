// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if GAS
using System;
using Iced.Intel.FormatterInternal;

namespace Iced.Intel.GasFormatterInternal {
	static class MemorySizes {
		public static readonly FormatterString[] AllMemorySizes = GetMemorySizes();
		static FormatterString[] GetMemorySizes() {
			// GENERATOR-BEGIN: ConstData
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			var empty = new FormatterString("");
			var b1to2 = new FormatterString("1to2");
			var b1to4 = new FormatterString("1to4");
			var b1to8 = new FormatterString("1to8");
			var b1to16 = new FormatterString("1to16");
			var b1to32 = new FormatterString("1to32");
			// GENERATOR-END: ConstData

#if HAS_SPAN
			ReadOnlySpan<byte>
#else
			byte[]
#endif
			bcstToData = new byte[IcedConstants.MemorySizeEnumCount - (int)IcedConstants.FirstBroadcastMemorySize] {
				// GENERATOR-BEGIN: BcstTo
				// ⚠️This was generated by GENERATOR!🦹‍♂️
				0x01,
				0x01,
				0x01,
				0x02,
				0x01,
				0x03,
				0x03,
				0x02,
				0x02,
				0x01,
				0x01,
				0x01,
				0x03,
				0x02,
				0x01,
				0x02,
				0x01,
				0x01,
				0x02,
				0x02,
				0x04,
				0x04,
				0x03,
				0x03,
				0x02,
				0x02,
				0x02,
				0x04,
				0x03,
				0x02,
				0x03,
				0x02,
				0x02,
				0x03,
				0x03,
				0x05,
				0x05,
				0x04,
				0x04,
				0x03,
				0x03,
				0x03,
				0x05,
				0x04,
				0x03,
				0x04,
				0x04,
				0x03,
				0x03,
				0x04,
				// GENERATOR-END: BcstTo
			};

			var infos = new FormatterString[IcedConstants.MemorySizeEnumCount];
			for (int i = 0; i < infos.Length; i++) {
				FormatterString bcstTo;
				if (i < (int)IcedConstants.FirstBroadcastMemorySize)
					bcstTo = empty;
				else {
					bcstTo = bcstToData[i - (int)IcedConstants.FirstBroadcastMemorySize] switch {
						// GENERATOR-BEGIN: BroadcastToKindSwitch
						// ⚠️This was generated by GENERATOR!🦹‍♂️
						0x00 => empty,
						0x01 => b1to2,
						0x02 => b1to4,
						0x03 => b1to8,
						0x04 => b1to16,
						0x05 => b1to32,
						// GENERATOR-END: BroadcastToKindSwitch
						_ => throw new InvalidOperationException(),
					};
				}

				infos[i] = bcstTo;
			}

			return infos;
		}
	}
}
#endif
