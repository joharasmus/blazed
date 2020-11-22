/*
Copyright (C) 2018-2019 de4dot@gmail.com

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

#if INSTR_INFO || ENCODER
using System.Diagnostics;

namespace Iced.Intel {
	public static partial class MemorySizeExtensions {
		internal static readonly MemorySizeInfo[] MemorySizeInfos = GetMemorySizeInfos();
		static MemorySizeInfo[] GetMemorySizeInfos() {
#if HAS_SPAN
			System.ReadOnlySpan<byte>
#else
			var
#endif
			data = new byte[IcedConstants.MemorySizeEnumCount * 3] {
				// GENERATOR-BEGIN: MemorySizeInfoTable
				// ⚠️This was generated by GENERATOR!🦹‍♂️
				0x00, 0x00, 0x00,
				0x01, 0x21, 0x00,
				0x02, 0x42, 0x00,
				0x03, 0x63, 0x00,
				0x04, 0xA5, 0x00,
				0x05, 0xA5, 0x00,
				0x06, 0x08, 0x01,
				0x07, 0x4A, 0x01,
				0x08, 0x8C, 0x01,
				0x09, 0x21, 0x80,
				0x0A, 0x42, 0x80,
				0x0B, 0x63, 0x80,
				0x0C, 0xA5, 0x80,
				0x0D, 0x08, 0x81,
				0x0E, 0x4A, 0x81,
				0x0F, 0x8C, 0x81,
				0x10, 0x63, 0x00,
				0x11, 0x84, 0x00,
				0x12, 0xC6, 0x00,
				0x13, 0x42, 0x00,
				0x14, 0x63, 0x00,
				0x15, 0xA5, 0x00,
				0x02, 0x43, 0x00,
				0x03, 0x65, 0x00,
				0x18, 0xA5, 0x00,
				0x19, 0x08, 0x01,
				0x1A, 0x84, 0x00,
				0x1B, 0xC6, 0x00,
				0x1C, 0x42, 0x80,
				0x1D, 0x63, 0x80,
				0x1E, 0xA5, 0x80,
				0x1F, 0xC6, 0x80,
				0x20, 0x08, 0x81,
				0x21, 0x42, 0x80,
				0x22, 0xE7, 0x00,
				0x23, 0x29, 0x01,
				0x24, 0xAD, 0x01,
				0x25, 0xCE, 0x01,
				0x26, 0xEF, 0x01,
				0x27, 0xEF, 0x01,
				0x28, 0x00, 0x00,
				0x29, 0x00, 0x00,
				0x2A, 0xC6, 0x80,
				0x2B, 0x8C, 0x01,
				0x2C, 0x00, 0x00,
				0x2D, 0xC6, 0x00,
				0x2E, 0x6B, 0x01,
				0x2F, 0x8C, 0x01,
				0x01, 0x22, 0x00,
				0x09, 0x22, 0x80,
				0x01, 0x23, 0x00,
				0x09, 0x23, 0x80,
				0x02, 0x43, 0x00,
				0x0A, 0x43, 0x80,
				0x21, 0x43, 0x80,
				0x01, 0x25, 0x00,
				0x09, 0x25, 0x80,
				0x02, 0x45, 0x00,
				0x0A, 0x45, 0x80,
				0x03, 0x65, 0x00,
				0x0B, 0x65, 0x80,
				0x1C, 0x45, 0x80,
				0x1D, 0x65, 0x80,
				0x01, 0x28, 0x00,
				0x09, 0x28, 0x80,
				0x02, 0x48, 0x00,
				0x0A, 0x48, 0x80,
				0x03, 0x68, 0x00,
				0x0B, 0x68, 0x80,
				0x04, 0xA8, 0x00,
				0x05, 0xA8, 0x00,
				0x0C, 0xA8, 0x80,
				0x1C, 0x48, 0x80,
				0x1D, 0x68, 0x80,
				0x1E, 0xA8, 0x80,
				0x36, 0x68, 0x80,
				0x01, 0x2A, 0x00,
				0x09, 0x2A, 0x80,
				0x02, 0x4A, 0x00,
				0x0A, 0x4A, 0x80,
				0x03, 0x6A, 0x00,
				0x0B, 0x6A, 0x80,
				0x04, 0xAA, 0x00,
				0x05, 0xAA, 0x00,
				0x0C, 0xAA, 0x80,
				0x06, 0x0A, 0x01,
				0x0D, 0x0A, 0x81,
				0x1C, 0x4A, 0x80,
				0x1D, 0x6A, 0x80,
				0x1E, 0xAA, 0x80,
				0x20, 0x0A, 0x81,
				0x36, 0x6A, 0x80,
				0x01, 0x2C, 0x00,
				0x09, 0x2C, 0x80,
				0x02, 0x4C, 0x00,
				0x0A, 0x4C, 0x80,
				0x03, 0x6C, 0x00,
				0x0B, 0x6C, 0x80,
				0x04, 0xAC, 0x00,
				0x05, 0xAC, 0x00,
				0x0C, 0xAC, 0x80,
				0x06, 0x0C, 0x01,
				0x1D, 0x6C, 0x80,
				0x1E, 0xAC, 0x80,
				0x36, 0x6C, 0x80,
				0x03, 0x63, 0x00,
				0x0B, 0x63, 0x80,
				0x1D, 0x63, 0x80,
				0x03, 0x63, 0x00,
				0x0B, 0x63, 0x80,
				0x04, 0xA5, 0x00,
				0x05, 0xA5, 0x00,
				0x0C, 0xA5, 0x80,
				0x1D, 0x63, 0x80,
				0x1E, 0xA5, 0x80,
				0x03, 0x63, 0x00,
				0x0B, 0x63, 0x80,
				0x04, 0xA5, 0x00,
				0x05, 0xA5, 0x00,
				0x0C, 0xA5, 0x80,
				0x1D, 0x63, 0x80,
				0x1E, 0xA5, 0x80,
				0x03, 0x63, 0x00,
				0x0B, 0x63, 0x80,
				0x04, 0xA5, 0x00,
				0x05, 0xA5, 0x00,
				0x0C, 0xA5, 0x80,
				0x1D, 0x63, 0x80,
				0x1E, 0xA5, 0x80,
				0x0A, 0x43, 0x80,
				0x0A, 0x43, 0x80,
				0x0A, 0x43, 0x80,
				0x03, 0x65, 0x00,
				0x03, 0x65, 0x00,
				0x03, 0x65, 0x00,
				0x0B, 0x65, 0x80,
				0x0B, 0x65, 0x80,
				0x0B, 0x65, 0x80,
				0x21, 0x43, 0x80,
				0x21, 0x43, 0x80,
				0x21, 0x43, 0x80,
				// GENERATOR-END: MemorySizeInfoTable
			};

			// GENERATOR-BEGIN: ConstData
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			const ushort IsSigned = 32768;
			const uint SizeMask = 31;
			const int SizeShift = 0;
			const int ElemSizeShift = 5;
			var sizes = new ushort[] {
				0,
				1,
				2,
				4,
				6,
				8,
				10,
				14,
				16,
				28,
				32,
				48,
				64,
				94,
				108,
				512,
			};
			// GENERATOR-END: ConstData

			var infos = new MemorySizeInfo[IcedConstants.MemorySizeEnumCount];
			for (int i = 0, j = 0; i < infos.Length; i++, j += 3) {
				var elementType = (MemorySize)data[j];
				uint value = (uint)(data[j + 2] << 8) | data[j + 1];
				var size = sizes[(int)((value >> SizeShift) & SizeMask)];
				var elementSize = sizes[(int)((value >> ElemSizeShift) & SizeMask)];
				infos[i] = new MemorySizeInfo((MemorySize)i, size, elementSize, elementType, (value & IsSigned) != 0, i >= (int)IcedConstants.FirstBroadcastMemorySize);
			}
			return infos;
		}

		/// <summary>
		/// Gets the memory size info
		/// </summary>
		/// <param name="memorySize">Memory size</param>
		/// <returns></returns>
		public static MemorySizeInfo GetInfo(this MemorySize memorySize) {
			var infos = MemorySizeInfos;
			if ((uint)memorySize >= (uint)infos.Length)
				ThrowHelper.ThrowArgumentOutOfRangeException_memorySize();
			return infos[(int)memorySize];
		}

		/// <summary>
		/// Gets the size in bytes of the memory location or 0 if it's not accessed by the instruction or unknown or variable sized
		/// </summary>
		/// <param name="memorySize">Memory size</param>
		/// <returns></returns>
		public static int GetSize(this MemorySize memorySize) => memorySize.GetInfo().Size;

		/// <summary>
		/// Gets the size in bytes of the packed element. If it's not a packed data type, it's equal to <see cref="GetSize(MemorySize)"/>.
		/// </summary>
		/// <param name="memorySize">Memory size</param>
		/// <returns></returns>
		public static int GetElementSize(this MemorySize memorySize) => memorySize.GetInfo().ElementSize;

		/// <summary>
		/// Gets the element type if it's packed data or <paramref name="memorySize"/> if it's not packed data
		/// </summary>
		/// <param name="memorySize">Memory size</param>
		/// <returns></returns>
		public static MemorySize GetElementType(this MemorySize memorySize) => memorySize.GetInfo().ElementType;

		/// <summary>
		/// Gets the element type info if it's packed data or <paramref name="memorySize"/> if it's not packed data
		/// </summary>
		/// <param name="memorySize">Memory size</param>
		/// <returns></returns>
		public static MemorySizeInfo GetElementTypeInfo(this MemorySize memorySize) => memorySize.GetInfo().ElementType.GetInfo();

		/// <summary>
		/// <see langword="true"/> if it's signed data (signed integer or a floating point value)
		/// </summary>
		/// <param name="memorySize">Memory size</param>
		/// <returns></returns>
		public static bool IsSigned(this MemorySize memorySize) => memorySize.GetInfo().IsSigned;

		/// <summary>
		/// <see langword="true"/> if this is a packed data type, eg. <see cref="MemorySize.Packed128_Float32"/>
		/// </summary>
		/// <param name="memorySize">Memory size</param>
		/// <returns></returns>
		public static bool IsPacked(this MemorySize memorySize) => memorySize.GetInfo().IsPacked;

		/// <summary>
		/// Gets the number of elements in the packed data type or 1 if it's not packed data (<see cref="IsPacked"/>)
		/// </summary>
		/// <param name="memorySize">Memory size</param>
		/// <returns></returns>
		public static int GetElementCount(this MemorySize memorySize) => memorySize.GetInfo().ElementCount;
	}

	/// <summary>
	/// <see cref="Intel.MemorySize"/> information
	/// </summary>
	public readonly struct MemorySizeInfo {
		// 8 bytes in size
		readonly ushort size;
		readonly ushort elementSize;
		readonly byte memorySize;
		readonly byte elementType;
		// Use flags if more booleans are needed
		readonly bool isSigned;
		readonly bool isBroadcast;

		/// <summary>
		/// Gets the <see cref="Intel.MemorySize"/> value
		/// </summary>
		public MemorySize MemorySize => (MemorySize)memorySize;

		/// <summary>
		/// Size in bytes of the memory location or 0 if it's not accessed or unknown
		/// </summary>
		public int Size => size;

		/// <summary>
		/// Size in bytes of the packed element. If it's not a packed data type, it's equal to <see cref="Size"/>.
		/// </summary>
		public int ElementSize => elementSize;

		/// <summary>
		/// Element type if it's packed data or the type itself if it's not packed data
		/// </summary>
		public MemorySize ElementType => (MemorySize)elementType;

		/// <summary>
		/// <see langword="true"/> if it's signed data (signed integer or a floating point value)
		/// </summary>
		public bool IsSigned => isSigned;

		/// <summary>
		/// <see langword="true"/> if it's a broadcast memory type
		/// </summary>
		public bool IsBroadcast => isBroadcast;

		/// <summary>
		/// <see langword="true"/> if this is a packed data type, eg. <see cref="MemorySize.Packed128_Float32"/>. See also <see cref="ElementCount"/>
		/// </summary>
		public bool IsPacked => elementSize < size;

		/// <summary>
		/// Gets the number of elements in the packed data type or 1 if it's not packed data (<see cref="IsPacked"/>)
		/// </summary>
		public int ElementCount => elementSize == size ? 1 : size / elementSize;// ElementSize can be 0 so we don't divide by it if es == s

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="memorySize">Memory size value</param>
		/// <param name="size">Size of location</param>
		/// <param name="elementSize">Size of the packed element, or <paramref name="size"/> if it's not packed data</param>
		/// <param name="elementType">Element type if it's packed data or <paramref name="memorySize"/> if it's not packed data</param>
		/// <param name="isSigned"><see langword="true"/> if signed data</param>
		/// <param name="isBroadcast"><see langword="true"/> if broadcast</param>
		public MemorySizeInfo(MemorySize memorySize, int size, int elementSize, MemorySize elementType, bool isSigned, bool isBroadcast) {
			if (size < 0)
				ThrowHelper.ThrowArgumentOutOfRangeException_size();
			if (elementSize < 0)
				ThrowHelper.ThrowArgumentOutOfRangeException_elementSize();
			if (elementSize > size)
				ThrowHelper.ThrowArgumentOutOfRangeException_elementSize();
			Static.Assert(IcedConstants.MemorySizeEnumCount <= byte.MaxValue + 1 ? 0 : -1);
			this.memorySize = (byte)memorySize;
			Debug.Assert(size <= ushort.MaxValue);
			this.size = (ushort)size;
			Debug.Assert(elementSize <= ushort.MaxValue);
			this.elementSize = (ushort)elementSize;
			Static.Assert(IcedConstants.MemorySizeEnumCount <= byte.MaxValue + 1 ? 0 : -1);
			this.elementType = (byte)elementType;
			this.isSigned = isSigned;
			this.isBroadcast = isBroadcast;
		}
	}
}
#endif
