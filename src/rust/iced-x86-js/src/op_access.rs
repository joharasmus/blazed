// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

use wasm_bindgen::prelude::*;

// GENERATOR-BEGIN: Enum
// ⚠️This was generated by GENERATOR!🦹‍♂️
/// Operand, register and memory access
#[wasm_bindgen]
#[derive(Copy, Clone)]
pub enum OpAccess {
	/// Nothing is read and nothing is written
	None = 0,
	/// The value is read
	Read = 1,
	/// The value is sometimes read and sometimes not
	CondRead = 2,
	/// The value is completely overwritten
	Write = 3,
	/// Conditional write, sometimes it's written and sometimes it's not modified
	CondWrite = 4,
	/// The value is read and written
	ReadWrite = 5,
	/// The value is read and sometimes written
	ReadCondWrite = 6,
	/// The memory operand doesn't refer to memory (eg. `LEA` instruction) or it's an instruction that doesn't read the data to a register or doesn't write to the memory location, it just prefetches/invalidates it, eg. `INVLPG`, `PREFETCHNTA`, `VGATHERPF0DPS`, etc. Some of those instructions still check if the code can access the memory location.
	NoMemAccess = 7,
}
// GENERATOR-END: Enum

#[allow(dead_code)]
pub(crate) fn iced_to_op_access(value: iced_x86_rust::OpAccess) -> OpAccess {
	// SAFETY: the enums are exactly identical
	unsafe { std::mem::transmute(value as u8) }
}
