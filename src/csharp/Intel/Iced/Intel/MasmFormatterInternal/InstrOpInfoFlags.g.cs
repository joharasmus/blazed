// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

// ⚠️This file was generated by GENERATOR!🦹‍♂️

#nullable enable

#if MASM
using System;

namespace Iced.Intel.MasmFormatterInternal {
	[Flags]
	enum InstrOpInfoFlags : ushort {
		None = 0x00000000,
		MemSize_Mask = 0x00000007,
		MemSize_Sse = 0x00000000,
		MemSize_Mmx = 0x00000001,
		MemSize_Normal = 0x00000002,
		MemSize_Nothing = 0x00000003,
		MemSize_XmmwordPtr = 0x00000004,
		MemSize_DwordOrQword = 0x00000005,
		ShowNoMemSize_ForceSize = 0x00000008,
		ShowMinMemSize_ForceSize = 0x00000010,
		JccNotTaken = 0x00000020,
		JccTaken = 0x00000040,
		BndPrefix = 0x00000080,
		IgnoreIndexReg = 0x00000100,
		MnemonicIsDirective = 0x00000200,
	}
}
#endif
