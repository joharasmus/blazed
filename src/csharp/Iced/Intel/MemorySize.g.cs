// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

// ⚠️This file was generated by GENERATOR!🦹‍♂️

#nullable enable

namespace Iced.Intel {
	/// <summary>Size of a memory reference</summary>
	public enum MemorySize {
		/// <summary>Unknown size or the instruction doesn&apos;t reference any memory (eg. <c>LEA</c>)</summary>
		Unknown = 0,
		/// <summary>Memory location contains a <see cref="byte"/></summary>
		UInt8 = 1,
		/// <summary>Memory location contains a <see cref="ushort"/></summary>
		UInt16 = 2,
		/// <summary>Memory location contains a <see cref="uint"/></summary>
		UInt32 = 3,
		/// <summary>Memory location contains a <c>uint52</c></summary>
		UInt52 = 4,
		/// <summary>Memory location contains a <see cref="ulong"/></summary>
		UInt64 = 5,
		/// <summary>Memory location contains a <c>uint128</c></summary>
		UInt128 = 6,
		/// <summary>Memory location contains a <c>uint256</c></summary>
		UInt256 = 7,
		/// <summary>Memory location contains a <c>uint512</c></summary>
		UInt512 = 8,
		/// <summary>Memory location contains a <see cref="sbyte"/></summary>
		Int8 = 9,
		/// <summary>Memory location contains a <see cref="short"/></summary>
		Int16 = 10,
		/// <summary>Memory location contains a <see cref="int"/></summary>
		Int32 = 11,
		/// <summary>Memory location contains a <see cref="long"/></summary>
		Int64 = 12,
		/// <summary>Memory location contains a <c>int128</c></summary>
		Int128 = 13,
		/// <summary>Memory location contains a <c>int256</c></summary>
		Int256 = 14,
		/// <summary>Memory location contains a <c>int512</c></summary>
		Int512 = 15,
		/// <summary>Memory location contains a seg:ptr pair, <see cref="ushort"/> (offset) + <see cref="ushort"/> (segment/selector)</summary>
		SegPtr16 = 16,
		/// <summary>Memory location contains a seg:ptr pair, <see cref="uint"/> (offset) + <see cref="ushort"/> (segment/selector)</summary>
		SegPtr32 = 17,
		/// <summary>Memory location contains a seg:ptr pair, <see cref="ulong"/> (offset) + <see cref="ushort"/> (segment/selector)</summary>
		SegPtr64 = 18,
		/// <summary>Memory location contains a 16-bit offset (<c>JMP/CALL WORD PTR [mem]</c>)</summary>
		WordOffset = 19,
		/// <summary>Memory location contains a 32-bit offset (<c>JMP/CALL DWORD PTR [mem]</c>)</summary>
		DwordOffset = 20,
		/// <summary>Memory location contains a 64-bit offset (<c>JMP/CALL QWORD PTR [mem]</c>)</summary>
		QwordOffset = 21,
		/// <summary>Memory location contains two <see cref="ushort"/>s (16-bit <c>BOUND</c>)</summary>
		Bound16_WordWord = 22,
		/// <summary>Memory location contains two <see cref="uint"/>s (32-bit <c>BOUND</c>)</summary>
		Bound32_DwordDword = 23,
		/// <summary>32-bit <c>BNDMOV</c>, 2 x <see cref="uint"/></summary>
		Bnd32 = 24,
		/// <summary>64-bit <c>BNDMOV</c>, 2 x <see cref="ulong"/></summary>
		Bnd64 = 25,
		/// <summary>Memory location contains a 16-bit limit and a 32-bit address (eg. <c>LGDTW</c>, <c>LGDTD</c>)</summary>
		Fword6 = 26,
		/// <summary>Memory location contains a 16-bit limit and a 64-bit address (eg. <c>LGDTQ</c>)</summary>
		Fword10 = 27,
		/// <summary>Memory location contains a <c>float16</c></summary>
		Float16 = 28,
		/// <summary>Memory location contains a <see cref="float"/></summary>
		Float32 = 29,
		/// <summary>Memory location contains a <see cref="double"/></summary>
		Float64 = 30,
		/// <summary>Memory location contains a <c>float80</c></summary>
		Float80 = 31,
		/// <summary>Memory location contains a <c>float128</c></summary>
		Float128 = 32,
		/// <summary>Memory location contains a <c>bfloat16</c></summary>
		BFloat16 = 33,
		/// <summary>Memory location contains a 14-byte FPU environment (16-bit <c>FLDENV</c>/<c>FSTENV</c>)</summary>
		FpuEnv14 = 34,
		/// <summary>Memory location contains a 28-byte FPU environment (32/64-bit <c>FLDENV</c>/<c>FSTENV</c>)</summary>
		FpuEnv28 = 35,
		/// <summary>Memory location contains a 94-byte FPU environment (16-bit <c>FSAVE</c>/<c>FRSTOR</c>)</summary>
		FpuState94 = 36,
		/// <summary>Memory location contains a 108-byte FPU environment (32/64-bit <c>FSAVE</c>/<c>FRSTOR</c>)</summary>
		FpuState108 = 37,
		/// <summary>Memory location contains 512-bytes of <c>FXSAVE</c>/<c>FXRSTOR</c> data</summary>
		Fxsave_512Byte = 38,
		/// <summary>Memory location contains 512-bytes of <c>FXSAVE64</c>/<c>FXRSTOR64</c> data</summary>
		Fxsave64_512Byte = 39,
		/// <summary>32-bit <c>XSAVE</c> area</summary>
		Xsave = 40,
		/// <summary>64-bit <c>XSAVE</c> area</summary>
		Xsave64 = 41,
		/// <summary>Memory location contains a 10-byte <c>bcd</c> value (<c>FBLD</c>/<c>FBSTP</c>)</summary>
		Bcd = 42,
		/// <summary>64-bit location: TILECFG (<c>LDTILECFG</c>/<c>STTILECFG</c>)</summary>
		Tilecfg = 43,
		/// <summary>Tile data</summary>
		Tile = 44,
		/// <summary>80-bit segment descriptor and selector: 0-7 = descriptor, 8-9 = selector</summary>
		SegmentDescSelector = 45,
		/// <summary>384-bit AES 128 handle (Key Locker)</summary>
		KLHandleAes128 = 46,
		/// <summary>512-bit AES 256 handle (Key Locker)</summary>
		KLHandleAes256 = 47,
		/// <summary>16-bit location: 2 x <see cref="byte"/></summary>
		Packed16_UInt8 = 48,
		/// <summary>16-bit location: 2 x <see cref="sbyte"/></summary>
		Packed16_Int8 = 49,
		/// <summary>32-bit location: 4 x <see cref="byte"/></summary>
		Packed32_UInt8 = 50,
		/// <summary>32-bit location: 4 x <see cref="sbyte"/></summary>
		Packed32_Int8 = 51,
		/// <summary>32-bit location: 2 x <see cref="ushort"/></summary>
		Packed32_UInt16 = 52,
		/// <summary>32-bit location: 2 x <see cref="short"/></summary>
		Packed32_Int16 = 53,
		/// <summary>32-bit location: 2 x <c>float16</c></summary>
		Packed32_Float16 = 54,
		/// <summary>32-bit location: 2 x <c>bfloat16</c></summary>
		Packed32_BFloat16 = 55,
		/// <summary>64-bit location: 8 x <see cref="byte"/></summary>
		Packed64_UInt8 = 56,
		/// <summary>64-bit location: 8 x <see cref="sbyte"/></summary>
		Packed64_Int8 = 57,
		/// <summary>64-bit location: 4 x <see cref="ushort"/></summary>
		Packed64_UInt16 = 58,
		/// <summary>64-bit location: 4 x <see cref="short"/></summary>
		Packed64_Int16 = 59,
		/// <summary>64-bit location: 2 x <see cref="uint"/></summary>
		Packed64_UInt32 = 60,
		/// <summary>64-bit location: 2 x <see cref="int"/></summary>
		Packed64_Int32 = 61,
		/// <summary>64-bit location: 4 x <c>float16</c></summary>
		Packed64_Float16 = 62,
		/// <summary>64-bit location: 2 x <see cref="float"/></summary>
		Packed64_Float32 = 63,
		/// <summary>128-bit location: 16 x <see cref="byte"/></summary>
		Packed128_UInt8 = 64,
		/// <summary>128-bit location: 16 x <see cref="sbyte"/></summary>
		Packed128_Int8 = 65,
		/// <summary>128-bit location: 8 x <see cref="ushort"/></summary>
		Packed128_UInt16 = 66,
		/// <summary>128-bit location: 8 x <see cref="short"/></summary>
		Packed128_Int16 = 67,
		/// <summary>128-bit location: 4 x <see cref="uint"/></summary>
		Packed128_UInt32 = 68,
		/// <summary>128-bit location: 4 x <see cref="int"/></summary>
		Packed128_Int32 = 69,
		/// <summary>128-bit location: 2 x <c>uint52</c></summary>
		Packed128_UInt52 = 70,
		/// <summary>128-bit location: 2 x <see cref="ulong"/></summary>
		Packed128_UInt64 = 71,
		/// <summary>128-bit location: 2 x <see cref="long"/></summary>
		Packed128_Int64 = 72,
		/// <summary>128-bit location: 8 x <c>float16</c></summary>
		Packed128_Float16 = 73,
		/// <summary>128-bit location: 4 x <see cref="float"/></summary>
		Packed128_Float32 = 74,
		/// <summary>128-bit location: 2 x <see cref="double"/></summary>
		Packed128_Float64 = 75,
		/// <summary>128-bit location: 4 x (2 x <c>float16</c>)</summary>
		Packed128_2xFloat16 = 76,
		/// <summary>128-bit location: 4 x (2 x <c>bfloat16</c>)</summary>
		Packed128_2xBFloat16 = 77,
		/// <summary>256-bit location: 32 x <see cref="byte"/></summary>
		Packed256_UInt8 = 78,
		/// <summary>256-bit location: 32 x <see cref="sbyte"/></summary>
		Packed256_Int8 = 79,
		/// <summary>256-bit location: 16 x <see cref="ushort"/></summary>
		Packed256_UInt16 = 80,
		/// <summary>256-bit location: 16 x <see cref="short"/></summary>
		Packed256_Int16 = 81,
		/// <summary>256-bit location: 8 x <see cref="uint"/></summary>
		Packed256_UInt32 = 82,
		/// <summary>256-bit location: 8 x <see cref="int"/></summary>
		Packed256_Int32 = 83,
		/// <summary>256-bit location: 4 x <c>uint52</c></summary>
		Packed256_UInt52 = 84,
		/// <summary>256-bit location: 4 x <see cref="ulong"/></summary>
		Packed256_UInt64 = 85,
		/// <summary>256-bit location: 4 x <see cref="long"/></summary>
		Packed256_Int64 = 86,
		/// <summary>256-bit location: 2 x <c>uint128</c></summary>
		Packed256_UInt128 = 87,
		/// <summary>256-bit location: 2 x <c>int128</c></summary>
		Packed256_Int128 = 88,
		/// <summary>256-bit location: 16 x <c>float16</c></summary>
		Packed256_Float16 = 89,
		/// <summary>256-bit location: 8 x <see cref="float"/></summary>
		Packed256_Float32 = 90,
		/// <summary>256-bit location: 4 x <see cref="double"/></summary>
		Packed256_Float64 = 91,
		/// <summary>256-bit location: 2 x <c>float128</c></summary>
		Packed256_Float128 = 92,
		/// <summary>256-bit location: 8 x (2 x <c>float16</c>)</summary>
		Packed256_2xFloat16 = 93,
		/// <summary>256-bit location: 8 x (2 x <c>bfloat16</c>)</summary>
		Packed256_2xBFloat16 = 94,
		/// <summary>512-bit location: 64 x <see cref="byte"/></summary>
		Packed512_UInt8 = 95,
		/// <summary>512-bit location: 64 x <see cref="sbyte"/></summary>
		Packed512_Int8 = 96,
		/// <summary>512-bit location: 32 x <see cref="ushort"/></summary>
		Packed512_UInt16 = 97,
		/// <summary>512-bit location: 32 x <see cref="short"/></summary>
		Packed512_Int16 = 98,
		/// <summary>512-bit location: 16 x <see cref="uint"/></summary>
		Packed512_UInt32 = 99,
		/// <summary>512-bit location: 16 x <see cref="int"/></summary>
		Packed512_Int32 = 100,
		/// <summary>512-bit location: 8 x <c>uint52</c></summary>
		Packed512_UInt52 = 101,
		/// <summary>512-bit location: 8 x <see cref="ulong"/></summary>
		Packed512_UInt64 = 102,
		/// <summary>512-bit location: 8 x <see cref="long"/></summary>
		Packed512_Int64 = 103,
		/// <summary>256-bit location: 4 x <c>uint128</c></summary>
		Packed512_UInt128 = 104,
		/// <summary>512-bit location: 32 x <c>float16</c></summary>
		Packed512_Float16 = 105,
		/// <summary>512-bit location: 16 x <see cref="float"/></summary>
		Packed512_Float32 = 106,
		/// <summary>512-bit location: 8 x <see cref="double"/></summary>
		Packed512_Float64 = 107,
		/// <summary>512-bit location: 16 x (2 x <c>float16</c>)</summary>
		Packed512_2xFloat16 = 108,
		/// <summary>512-bit location: 16 x (2 x <c>bfloat16</c>)</summary>
		Packed512_2xBFloat16 = 109,
		/// <summary>Broadcast <c>float16</c> to 32-bits</summary>
		Broadcast32_Float16 = 110,
		/// <summary>Broadcast <see cref="uint"/> to 64-bits</summary>
		Broadcast64_UInt32 = 111,
		/// <summary>Broadcast <see cref="int"/> to 64-bits</summary>
		Broadcast64_Int32 = 112,
		/// <summary>Broadcast <c>float16</c> to 64-bits</summary>
		Broadcast64_Float16 = 113,
		/// <summary>Broadcast <see cref="float"/> to 64-bits</summary>
		Broadcast64_Float32 = 114,
		/// <summary>Broadcast <see cref="short"/> to 128-bits</summary>
		Broadcast128_Int16 = 115,
		/// <summary>Broadcast <see cref="ushort"/> to 128-bits</summary>
		Broadcast128_UInt16 = 116,
		/// <summary>Broadcast <see cref="uint"/> to 128-bits</summary>
		Broadcast128_UInt32 = 117,
		/// <summary>Broadcast <see cref="int"/> to 128-bits</summary>
		Broadcast128_Int32 = 118,
		/// <summary>Broadcast <c>uint52</c> to 128-bits</summary>
		Broadcast128_UInt52 = 119,
		/// <summary>Broadcast <see cref="ulong"/> to 128-bits</summary>
		Broadcast128_UInt64 = 120,
		/// <summary>Broadcast <see cref="long"/> to 128-bits</summary>
		Broadcast128_Int64 = 121,
		/// <summary>Broadcast <c>float16</c> to 128-bits</summary>
		Broadcast128_Float16 = 122,
		/// <summary>Broadcast <see cref="float"/> to 128-bits</summary>
		Broadcast128_Float32 = 123,
		/// <summary>Broadcast <see cref="double"/> to 128-bits</summary>
		Broadcast128_Float64 = 124,
		/// <summary>Broadcast 2 x <see cref="short"/> to 128-bits</summary>
		Broadcast128_2xInt16 = 125,
		/// <summary>Broadcast 2 x <see cref="int"/> to 128-bits</summary>
		Broadcast128_2xInt32 = 126,
		/// <summary>Broadcast 2 x <see cref="uint"/> to 128-bits</summary>
		Broadcast128_2xUInt32 = 127,
		/// <summary>Broadcast 2 x <c>float16</c> to 128-bits</summary>
		Broadcast128_2xFloat16 = 128,
		/// <summary>Broadcast 2 x <c>bfloat16</c> to 128-bits</summary>
		Broadcast128_2xBFloat16 = 129,
		/// <summary>Broadcast <see cref="short"/> to 256-bits</summary>
		Broadcast256_Int16 = 130,
		/// <summary>Broadcast <see cref="ushort"/> to 256-bits</summary>
		Broadcast256_UInt16 = 131,
		/// <summary>Broadcast <see cref="uint"/> to 256-bits</summary>
		Broadcast256_UInt32 = 132,
		/// <summary>Broadcast <see cref="int"/> to 256-bits</summary>
		Broadcast256_Int32 = 133,
		/// <summary>Broadcast <c>uint52</c> to 256-bits</summary>
		Broadcast256_UInt52 = 134,
		/// <summary>Broadcast <see cref="ulong"/> to 256-bits</summary>
		Broadcast256_UInt64 = 135,
		/// <summary>Broadcast <see cref="long"/> to 256-bits</summary>
		Broadcast256_Int64 = 136,
		/// <summary>Broadcast <c>float16</c> to 256-bits</summary>
		Broadcast256_Float16 = 137,
		/// <summary>Broadcast <see cref="float"/> to 256-bits</summary>
		Broadcast256_Float32 = 138,
		/// <summary>Broadcast <see cref="double"/> to 256-bits</summary>
		Broadcast256_Float64 = 139,
		/// <summary>Broadcast 2 x <see cref="short"/> to 256-bits</summary>
		Broadcast256_2xInt16 = 140,
		/// <summary>Broadcast 2 x <see cref="int"/> to 256-bits</summary>
		Broadcast256_2xInt32 = 141,
		/// <summary>Broadcast 2 x <see cref="uint"/> to 256-bits</summary>
		Broadcast256_2xUInt32 = 142,
		/// <summary>Broadcast 2 x <c>float16</c> to 256-bits</summary>
		Broadcast256_2xFloat16 = 143,
		/// <summary>Broadcast 2 x <c>bfloat16</c> to 256-bits</summary>
		Broadcast256_2xBFloat16 = 144,
		/// <summary>Broadcast <see cref="short"/> to 512-bits</summary>
		Broadcast512_Int16 = 145,
		/// <summary>Broadcast <see cref="ushort"/> to 512-bits</summary>
		Broadcast512_UInt16 = 146,
		/// <summary>Broadcast <see cref="uint"/> to 512-bits</summary>
		Broadcast512_UInt32 = 147,
		/// <summary>Broadcast <see cref="int"/> to 512-bits</summary>
		Broadcast512_Int32 = 148,
		/// <summary>Broadcast <c>uint52</c> to 512-bits</summary>
		Broadcast512_UInt52 = 149,
		/// <summary>Broadcast <see cref="ulong"/> to 512-bits</summary>
		Broadcast512_UInt64 = 150,
		/// <summary>Broadcast <see cref="long"/> to 512-bits</summary>
		Broadcast512_Int64 = 151,
		/// <summary>Broadcast <c>float16</c> to 512-bits</summary>
		Broadcast512_Float16 = 152,
		/// <summary>Broadcast <see cref="float"/> to 512-bits</summary>
		Broadcast512_Float32 = 153,
		/// <summary>Broadcast <see cref="double"/> to 512-bits</summary>
		Broadcast512_Float64 = 154,
		/// <summary>Broadcast 2 x <c>float16</c> to 512-bits</summary>
		Broadcast512_2xFloat16 = 155,
		/// <summary>Broadcast 2 x <see cref="short"/> to 512-bits</summary>
		Broadcast512_2xInt16 = 156,
		/// <summary>Broadcast 2 x <see cref="uint"/> to 512-bits</summary>
		Broadcast512_2xUInt32 = 157,
		/// <summary>Broadcast 2 x <see cref="int"/> to 512-bits</summary>
		Broadcast512_2xInt32 = 158,
		/// <summary>Broadcast 2 x <c>bfloat16</c> to 512-bits</summary>
		Broadcast512_2xBFloat16 = 159,
	}
}