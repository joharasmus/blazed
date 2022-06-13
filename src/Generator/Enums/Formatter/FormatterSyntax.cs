// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;

namespace Generator.Enums.Formatter {
	[Enum("FormatterSyntax", Documentation = "Formatter syntax (Intel XED, masm, nasm)", Public = true)]
	enum FormatterSyntax {
		[Comment("Intel XED")]
		Intel,
		[Comment("masm")]
		Masm,
		[Comment("nasm")]
		Nasm,
		// This enum only contains entries for formatters that implement the Formatter iface/trait
	}
}
