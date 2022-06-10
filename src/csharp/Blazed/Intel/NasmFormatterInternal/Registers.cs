// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if NASM
using Blazed.Intel.FormatterInternal;

namespace Blazed.Intel.NasmFormatterInternal {
	static class Registers {
		public static readonly FormatterString[] AllRegisters = GetRegisters();
		static FormatterString[] GetRegisters() {
			var registers = RegistersTable.GetRegisters();
			for (int i = 0; i < 8; i++)
				registers[(int)Register.ST0 + i] = new FormatterString("st" + i.ToString());
			return registers;
		}
	}
}
#endif
