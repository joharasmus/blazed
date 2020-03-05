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

use super::super::*;
#[cfg(not(feature = "std"))]
use alloc::vec::Vec;

pub(crate) fn get_tests() -> Vec<(u32, &'static str, Instruction)> {
	let mut v = Vec::with_capacity(INFOS16_LEN + INFOS32_LEN + INFOS64_LEN);
	for &(hex_bytes, instr) in (&*INFOS16).iter() {
		v.push((16, hex_bytes, instr));
	}
	for &(hex_bytes, instr) in (&*INFOS32).iter() {
		v.push((32, hex_bytes, instr));
	}
	for &(hex_bytes, instr) in (&*INFOS64).iter() {
		v.push((64, hex_bytes, instr));
	}
	v
}

#[cfg(any(feature = "gas", feature = "intel", feature = "masm", feature = "nasm"))]
pub(crate) fn get_infos(bitness: u32) -> &'static Vec<(&'static str, Instruction)> {
	match bitness {
		16 => &*INFOS16,
		32 => &*INFOS32,
		64 => &*INFOS64,
		_ => unreachable!(),
	}
}

const INFOS16_LEN: usize = 49;
const INFOS32_LEN: usize = 49;
const INFOS64_LEN: usize = 48;

fn c16(mut instruction: Instruction) -> Instruction {
	instruction.set_code_size(CodeSize::Code16);
	instruction
}

fn c32(mut instruction: Instruction) -> Instruction {
	instruction.set_code_size(CodeSize::Code32);
	instruction
}

fn c64(mut instruction: Instruction) -> Instruction {
	instruction.set_code_size(CodeSize::Code64);
	instruction
}

