// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;

namespace Generator.Enums.Formatter {
	[Enum("FormatterSyntax", Documentation = "Formatter syntax (nasm)", Public = true)]
	enum FormatterSyntax {
		[Comment("nasm")]
		Nasm
	}
}
