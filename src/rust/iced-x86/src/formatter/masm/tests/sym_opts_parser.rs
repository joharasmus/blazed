// SPDX-License-Identifier: MIT
// Copyright wtfsckgh@gmail.com
// Copyright iced contributors

#![allow(unused_results)]

use super::super::super::test_utils::from_str_conv::*;
use super::sym_opts::*;
use alloc::string::String;
use alloc::vec::Vec;
use core::iter::IntoIterator;
use core::u32;
use std::collections::HashMap;
use std::fs::File;
use std::io::prelude::*;
use std::io::{BufReader, Lines};
use std::path::Path;

pub(super) struct SymbolOptionsTestParser {
	filename: String,
	lines: Lines<BufReader<File>>,
}

impl SymbolOptionsTestParser {
	pub(super) fn new(filename: &Path) -> Self {
		let display_filename = filename.display().to_string();
		let file = File::open(filename).unwrap_or_else(|_| panic!("Couldn't open file {}", display_filename));
		let lines = BufReader::new(file).lines();
		Self { filename: display_filename, lines }
	}
}

impl IntoIterator for SymbolOptionsTestParser {
	type Item = SymbolOptionsTestCase;
	type IntoIter = IntoIter;

	fn into_iter(self) -> Self::IntoIter {
		// GENERATOR-BEGIN: SymbolTestFlagsDict
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		let mut to_flags: HashMap<&'static str, u32> = HashMap::with_capacity(7);
		to_flags.insert("sym", SymbolTestFlags::SYMBOL);
		to_flags.insert("signed", SymbolTestFlags::SIGNED);
		to_flags.insert("symbr", SymbolTestFlags::SYMBOL_DISPL_IN_BRACKETS);
		to_flags.insert("displbr", SymbolTestFlags::DISPL_IN_BRACKETS);
		to_flags.insert("rip", SymbolTestFlags::RIP);
		to_flags.insert("disp0", SymbolTestFlags::SHOW_ZERO_DISPLACEMENTS);
		to_flags.insert("nods32", SymbolTestFlags::NO_ADD_DS_PREFIX32);
		// GENERATOR-END: SymbolTestFlagsDict

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
	type Item = SymbolOptionsTestCase;

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
							self.read_next_test_case(line)
						}
						Err(err) => Err(err.to_string()),
					};
					match result {
						Ok(tc) => {
							if let Some(tc) = tc {
								return Some(tc);
							} else {
								continue;
							}
						}
						Err(err) => panic!("Error parsing symbol options test case file '{}', line {}: {}", self.filename, self.line_number, err),
					}
				}
			}
		}
	}
}

impl IntoIter {
	fn read_next_test_case(&self, line: String) -> Result<Option<SymbolOptionsTestCase>, String> {
		let elems: Vec<_> = line.split(',').collect();
		if elems.len() != 5 {
			return Err(format!("Invalid number of commas: {}", elems.len() - 1));
		}

		let hex_bytes = String::from(elems[0].trim());
		let _ = to_vec_u8(&hex_bytes)?;
		if is_ignored_code(elems[1]) {
			return Ok(None);
		}
		let bitness = to_u32(elems[2])?;
		let formatted_string = elems[3].trim().replace('|', ",");
		let mut flags = SymbolTestFlags::NONE;
		for value in elems[4].split_whitespace() {
			if value.is_empty() {
				continue;
			}
			match self.to_flags.get(value) {
				Some(f) => flags |= *f,
				None => return Err(format!("Invalid flags value: {}", value)),
			}
		}

		Ok(Some(SymbolOptionsTestCase { hex_bytes, bitness, formatted_string, flags }))
	}
}
