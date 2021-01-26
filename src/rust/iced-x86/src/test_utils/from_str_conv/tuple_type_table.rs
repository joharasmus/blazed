// SPDX-License-Identifier: MIT
// Copyright wtfsckgh@gmail.com
// Copyright iced contributors

#![allow(unused_results)]

use super::super::super::TupleType;
use std::collections::HashMap;

lazy_static! {
	pub(super) static ref TO_TUPLE_TYPE_HASH: HashMap<&'static str, TupleType> = {
		// GENERATOR-BEGIN: TupleTypeHash
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		let mut h = HashMap::with_capacity(14);
		h.insert("N1", TupleType::N1);
		h.insert("N2", TupleType::N2);
		h.insert("N4", TupleType::N4);
		h.insert("N8", TupleType::N8);
		h.insert("N16", TupleType::N16);
		h.insert("N32", TupleType::N32);
		h.insert("N64", TupleType::N64);
		h.insert("N8b4", TupleType::N8b4);
		h.insert("N16b4", TupleType::N16b4);
		h.insert("N32b4", TupleType::N32b4);
		h.insert("N64b4", TupleType::N64b4);
		h.insert("N16b8", TupleType::N16b8);
		h.insert("N32b8", TupleType::N32b8);
		h.insert("N64b8", TupleType::N64b8);
		// GENERATOR-END: TupleTypeHash
		h
	};
}
