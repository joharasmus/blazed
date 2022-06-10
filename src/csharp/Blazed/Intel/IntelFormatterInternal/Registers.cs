// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if INTEL
using Blazed.Intel.FormatterInternal;

namespace Blazed.Intel.IntelFormatterInternal {
	static class Registers {
#pragma warning disable CS0618 // Type or member is obsolete
		public const Register Register_ST = Register.DontUse0;
#pragma warning restore CS0618 // Type or member is obsolete
		public static readonly FormatterString[] AllRegisters = RegistersTable.GetRegisters();
	}
}
#endif