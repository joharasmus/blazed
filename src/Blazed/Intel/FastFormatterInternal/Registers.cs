// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if FAST_FMT
using Blazed.Intel.FormatterInternal;

namespace Blazed.Intel.FastFormatterInternal {
	static class Registers {
		public static readonly FormatterString[] AllRegisters = RegistersTable.GetRegisters();
	}
}
#endif
