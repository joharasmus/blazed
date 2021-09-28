// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

use wasm_bindgen::prelude::*;

// GENERATOR-BEGIN: Enum
// ⚠️This was generated by GENERATOR!🦹‍♂️
/// Mandatory prefix
#[wasm_bindgen]
#[derive(Copy, Clone)]
pub enum MandatoryPrefix {
	/// No mandatory prefix (legacy and 3DNow! tables only)
	None = 0,
	/// Empty mandatory prefix (no `66`, `F3` or `F2` prefix)
	PNP = 1,
	/// `66` prefix
	P66 = 2,
	/// `F3` prefix
	PF3 = 3,
	/// `F2` prefix
	PF2 = 4,
}
// GENERATOR-END: Enum

#[allow(dead_code)]
pub(crate) fn iced_to_mandatory_prefix(value: iced_x86_rust::MandatoryPrefix) -> MandatoryPrefix {
	// SAFETY: the enums are exactly identical
	unsafe { std::mem::transmute(value as u8) }
}
