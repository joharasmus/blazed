// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if INSTR_INFO
namespace Blazed.Intel.InstructionInfoInternal {
	struct SimpleList<T> {
		public static readonly SimpleList<T> Empty = new SimpleList<T>(System.Array.Empty<T>());
		public T[] Array;
		public int ValidLength;
		public SimpleList(T[] array) {
			Array = array;
			ValidLength = 0;
		}
	}
}
#endif
