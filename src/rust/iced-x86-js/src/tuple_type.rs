/*
Copyright (C) 2018-2019 de4dot@gmail.com

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

use wasm_bindgen::prelude::*;

// GENERATOR-BEGIN: Enum
// ⚠️This was generated by GENERATOR!🦹‍♂️
/// Tuple type (EVEX) which can be used to get the disp8 scale factor `N`
#[wasm_bindgen]
#[derive(Copy, Clone)]
#[allow(non_camel_case_types)]
pub enum TupleType {
	/// `N = 1`
	None = 0,
	/// `N = b ? (W ? 8 : 4) : 16`
	Full_128 = 1,
	/// `N = b ? (W ? 8 : 4) : 32`
	Full_256 = 2,
	/// `N = b ? (W ? 8 : 4) : 64`
	Full_512 = 3,
	/// `N = b ? 4 : 8`
	Half_128 = 4,
	/// `N = b ? 4 : 16`
	Half_256 = 5,
	/// `N = b ? 4 : 32`
	Half_512 = 6,
	/// `N = 16`
	Full_Mem_128 = 7,
	/// `N = 32`
	Full_Mem_256 = 8,
	/// `N = 64`
	Full_Mem_512 = 9,
	/// `N = W ? 8 : 4`
	Tuple1_Scalar = 10,
	/// `N = 1`
	Tuple1_Scalar_1 = 11,
	/// `N = 2`
	Tuple1_Scalar_2 = 12,
	/// `N = 4`
	Tuple1_Scalar_4 = 13,
	/// `N = 8`
	Tuple1_Scalar_8 = 14,
	/// `N = 4`
	Tuple1_Fixed_4 = 15,
	/// `N = 8`
	Tuple1_Fixed_8 = 16,
	/// `N = W ? 16 : 8`
	Tuple2 = 17,
	/// `N = W ? 32 : 16`
	Tuple4 = 18,
	/// `N = W ? error : 32`
	Tuple8 = 19,
	/// `N = 16`
	Tuple1_4X = 20,
	/// `N = 8`
	Half_Mem_128 = 21,
	/// `N = 16`
	Half_Mem_256 = 22,
	/// `N = 32`
	Half_Mem_512 = 23,
	/// `N = 4`
	Quarter_Mem_128 = 24,
	/// `N = 8`
	Quarter_Mem_256 = 25,
	/// `N = 16`
	Quarter_Mem_512 = 26,
	/// `N = 2`
	Eighth_Mem_128 = 27,
	/// `N = 4`
	Eighth_Mem_256 = 28,
	/// `N = 8`
	Eighth_Mem_512 = 29,
	/// `N = 16`
	Mem128 = 30,
	/// `N = 8`
	MOVDDUP_128 = 31,
	/// `N = 32`
	MOVDDUP_256 = 32,
	/// `N = 64`
	MOVDDUP_512 = 33,
}
// GENERATOR-END: Enum

#[allow(dead_code)]
pub(crate) fn iced_to_tuple_type(value: iced_x86_rust::TupleType) -> TupleType {
	// Safe, the enums are exactly identical
	unsafe { std::mem::transmute(value as u8) }
}
