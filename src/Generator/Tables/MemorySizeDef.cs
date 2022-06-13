// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using Generator.Enums;

namespace Generator.Tables {
	[Enum("BroadcastToKind")]
	enum BroadcastToKind {
		None,
		b1to2,
		b1to4,
		b1to8,
		b1to16,
		b1to32,
	}

	[Enum("MemoryKeywords", "MemoryKeywords")]
	enum MemoryKeywords {
		None,
		@byte,
		dword,
		far,
		fpuenv14,
		fpuenv28,
		fpustate108,
		fpustate94,
		oword,
		qword,
		tword,
		word,
		yword,
		zword,
		mem384,
	}

	[Flags]
	enum MemorySizeDefFlags : uint {
		None				= 0,
		Signed				= 0x00000001,
		Broadcast			= 0x00000002,
	}

	sealed class MemorySizeDef {
		public readonly EnumValue MemorySize;
		public readonly uint Size;
		public readonly EnumValue ElementType;
		public readonly uint ElementSize;
		public readonly MemorySizeDefFlags Flags;
		public bool IsSigned => (Flags & MemorySizeDefFlags.Signed) != 0;
		public readonly EnumValue BroadcastToKind;
		public readonly EnumValue Asm;

		public MemorySizeDef(
			EnumValue memorySize, uint size, 
			EnumValue elementType, uint elementSize, 
			MemorySizeDefFlags flags,
			EnumValue broadcastToKind, EnumValue asm) {
			MemorySize = memorySize;
			Size = size;
			ElementType = elementType;
			ElementSize = elementSize;
			Flags = flags;
			BroadcastToKind = broadcastToKind;
			Asm = asm;
		}
	}
}