lazy_static! {
	static ref INFOS16: Vec<(&'static str, Instruction)> = {
		#[cfg_attr(feature = "cargo-fmt", rustfmt::skip)]
		let array: [_; INFOS16_LEN] = [
			("0F", c16(Instruction::with_reg(Code::Popw_CS, Register::CS))),
			("9B D9 30", c16(Instruction::with_mem(Code::Fstenv_m14byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::None)))),
			("9B 64 D9 30", c16(Instruction::with_mem(Code::Fstenv_m14byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::FS)))),
			("9B 66 D9 30", c16(Instruction::with_mem(Code::Fstenv_m28byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::None)))),
			("9B 64 66 D9 30", c16(Instruction::with_mem(Code::Fstenv_m28byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::FS)))),
			("9B D9 38", c16(Instruction::with_mem(Code::Fstcw_m2byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::None)))),
			("9B 64 D9 38", c16(Instruction::with_mem(Code::Fstcw_m2byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::FS)))),
			("9B DB E0", c16(Instruction::with(Code::Feni))),
			("9B DB E1", c16(Instruction::with(Code::Fdisi))),
			("9B DB E2", c16(Instruction::with(Code::Fclex))),
			("9B DB E3", c16(Instruction::with(Code::Finit))),
			("9B DB E4", c16(Instruction::with(Code::Fsetpm))),
			("9B DD 30", c16(Instruction::with_mem(Code::Fsave_m94byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::None)))),
			("9B 64 DD 30", c16(Instruction::with_mem(Code::Fsave_m94byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::FS)))),
			("9B 66 DD 30", c16(Instruction::with_mem(Code::Fsave_m108byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::None)))),
			("9B 64 66 DD 30", c16(Instruction::with_mem(Code::Fsave_m108byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::FS)))),
			("9B DD 38", c16(Instruction::with_mem(Code::Fstsw_m2byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::None)))),
			("9B 64 DD 38", c16(Instruction::with_mem(Code::Fstsw_m2byte, MemoryOperand::new(Register::BX, Register::SI, 1, 0, 0, false, Register::FS)))),
			("9B DF E0", c16(Instruction::with_reg(Code::Fstsw_AX, Register::AX))),
			("77", c16(Instruction::with_declare_byte_1(0x77))),
			("77 A9", c16(Instruction::with_declare_byte_2(0x77, 0xA9))),
			("77 A9 CE", c16(Instruction::with_declare_byte_3(0x77, 0xA9, 0xCE))),
			("77 A9 CE 9D", c16(Instruction::with_declare_byte_4(0x77, 0xA9, 0xCE, 0x9D))),
			("77 A9 CE 9D 55", c16(Instruction::with_declare_byte_5(0x77, 0xA9, 0xCE, 0x9D, 0x55))),
			("77 A9 CE 9D 55 05", c16(Instruction::with_declare_byte_6(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05))),
			("77 A9 CE 9D 55 05 42", c16(Instruction::with_declare_byte_7(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42))),
			("77 A9 CE 9D 55 05 42 6C", c16(Instruction::with_declare_byte_8(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C))),
			("77 A9 CE 9D 55 05 42 6C 86", c16(Instruction::with_declare_byte_9(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86))),
			("77 A9 CE 9D 55 05 42 6C 86 32", c16(Instruction::with_declare_byte_10(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE", c16(Instruction::with_declare_byte_11(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F", c16(Instruction::with_declare_byte_12(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34", c16(Instruction::with_declare_byte_13(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34 27", c16(Instruction::with_declare_byte_14(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34, 0x27))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34 27 AA", c16(Instruction::with_declare_byte_15(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34, 0x27, 0xAA))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34 27 AA 08", c16(Instruction::with_declare_byte_16(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34, 0x27, 0xAA, 0x08))),
			("A977", c16(Instruction::with_declare_word_1(0x77A9))),
			("A977 9DCE", c16(Instruction::with_declare_word_2(0x77A9, 0xCE9D))),
			("A977 9DCE 0555", c16(Instruction::with_declare_word_3(0x77A9, 0xCE9D, 0x5505))),
			("A977 9DCE 0555 6C42", c16(Instruction::with_declare_word_4(0x77A9, 0xCE9D, 0x5505, 0x426C))),
			("A977 9DCE 0555 6C42 3286", c16(Instruction::with_declare_word_5(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632))),
			("A977 9DCE 0555 6C42 3286 4FFE", c16(Instruction::with_declare_word_6(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632, 0xFE4F))),
			("A977 9DCE 0555 6C42 3286 4FFE 2734", c16(Instruction::with_declare_word_7(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632, 0xFE4F, 0x3427))),
			("A977 9DCE 0555 6C42 3286 4FFE 2734 08AA", c16(Instruction::with_declare_word_8(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632, 0xFE4F, 0x3427, 0xAA08))),
			("9DCEA977", c16(Instruction::with_declare_dword_1(0x77A9_CE9D))),
			("9DCEA977 6C420555", c16(Instruction::with_declare_dword_2(0x77A9_CE9D, 0x5505_426C))),
			("9DCEA977 6C420555 4FFE3286", c16(Instruction::with_declare_dword_3(0x77A9_CE9D, 0x5505_426C, 0x8632_FE4F))),
			("9DCEA977 6C420555 4FFE3286 08AA2734", c16(Instruction::with_declare_dword_4(0x77A9_CE9D, 0x5505_426C, 0x8632_FE4F, 0x3427_AA08))),
			("6C4205559DCEA977", c16(Instruction::with_declare_qword_1(0x77A9_CE9D_5505_426C))),
			("6C4205559DCEA977 08AA27344FFE3286", c16(Instruction::with_declare_qword_2(0x77A9_CE9D_5505_426C, 0x8632_FE4F_3427_AA08))),
		];
		array.iter().cloned().collect()
	};
}

lazy_static! {
	static ref INFOS32: Vec<(&'static str, Instruction)> = {
		#[cfg_attr(feature = "cargo-fmt", rustfmt::skip)]
		let array: [_; INFOS32_LEN] = [
			("66 0F", c32(Instruction::with_reg(Code::Popw_CS, Register::CS))),
			("9B 66 D9 30", c32(Instruction::with_mem(Code::Fstenv_m14byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 66 D9 30", c32(Instruction::with_mem(Code::Fstenv_m14byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B D9 30", c32(Instruction::with_mem(Code::Fstenv_m28byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 D9 30", c32(Instruction::with_mem(Code::Fstenv_m28byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B D9 38", c32(Instruction::with_mem(Code::Fstcw_m2byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 D9 38", c32(Instruction::with_mem(Code::Fstcw_m2byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B DB E0", c32(Instruction::with(Code::Feni))),
			("9B DB E1", c32(Instruction::with(Code::Fdisi))),
			("9B DB E2", c32(Instruction::with(Code::Fclex))),
			("9B DB E3", c32(Instruction::with(Code::Finit))),
			("9B DB E4", c32(Instruction::with(Code::Fsetpm))),
			("9B 66 DD 30", c32(Instruction::with_mem(Code::Fsave_m94byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 66 DD 30", c32(Instruction::with_mem(Code::Fsave_m94byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B DD 30", c32(Instruction::with_mem(Code::Fsave_m108byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 DD 30", c32(Instruction::with_mem(Code::Fsave_m108byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B DD 38", c32(Instruction::with_mem(Code::Fstsw_m2byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 DD 38", c32(Instruction::with_mem(Code::Fstsw_m2byte, MemoryOperand::new(Register::EAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B DF E0", c32(Instruction::with_reg(Code::Fstsw_AX, Register::AX))),
			("77", c32(Instruction::with_declare_byte_1(0x77))),
			("77 A9", c32(Instruction::with_declare_byte_2(0x77, 0xA9))),
			("77 A9 CE", c32(Instruction::with_declare_byte_3(0x77, 0xA9, 0xCE))),
			("77 A9 CE 9D", c32(Instruction::with_declare_byte_4(0x77, 0xA9, 0xCE, 0x9D))),
			("77 A9 CE 9D 55", c32(Instruction::with_declare_byte_5(0x77, 0xA9, 0xCE, 0x9D, 0x55))),
			("77 A9 CE 9D 55 05", c32(Instruction::with_declare_byte_6(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05))),
			("77 A9 CE 9D 55 05 42", c32(Instruction::with_declare_byte_7(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42))),
			("77 A9 CE 9D 55 05 42 6C", c32(Instruction::with_declare_byte_8(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C))),
			("77 A9 CE 9D 55 05 42 6C 86", c32(Instruction::with_declare_byte_9(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86))),
			("77 A9 CE 9D 55 05 42 6C 86 32", c32(Instruction::with_declare_byte_10(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE", c32(Instruction::with_declare_byte_11(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F", c32(Instruction::with_declare_byte_12(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34", c32(Instruction::with_declare_byte_13(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34 27", c32(Instruction::with_declare_byte_14(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34, 0x27))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34 27 AA", c32(Instruction::with_declare_byte_15(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34, 0x27, 0xAA))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34 27 AA 08", c32(Instruction::with_declare_byte_16(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34, 0x27, 0xAA, 0x08))),
			("A977", c32(Instruction::with_declare_word_1(0x77A9))),
			("A977 9DCE", c32(Instruction::with_declare_word_2(0x77A9, 0xCE9D))),
			("A977 9DCE 0555", c32(Instruction::with_declare_word_3(0x77A9, 0xCE9D, 0x5505))),
			("A977 9DCE 0555 6C42", c32(Instruction::with_declare_word_4(0x77A9, 0xCE9D, 0x5505, 0x426C))),
			("A977 9DCE 0555 6C42 3286", c32(Instruction::with_declare_word_5(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632))),
			("A977 9DCE 0555 6C42 3286 4FFE", c32(Instruction::with_declare_word_6(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632, 0xFE4F))),
			("A977 9DCE 0555 6C42 3286 4FFE 2734", c32(Instruction::with_declare_word_7(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632, 0xFE4F, 0x3427))),
			("A977 9DCE 0555 6C42 3286 4FFE 2734 08AA", c32(Instruction::with_declare_word_8(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632, 0xFE4F, 0x3427, 0xAA08))),
			("9DCEA977", c32(Instruction::with_declare_dword_1(0x77A9_CE9D))),
			("9DCEA977 6C420555", c32(Instruction::with_declare_dword_2(0x77A9_CE9D, 0x5505_426C))),
			("9DCEA977 6C420555 4FFE3286", c32(Instruction::with_declare_dword_3(0x77A9_CE9D, 0x5505_426C, 0x8632_FE4F))),
			("9DCEA977 6C420555 4FFE3286 08AA2734", c32(Instruction::with_declare_dword_4(0x77A9_CE9D, 0x5505_426C, 0x8632_FE4F, 0x3427_AA08))),
			("6C4205559DCEA977", c32(Instruction::with_declare_qword_1(0x77A9_CE9D_5505_426C))),
			("6C4205559DCEA977 08AA27344FFE3286", c32(Instruction::with_declare_qword_2(0x77A9_CE9D_5505_426C, 0x8632_FE4F_3427_AA08))),
		];
		array.iter().cloned().collect()
	};
}

lazy_static! {
	static ref INFOS64: Vec<(&'static str, Instruction)> = {
		#[cfg_attr(feature = "cargo-fmt", rustfmt::skip)]
		let array: [_; INFOS64_LEN] = [
			("9B 66 D9 30", c64(Instruction::with_mem(Code::Fstenv_m14byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 66 D9 30", c64(Instruction::with_mem(Code::Fstenv_m14byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B D9 30", c64(Instruction::with_mem(Code::Fstenv_m28byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 D9 30", c64(Instruction::with_mem(Code::Fstenv_m28byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B D9 38", c64(Instruction::with_mem(Code::Fstcw_m2byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 D9 38", c64(Instruction::with_mem(Code::Fstcw_m2byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B DB E0", c64(Instruction::with(Code::Feni))),
			("9B DB E1", c64(Instruction::with(Code::Fdisi))),
			("9B DB E2", c64(Instruction::with(Code::Fclex))),
			("9B DB E3", c64(Instruction::with(Code::Finit))),
			("9B DB E4", c64(Instruction::with(Code::Fsetpm))),
			("9B 66 DD 30", c64(Instruction::with_mem(Code::Fsave_m94byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 66 DD 30", c64(Instruction::with_mem(Code::Fsave_m94byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B DD 30", c64(Instruction::with_mem(Code::Fsave_m108byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 DD 30", c64(Instruction::with_mem(Code::Fsave_m108byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B DD 38", c64(Instruction::with_mem(Code::Fstsw_m2byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::None)))),
			("9B 64 DD 38", c64(Instruction::with_mem(Code::Fstsw_m2byte, MemoryOperand::new(Register::RAX, Register::None, 1, 0, 0, false, Register::FS)))),
			("9B DF E0", c64(Instruction::with_reg(Code::Fstsw_AX, Register::AX))),
			("77", c64(Instruction::with_declare_byte_1(0x77))),
			("77 A9", c64(Instruction::with_declare_byte_2(0x77, 0xA9))),
			("77 A9 CE", c64(Instruction::with_declare_byte_3(0x77, 0xA9, 0xCE))),
			("77 A9 CE 9D", c64(Instruction::with_declare_byte_4(0x77, 0xA9, 0xCE, 0x9D))),
			("77 A9 CE 9D 55", c64(Instruction::with_declare_byte_5(0x77, 0xA9, 0xCE, 0x9D, 0x55))),
			("77 A9 CE 9D 55 05", c64(Instruction::with_declare_byte_6(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05))),
			("77 A9 CE 9D 55 05 42", c64(Instruction::with_declare_byte_7(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42))),
			("77 A9 CE 9D 55 05 42 6C", c64(Instruction::with_declare_byte_8(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C))),
			("77 A9 CE 9D 55 05 42 6C 86", c64(Instruction::with_declare_byte_9(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86))),
			("77 A9 CE 9D 55 05 42 6C 86 32", c64(Instruction::with_declare_byte_10(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE", c64(Instruction::with_declare_byte_11(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F", c64(Instruction::with_declare_byte_12(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34", c64(Instruction::with_declare_byte_13(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34 27", c64(Instruction::with_declare_byte_14(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34, 0x27))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34 27 AA", c64(Instruction::with_declare_byte_15(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34, 0x27, 0xAA))),
			("77 A9 CE 9D 55 05 42 6C 86 32 FE 4F 34 27 AA 08", c64(Instruction::with_declare_byte_16(0x77, 0xA9, 0xCE, 0x9D, 0x55, 0x05, 0x42, 0x6C, 0x86, 0x32, 0xFE, 0x4F, 0x34, 0x27, 0xAA, 0x08))),
			("A977", c64(Instruction::with_declare_word_1(0x77A9))),
			("A977 9DCE", c64(Instruction::with_declare_word_2(0x77A9, 0xCE9D))),
			("A977 9DCE 0555", c64(Instruction::with_declare_word_3(0x77A9, 0xCE9D, 0x5505))),
			("A977 9DCE 0555 6C42", c64(Instruction::with_declare_word_4(0x77A9, 0xCE9D, 0x5505, 0x426C))),
			("A977 9DCE 0555 6C42 3286", c64(Instruction::with_declare_word_5(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632))),
			("A977 9DCE 0555 6C42 3286 4FFE", c64(Instruction::with_declare_word_6(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632, 0xFE4F))),
			("A977 9DCE 0555 6C42 3286 4FFE 2734", c64(Instruction::with_declare_word_7(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632, 0xFE4F, 0x3427))),
			("A977 9DCE 0555 6C42 3286 4FFE 2734 08AA", c64(Instruction::with_declare_word_8(0x77A9, 0xCE9D, 0x5505, 0x426C, 0x8632, 0xFE4F, 0x3427, 0xAA08))),
			("9DCEA977", c64(Instruction::with_declare_dword_1(0x77A9_CE9D))),
			("9DCEA977 6C420555", c64(Instruction::with_declare_dword_2(0x77A9_CE9D, 0x5505_426C))),
			("9DCEA977 6C420555 4FFE3286", c64(Instruction::with_declare_dword_3(0x77A9_CE9D, 0x5505_426C, 0x8632_FE4F))),
			("9DCEA977 6C420555 4FFE3286 08AA2734", c64(Instruction::with_declare_dword_4(0x77A9_CE9D, 0x5505_426C, 0x8632_FE4F, 0x3427_AA08))),
			("6C4205559DCEA977", c64(Instruction::with_declare_qword_1(0x77A9_CE9D_5505_426C))),
			("6C4205559DCEA977 08AA27344FFE3286", c64(Instruction::with_declare_qword_2(0x77A9_CE9D_5505_426C, 0x8632_FE4F_3427_AA08))),
		];
		array.iter().cloned().collect()
	};
}
