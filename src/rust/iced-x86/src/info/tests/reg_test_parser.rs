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

use super::super::super::test_utils::from_str_conv::*;
use super::constants::*;
use super::reg_info_test_case::*;
#[cfg(not(feature = "std"))]
use alloc::string::String;
#[cfg(not(feature = "std"))]
use alloc::vec::Vec;
use core::iter::IntoIterator;
use core::u32;
#[cfg(not(feature = "std"))]
use hashbrown::HashMap;
#[cfg(feature = "std")]
use std::collections::HashMap;
use std::fs::File;
use std::io::prelude::*;
use std::io::{BufReader, Lines};
use std::path::Path;

pub(super) struct RegisterInfoTestParser {
	filename: String,
	lines: Lines<BufReader<File>>,
}

impl RegisterInfoTestParser {
	pub(super) fn new(filename: &Path) -> Self {
		let display_filename = filename.display().to_string();
		let file = File::open(filename).unwrap_or_else(|_| panic!("Couldn't open file {}", display_filename));
		let lines = BufReader::new(file).lines();
		Self { filename: display_filename, lines }
	}
}

impl IntoIterator for RegisterInfoTestParser {
	type Item = RegisterInfoTestCase;
	type IntoIter = IntoIter;

	fn into_iter(self) -> Self::IntoIter {
		// GENERATOR-BEGIN: FlagsDict
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		let mut to_flags: HashMap<&'static str, u32> = HashMap::new();
		let _ = to_flags.insert("seg", RegisterFlags::SEGMENT_REGISTER);
		let _ = to_flags.insert("gpr", RegisterFlags::GPR);
		let _ = to_flags.insert("gpr8", RegisterFlags::GPR8);
		let _ = to_flags.insert("gpr16", RegisterFlags::GPR16);
		let _ = to_flags.insert("gpr32", RegisterFlags::GPR32);
		let _ = to_flags.insert("gpr64", RegisterFlags::GPR64);
		let _ = to_flags.insert("xmm", RegisterFlags::XMM);
		let _ = to_flags.insert("ymm", RegisterFlags::YMM);
		let _ = to_flags.insert("zmm", RegisterFlags::ZMM);
		let _ = to_flags.insert("vec", RegisterFlags::VECTOR_REGISTER);
		let _ = to_flags.insert("ip", RegisterFlags::IP);
		let _ = to_flags.insert("k", RegisterFlags::K);
		let _ = to_flags.insert("bnd", RegisterFlags::BND);
		let _ = to_flags.insert("cr", RegisterFlags::CR);
		let _ = to_flags.insert("dr", RegisterFlags::DR);
		let _ = to_flags.insert("tr", RegisterFlags::TR);
		let _ = to_flags.insert("st", RegisterFlags::ST);
		let _ = to_flags.insert("mm", RegisterFlags::MM);
		// GENERATOR-END: FlagsDict

		IntoIter { filename: self.filename, lines: self.lines, line_number: 0, to_flags }
	}
}

pub(super) struct IntoIter {
	filename: String,
	lines: Lines<BufReader<File>>,
	line_number: u32,
	to_flags: HashMap<&'static str, u32>,
}

impl Iterator for IntoIter {
	type Item = RegisterInfoTestCase;

	fn next(&mut self) -> Option<Self::Item> {
		loop {
			match self.lines.next() {
				None => return None,
				Some(info) => {
					let result = match info {
						Ok(line) => {
							self.line_number += 1;
							if line.is_empty() || line.starts_with('#') {
								continue;
							}
							self.read_next_test_case(line, self.line_number)
						}
						Err(err) => Err(err.to_string()),
					};
					match result {
						Ok(tc) => return Some(tc),
						Err(err) => panic!("Error parsing register info test case file '{}', line {}: {}", self.filename, self.line_number, err),
					}
				}
			}
		}
	}
}

impl IntoIter {
	fn read_next_test_case(&self, line: String, line_number: u32) -> Result<RegisterInfoTestCase, String> {
		const_assert_eq!(7, MiscInstrInfoTestConstants::REGISTER_ELEMS_PER_LINE);
		let elems: Vec<_> = line.splitn(MiscInstrInfoTestConstants::REGISTER_ELEMS_PER_LINE, ',').collect();
		if elems.len() != MiscInstrInfoTestConstants::REGISTER_ELEMS_PER_LINE {
			return Err(format!("Invalid number of commas: {}", elems.len() - 1));
		}

		let mut tc = RegisterInfoTestCase::default();
		tc.line_number = line_number;
		tc.register = to_register(elems[0])?;
		tc.number = to_u32(elems[1])? as usize;
		tc.base = to_register(elems[2])?;
		tc.full_register = to_register(elems[3])?;
		tc.full_register32 = to_register(elems[4])?;
		tc.size = to_u32(elems[5])? as usize;
		for value in elems[6].split_whitespace() {
			if value.is_empty() {
				continue;
			}
			match self.to_flags.get(value) {
				Some(flags) => tc.flags |= *flags,
				None => return Err(format!("Invalid flags value: {}", value)),
			}
		}

		Ok(tc)
	}
}
