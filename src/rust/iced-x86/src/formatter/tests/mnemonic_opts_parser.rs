// SPDX-License-Identifier: MIT
// Copyright wtfsckgh@gmail.com
// Copyright iced contributors

#![allow(unused_results)]

use super::super::super::test_utils::from_str_conv::*;
use super::super::super::Code;
use super::super::enums::FormatMnemonicOptions;
use alloc::string::String;
use alloc::vec::Vec;
use core::iter::IntoIterator;
use core::u32;
use std::collections::HashMap;
use std::fs::File;
use std::io::prelude::*;
use std::io::{BufReader, Lines};
use std::path::Path;

pub(in super::super) struct MnemonicOptionsTestCase {
	pub(in super::super) hex_bytes: String,
	pub(in super::super) code: Code,
	pub(in super::super) bitness: u32,
	pub(in super::super) formatted_string: String,
	pub(in super::super) flags: u32, // FormatMnemonicOptions
}

pub(in super::super) struct MnemonicOptionsTestParser {
	filename: String,
	lines: Lines<BufReader<File>>,
}

impl MnemonicOptionsTestParser {
	pub(in super::super) fn new(filename: &Path) -> Self {
		let display_filename = filename.display().to_string();
		let file = File::open(filename).unwrap_or_else(|_| panic!("Couldn't open file {}", display_filename));
		let lines = BufReader::new(file).lines();
		Self { filename: display_filename, lines }
	}
}

impl IntoIterator for MnemonicOptionsTestParser {
	type Item = MnemonicOptionsTestCase;
	type IntoIter = IntoIter;

	fn into_iter(self) -> Self::IntoIter {
		// GENERATOR-BEGIN: OptionsDict
		// ⚠️This was generated by GENERATOR!🦹‍♂️
		let mut to_flags: HashMap<&'static str, u32> = HashMap::with_capacity(2);
		to_flags.insert("noprefixes", FormatMnemonicOptions::NO_PREFIXES);
		to_flags.insert("nomnemonic", FormatMnemonicOptions::NO_MNEMONIC);
		// GENERATOR-END: OptionsDict

		IntoIter { filename: self.filename, lines: self.lines, line_number: 0, to_flags }
	}
}

pub(in super::super) struct IntoIter {
	filename: String,
	lines: Lines<BufReader<File>>,
	line_number: u32,
	to_flags: HashMap<&'static str, u32>,
}

impl Iterator for IntoIter {
	type Item = MnemonicOptionsTestCase;

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
						Err(err) => panic!("Error parsing mnemonic options test case file '{}', line {}: {}", self.filename, self.line_number, err),
					}
				}
			}
		}
	}
}

impl IntoIter {
	fn read_next_test_case(&self, line: String) -> Result<Option<MnemonicOptionsTestCase>, String> {
		let elems: Vec<_> = line.split(',').collect();
		if elems.len() != 5 {
			return Err(format!("Invalid number of commas: {}", elems.len() - 1));
		}

		let hex_bytes = String::from(elems[0].trim());
		let _ = to_vec_u8(&hex_bytes)?;
		if is_ignored_code(elems[1]) {
			return Ok(None);
		}
		let code = to_code(elems[1])?;
		let bitness = to_u32(elems[2])?;
		let formatted_string = elems[3].trim().replace('|', ",");
		let mut flags = FormatMnemonicOptions::NONE;
		for value in elems[4].split_whitespace() {
			if value.is_empty() {
				continue;
			}
			match self.to_flags.get(value) {
				Some(f) => flags |= *f,
				None => return Err(format!("Invalid flags value: {}", value)),
			}
		}

		Ok(Some(MnemonicOptionsTestCase { hex_bytes, code, bitness, formatted_string, flags }))
	}
}
