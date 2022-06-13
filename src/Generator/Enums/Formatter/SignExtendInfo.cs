// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

namespace Generator.Enums.Formatter {
	[Enum(nameof(SignExtendInfo), "SignExtendInfo")]
	enum SignExtendInfo {
		None,
		Sex1to2,
		Sex1to4,
		Sex1to8,
		Sex4to8,
		Sex2,
		Sex4,
	}
}
