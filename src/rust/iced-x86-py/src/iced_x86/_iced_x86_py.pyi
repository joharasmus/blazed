#
# Copyright (C) 2018-2019 de4dot@gmail.com
#
# Permission is hereby granted, free of charge, to any person obtaining
# a copy of this software and associated documentation files (the
# "Software"), to deal in the Software without restriction, including
# without limitation the rights to use, copy, modify, merge, publish,
# distribute, sublicense, and/or sell copies of the Software, and to
# permit persons to whom the Software is furnished to do so, subject to
# the following conditions:
#
# The above copyright notice and this permission notice shall be
# included in all copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
# EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
# MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
# IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
# CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
# TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
# SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#

from collections.abc import Iterator
from enum import IntEnum, IntFlag
from typing import Any, List, Optional, Union

# pylint: disable=unsubscriptable-object

class Code(IntEnum): ...
class CodeSize(IntEnum): ...
class ConditionCode(IntEnum): ...
class CpuidFeature(IntEnum): ...
class DecoderOptions(IntFlag):
	NONE = 0
	...
class EncodingKind(IntEnum): ...
class FlowControl(IntEnum): ...
class MemorySize(IntEnum): ...
class Mnemonic(IntEnum): ...
class OpKind(IntEnum): ...
class Register(IntEnum): ...
class RoundingControl(IntEnum): ...
class FormatterSyntax(IntEnum): ...
class FormatMnemonicOptions(IntEnum):
	NONE = 0
	...
class OpAccess(IntEnum): ...
class MemorySizeOptions(IntEnum): ...
class CC_b(IntEnum): ...
class CC_ae(IntEnum): ...
class CC_e(IntEnum): ...
class CC_ne(IntEnum): ...
class CC_be(IntEnum): ...
class CC_a(IntEnum): ...
class CC_p(IntEnum): ...
class CC_np(IntEnum): ...
class CC_l(IntEnum): ...
class CC_ge(IntEnum): ...
class CC_le(IntEnum): ...
class CC_g(IntEnum): ...


class OpCodeInfo:
	def __init__(self, code: Code) -> None: ...
	@property
	def code(self) -> int: ...
	@property
	def mnemonic(self) -> int: ...
	@property
	def encoding(self) -> int: ...
	@property
	def is_instruction(self) -> bool: ...
	@property
	def mode16(self) -> bool: ...
	@property
	def mode32(self) -> bool: ...
	@property
	def mode64(self) -> bool: ...
	@property
	def fwait(self) -> bool: ...
	@property
	def operand_size(self) -> int: ...
	@property
	def address_size(self) -> int: ...
	@property
	def l(self) -> int: ...
	@property
	def w(self) -> int: ...
	@property
	def is_lig(self) -> bool: ...
	@property
	def is_wig(self) -> bool: ...
	@property
	def is_wig32(self) -> bool: ...
	@property
	def tuple_type(self) -> int: ...
	@property
	def memory_size(self) -> int: ...
	@property
	def broadcast_memory_size(self) -> int: ...
	@property
	def can_broadcast(self) -> bool: ...
	@property
	def can_use_rounding_control(self) -> bool: ...
	@property
	def can_suppress_all_exceptions(self) -> bool: ...
	@property
	def can_use_op_mask_register(self) -> bool: ...
	@property
	def require_op_mask_register(self) -> bool: ...
	@property
	def can_use_zeroing_masking(self) -> bool: ...
	@property
	def can_use_lock_prefix(self) -> bool: ...
	@property
	def can_use_xacquire_prefix(self) -> bool: ...
	@property
	def can_use_xrelease_prefix(self) -> bool: ...
	@property
	def can_use_rep_prefix(self) -> bool: ...
	@property
	def can_use_repne_prefix(self) -> bool: ...
	@property
	def can_use_bnd_prefix(self) -> bool: ...
	@property
	def can_use_hint_taken_prefix(self) -> bool: ...
	@property
	def can_use_notrack_prefix(self) -> bool: ...
	@property
	def ignores_rounding_control(self) -> bool: ...
	@property
	def amd_lock_reg_bit(self) -> bool: ...
	@property
	def default_op_size64(self) -> bool: ...
	@property
	def force_op_size64(self) -> bool: ...
	@property
	def intel_force_op_size64(self) -> bool: ...
	@property
	def must_be_cpl0(self) -> bool: ...
	@property
	def cpl0(self) -> bool: ...
	@property
	def cpl1(self) -> bool: ...
	@property
	def cpl2(self) -> bool: ...
	@property
	def cpl3(self) -> bool: ...
	@property
	def is_input_output(self) -> bool: ...
	@property
	def is_nop(self) -> bool: ...
	@property
	def is_reserved_nop(self) -> bool: ...
	@property
	def is_serializing_intel(self) -> bool: ...
	@property
	def is_serializing_amd(self) -> bool: ...
	@property
	def may_require_cpl0(self) -> bool: ...
	@property
	def is_cet_tracked(self) -> bool: ...
	@property
	def is_non_temporal(self) -> bool: ...
	@property
	def is_fpu_no_wait(self) -> bool: ...
	@property
	def ignores_mod_bits(self) -> bool: ...
	@property
	def no66(self) -> bool: ...
	@property
	def nfx(self) -> bool: ...
	@property
	def requires_unique_reg_nums(self) -> bool: ...
	@property
	def is_privileged(self) -> bool: ...
	@property
	def is_save_restore(self) -> bool: ...
	@property
	def is_stack_instruction(self) -> bool: ...
	@property
	def ignores_segment(self) -> bool: ...
	@property
	def is_op_mask_read_write(self) -> bool: ...
	@property
	def real_mode(self) -> bool: ...
	@property
	def protected_mode(self) -> bool: ...
	@property
	def virtual8086_mode(self) -> bool: ...
	@property
	def compatibility_mode(self) -> bool: ...
	@property
	def long_mode(self) -> bool: ...
	@property
	def use_outside_smm(self) -> bool: ...
	@property
	def use_in_smm(self) -> bool: ...
	@property
	def use_outside_enclave_sgx(self) -> bool: ...
	@property
	def use_in_enclave_sgx1(self) -> bool: ...
	@property
	def use_in_enclave_sgx2(self) -> bool: ...
	@property
	def use_outside_vmx_op(self) -> bool: ...
	@property
	def use_in_vmx_root_op(self) -> bool: ...
	@property
	def use_in_vmx_non_root_op(self) -> bool: ...
	@property
	def use_outside_seam(self) -> bool: ...
	@property
	def use_in_seam(self) -> bool: ...
	@property
	def tdx_non_root_gen_ud(self) -> bool: ...
	@property
	def tdx_non_root_gen_ve(self) -> bool: ...
	@property
	def tdx_non_root_may_gen_ex(self) -> bool: ...
	@property
	def intel_vm_exit(self) -> bool: ...
	@property
	def intel_may_vm_exit(self) -> bool: ...
	@property
	def intel_smm_vm_exit(self) -> bool: ...
	@property
	def amd_vm_exit(self) -> bool: ...
	@property
	def amd_may_vm_exit(self) -> bool: ...
	@property
	def tsx_abort(self) -> bool: ...
	@property
	def tsx_impl_abort(self) -> bool: ...
	@property
	def tsx_may_abort(self) -> bool: ...
	@property
	def intel_decoder16(self) -> bool: ...
	@property
	def intel_decoder32(self) -> bool: ...
	@property
	def intel_decoder64(self) -> bool: ...
	@property
	def amd_decoder16(self) -> bool: ...
	@property
	def amd_decoder32(self) -> bool: ...
	@property
	def amd_decoder64(self) -> bool: ...
	@property
	def decoder_option(self) -> int: ...
	@property
	def table(self) -> int: ...
	@property
	def mandatory_prefix(self) -> int: ...
	@property
	def op_code(self) -> int: ...
	@property
	def op_code_len(self) -> int: ...
	@property
	def is_group(self) -> bool: ...
	@property
	def group_index(self) -> int: ...
	@property
	def is_rm_group(self) -> bool: ...
	@property
	def rm_group_index(self) -> int: ...
	@property
	def op_count(self) -> int: ...
	@property
	def op0_kind(self) -> int: ...
	@property
	def op1_kind(self) -> int: ...
	@property
	def op2_kind(self) -> int: ...
	@property
	def op3_kind(self) -> int: ...
	@property
	def op4_kind(self) -> int: ...
	def op_kind(self, operand: int) -> int: ...
	def op_kinds(self) -> List[OpKind]: ...
	def is_available_in_mode(self, bitness: int) -> bool: ...
	@property
	def op_code_string(self) -> str: ...
	@property
	def instruction_string(self) -> str: ...
	def __repr__(self) -> str: ...
	def __str__(self) -> str: ...
	def __format__(self, format_spec: str) -> str: ...
	def __eq__(self, other: Any) -> bool: ...
	def __ne__(self, other: Any) -> bool: ...
	def __hash__(self) -> int: ...

class ConstantOffsets:
	@property
	def displacement_offset(self) -> int: ...
	@property
	def displacement_size(self) -> int: ...
	@property
	def immediate_offset(self) -> int: ...
	@property
	def immediate_size(self) -> int: ...
	@property
	def immediate_offset2(self) -> int: ...
	@property
	def immediate_size2(self) -> int: ...
	@property
	def has_displacement(self) -> bool: ...
	@property
	def has_immediate(self) -> bool: ...
	@property
	def has_immediate2(self) -> bool: ...
	def __eq__(self, other: Any) -> bool: ...
	def __ne__(self, other: Any) -> bool: ...
	def __hash__(self) -> int: ...

class FpuStackIncrementInfo:
	def __init__(self, increment: int, conditional: bool, writes_top: bool) -> None: ...
	@property
	def increment(self) -> int: ...
	@property
	def conditional(self) -> bool: ...
	@property
	def writes_top(self) -> bool: ...

class Instruction:
	def __len__(self) -> int: ...
	def __init__(self) -> None: ...
	def __copy__(self) -> Instruction: ...
	def __deepcopy__(self, memo: Any) -> Instruction: ...
	def clone(self) -> Instruction: ...
	def eq_all_bits(self, other: Instruction) -> bool: ...
	@property
	def ip16(self) -> int: ...
	@ip16.setter
	def ip16(self, new_value: int) -> None: ...
	@property
	def ip32(self) -> int: ...
	@ip32.setter
	def ip32(self, new_value: int) -> None: ...
	@property
	def ip(self) -> int: ...
	@ip.setter
	def ip(self, new_value: int) -> None: ...
	@property
	def next_ip16(self) -> int: ...
	@next_ip16.setter
	def next_ip16(self, new_value: int) -> None: ...
	@property
	def next_ip32(self) -> int: ...
	@next_ip32.setter
	def next_ip32(self, new_value: int) -> None: ...
	@property
	def next_ip(self) -> int: ...
	@next_ip.setter
	def next_ip(self, new_value: int) -> None: ...
	@property
	def code_size(self) -> CodeSize: ...
	@code_size.setter
	def code_size(self, new_value: CodeSize) -> None: ...
	@property
	def is_invalid(self) -> bool: ...
	@property
	def code(self) -> Code: ...
	@code.setter
	def code(self, new_value: Code) -> None: ...
	@property
	def mnemonic(self) -> Mnemonic: ...
	@property
	def op_count(self) -> int: ...
	@property
	def len(self) -> int: ...
	@len.setter
	def len(self, new_value: int) -> None: ...
	@property
	def has_xacquire_prefix(self) -> bool: ...
	@has_xacquire_prefix.setter
	def has_xacquire_prefix(self, new_value: bool) -> None: ...
	@property
	def has_xrelease_prefix(self) -> bool: ...
	@has_xrelease_prefix.setter
	def has_xrelease_prefix(self, new_value: bool) -> None: ...
	@property
	def has_rep_prefix(self) -> bool: ...
	@has_rep_prefix.setter
	def has_rep_prefix(self, new_value: bool) -> None: ...
	@property
	def has_repe_prefix(self) -> bool: ...
	@has_repe_prefix.setter
	def has_repe_prefix(self, new_value: bool) -> None: ...
	@property
	def has_repne_prefix(self) -> bool: ...
	@has_repne_prefix.setter
	def has_repne_prefix(self, new_value: bool) -> None: ...
	@property
	def has_lock_prefix(self) -> bool: ...
	@has_lock_prefix.setter
	def has_lock_prefix(self, new_value: bool) -> None: ...
	@property
	def op0_kind(self) -> OpKind: ...
	@op0_kind.setter
	def op0_kind(self, new_value: OpKind) -> None: ...
	@property
	def op1_kind(self) -> OpKind: ...
	@op1_kind.setter
	def op1_kind(self, new_value: OpKind) -> None: ...
	@property
	def op2_kind(self) -> OpKind: ...
	@op2_kind.setter
	def op2_kind(self, new_value: OpKind) -> None: ...
	@property
	def op3_kind(self) -> OpKind: ...
	@op3_kind.setter
	def op3_kind(self, new_value: OpKind) -> None: ...
	@property
	def op4_kind(self) -> OpKind: ...
	@op4_kind.setter
	def op4_kind(self, new_value: OpKind) -> None: ...
	def op_kind(self, operand: int) -> OpKind: ...
	def set_op_kind(self, operand: int, op_kind: OpKind) -> None: ...
	@property
	def has_segment_prefix(self) -> bool: ...
	@property
	def segment_prefix(self) -> Register: ...
	@segment_prefix.setter
	def segment_prefix(self, new_value: Register) -> None: ...
	@property
	def memory_segment(self) -> Register: ...
	@property
	def memory_displ_size(self) -> int: ...
	@memory_displ_size.setter
	def memory_displ_size(self, new_value: int) -> None: ...
	@property
	def is_broadcast(self) -> bool: ...
	@is_broadcast.setter
	def is_broadcast(self, new_value: bool) -> None: ...
	@property
	def memory_size(self) -> MemorySize: ...
	@property
	def memory_index_scale(self) -> int: ...
	@memory_index_scale.setter
	def memory_index_scale(self, new_value: int) -> None: ...
	@property
	def memory_displacement(self) -> int: ...
	@memory_displacement.setter
	def memory_displacement(self, new_value: int) -> None: ...
	@property
	def memory_displacement64(self) -> int: ...
	def immediate(self, operand: int) -> int: ...
	def set_immediate_i32(self, operand: int, new_value: int) -> None: ...
	def set_immediate_u32(self, operand: int, new_value: int) -> None: ...
	def set_immediate_i64(self, operand: int, new_value: int) -> None: ...
	def set_immediate_u64(self, operand: int, new_value: int) -> None: ...
	@property
	def immediate8(self) -> int: ...
	@immediate8.setter
	def immediate8(self, new_value: int) -> None: ...
	@property
	def immediate8_2nd(self) -> int: ...
	@immediate8_2nd.setter
	def immediate8_2nd(self, new_value: int) -> None: ...
	@property
	def immediate16(self) -> int: ...
	@immediate16.setter
	def immediate16(self, new_value: int) -> None: ...
	@property
	def immediate32(self) -> int: ...
	@immediate32.setter
	def immediate32(self, new_value: int) -> None: ...
	@property
	def immediate64(self) -> int: ...
	@immediate64.setter
	def immediate64(self, new_value: int) -> None: ...
	@property
	def immediate8to16(self) -> int: ...
	@immediate8to16.setter
	def immediate8to16(self, new_value: int) -> None: ...
	@property
	def immediate8to32(self) -> int: ...
	@immediate8to32.setter
	def immediate8to32(self, new_value: int) -> None: ...
	@property
	def immediate8to64(self) -> int: ...
	@immediate8to64.setter
	def immediate8to64(self, new_value: int) -> None: ...
	@property
	def immediate32to64(self) -> int: ...
	@immediate32to64.setter
	def immediate32to64(self, new_value: int) -> None: ...
	@property
	def memory_address64(self) -> int: ...
	@memory_address64.setter
	def memory_address64(self, new_value: int) -> None: ...
	@property
	def near_branch16(self) -> int: ...
	@near_branch16.setter
	def near_branch16(self, new_value: int) -> None: ...
	@property
	def near_branch32(self) -> int: ...
	@near_branch32.setter
	def near_branch32(self, new_value: int) -> None: ...
	@property
	def near_branch64(self) -> int: ...
	@near_branch64.setter
	def near_branch64(self, new_value: int) -> None: ...
	@property
	def near_branch_target(self) -> int: ...
	@property
	def far_branch16(self) -> int: ...
	@far_branch16.setter
	def far_branch16(self, new_value: int) -> None: ...
	@property
	def far_branch32(self) -> int: ...
	@far_branch32.setter
	def far_branch32(self, new_value: int) -> None: ...
	@property
	def far_branch_selector(self) -> int: ...
	@far_branch_selector.setter
	def far_branch_selector(self, new_value: int) -> None: ...
	@property
	def memory_base(self) -> Register: ...
	@memory_base.setter
	def memory_base(self, new_value: Register) -> None: ...
	@property
	def memory_index(self) -> Register: ...
	@memory_index.setter
	def memory_index(self, new_value: Register) -> None: ...
	@property
	def op0_register(self) -> Register: ...
	@op0_register.setter
	def op0_register(self, new_value: Register) -> None: ...
	@property
	def op1_register(self) -> Register: ...
	@op1_register.setter
	def op1_register(self, new_value: Register) -> None: ...
	@property
	def op2_register(self) -> Register: ...
	@op2_register.setter
	def op2_register(self, new_value: Register) -> None: ...
	@property
	def op3_register(self) -> Register: ...
	@op3_register.setter
	def op3_register(self, new_value: Register) -> None: ...
	@property
	def op4_register(self) -> Register: ...
	@op4_register.setter
	def op4_register(self, new_value: Register) -> None: ...
	def op_register(self, operand: int) -> Register: ...
	def set_op_register(self, operand: int, new_value: Register) -> None: ...
	@property
	def op_mask(self) -> Register: ...
	@op_mask.setter
	def op_mask(self, new_value: Register) -> None: ...
	@property
	def has_op_mask(self) -> bool: ...
	@property
	def zeroing_masking(self) -> bool: ...
	@zeroing_masking.setter
	def zeroing_masking(self, new_value: bool) -> None: ...
	@property
	def merging_masking(self) -> bool: ...
	@merging_masking.setter
	def merging_masking(self, new_value: bool) -> None: ...
	@property
	def rounding_control(self) -> RoundingControl: ...
	@rounding_control.setter
	def rounding_control(self, new_value: RoundingControl) -> None: ...
	@property
	def declare_data_len(self) -> int: ...
	@declare_data_len.setter
	def declare_data_len(self, new_value: int) -> None: ...
	def set_declare_byte_value_i8(self, index: int, new_value: int) -> None: ...
	def set_declare_byte_value(self, index: int, new_value: int) -> None: ...
	def get_declare_byte_value(self, index: int) -> int: ...
	def get_declare_byte_value_i8(self, index: int) -> int: ...
	def set_declare_word_value_i16(self, index: int, new_value: int) -> None: ...
	def set_declare_word_value(self, index: int, new_value: int) -> None: ...
	def get_declare_word_value(self, index: int) -> int: ...
	def get_declare_word_value_i16(self, index: int) -> int: ...
	def set_declare_dword_value_i32(self, index: int, new_value: int) -> None: ...
	def set_declare_dword_value(self, index: int, new_value: int) -> None: ...
	def get_declare_dword_value(self, index: int) -> int: ...
	def get_declare_dword_value_i32(self, index: int) -> int: ...
	def set_declare_qword_value_i64(self, index: int, new_value: int) -> None: ...
	def set_declare_qword_value(self, index: int, new_value: int) -> None: ...
	def get_declare_qword_value(self, index: int) -> int: ...
	def get_declare_qword_value_i64(self, index: int) -> int: ...
	@property
	def is_vsib(self) -> bool: ...
	@property
	def is_vsib32(self) -> bool: ...
	@property
	def is_vsib64(self) -> bool: ...
	@property
	def vsib(self) -> Optional[bool]: ...
	@property
	def suppress_all_exceptions(self) -> bool: ...
	@suppress_all_exceptions.setter
	def suppress_all_exceptions(self, new_value: bool) -> None: ...
	@property
	def is_ip_rel_memory_operand(self) -> bool: ...
	@property
	def ip_rel_memory_address(self) -> int: ...
	def try_virtual_address(self, operand: int, element_index: int) -> Optional[int]: ...
	@property
	def stack_pointer_increment(self) -> int: ...
	def fpu_stack_increment_info(self) -> FpuStackIncrementInfo: ...
	@property
	def encoding(self) -> EncodingKind: ...
	def cpuid_features(self) -> List[CpuidFeature]: ...
	@property
	def flow_control(self) -> FlowControl: ...
	@property
	def is_privileged(self) -> bool: ...
	@property
	def is_stack_instruction(self) -> bool: ...
	@property
	def is_save_restore_instruction(self) -> bool: ...
	@property
	def rflags_read(self) -> int: ...
	@property
	def rflags_written(self) -> int: ...
	@property
	def rflags_cleared(self) -> int: ...
	@property
	def rflags_set(self) -> int: ...
	@property
	def rflags_undefined(self) -> int: ...
	@property
	def rflags_modified(self) -> int: ...
	@property
	def is_jcc_short_or_near(self) -> bool: ...
	@property
	def is_jcc_near(self) -> bool: ...
	@property
	def is_jcc_short(self) -> bool: ...
	@property
	def is_jmp_short(self) -> bool: ...
	@property
	def is_jmp_near(self) -> bool: ...
	@property
	def is_jmp_short_or_near(self) -> bool: ...
	@property
	def is_jmp_far(self) -> bool: ...
	@property
	def is_call_near(self) -> bool: ...
	@property
	def is_call_far(self) -> bool: ...
	@property
	def is_jmp_near_indirect(self) -> bool: ...
	@property
	def is_jmp_far_indirect(self) -> bool: ...
	@property
	def is_call_near_indirect(self) -> bool: ...
	@property
	def is_call_far_indirect(self) -> bool: ...
	def negate_condition_code(self) -> None: ...
	def as_short_branch(self) -> None: ...
	def as_near_branch(self) -> None: ...
	@property
	def condition_code(self) -> ConditionCode: ...
	def op_code(self) -> OpCodeInfo: ...
	def __repr__(self) -> str: ...
	def __str__(self) -> str: ...
	def __format__(self, format_spec: str) -> str: ...
	def __eq__(self, other: Any) -> bool: ...
	def __ne__(self, other: Any) -> bool: ...
	def __hash__(self) -> int: ...
	def __bool__(self) -> bool: ...


class Decoder:
	def __init__(self, bitness: int, data: Union[bytes, bytearray], options: DecoderOptions = DecoderOptions.NONE) -> None: ...
	@property
	def ip(self) -> int: ...
	@ip.setter
	def ip(self, new_value: int) -> None: ...
	@property
	def bitness(self) -> int: ...
	@property
	def max_position(self) -> int: ...
	@property
	def position(self) -> int: ...
	@position.setter
	def position(self, new_pos: int) -> None: ...
	@property
	def can_decode(self) -> bool: ...
	@property
	def last_error(self) -> int: ...
	def decode(self) -> Instruction: ...
	def decode_out(self, instruction: Instruction) -> None: ...
	def get_constant_offsets(self, instruction: Instruction) -> ConstantOffsets: ...
	def __iter__(self) -> Iterator[Instruction]: ...

class Encoder:
	def __init__(self, bitness: int, capacity: int = 0) -> None: ...
	def encode(self, instruction: Instruction, rip: int) -> int: ...
	def write_u8(self, value: int) -> None: ...
	def take_buffer(self) -> bytes: ...
	def get_constant_offsets(self) -> ConstantOffsets: ...
	@property
	def prevent_vex2(self) -> bool: ...
	@prevent_vex2.setter
	def prevent_vex2(self, new_value: bool) -> None: ...
	@property
	def vex_wig(self) -> int: ...
	@vex_wig.setter
	def vex_wig(self, new_value: int) -> None: ...
	@property
	def vex_lig(self) -> int: ...
	@vex_lig.setter
	def vex_lig(self, new_value: int) -> None: ...
	@property
	def evex_wig(self) -> int: ...
	@evex_wig.setter
	def evex_wig(self, new_value: int) -> None: ...
	@property
	def evex_lig(self) -> int: ...
	@evex_lig.setter
	def evex_lig(self, new_value: int) -> None: ...
	@property
	def bitness(self) -> int: ...

class Formatter:
	def __init__(self, syntax: FormatterSyntax) -> None: ...
	def format(self, instruction: Instruction) -> str: ...
	def format_mnemonic(self, instruction: Instruction, options: FormatMnemonicOptions = FormatMnemonicOptions.NONE) -> str: ...
	def operand_count(self, instruction: Instruction) -> int: ...
	def op_access(self, instruction: Instruction, operand: int) -> Optional[OpAccess]: ...
	def get_instruction_operand(self, instruction: Instruction, operand: int) -> Optional[int]: ...
	def get_formatter_operand(self, instruction: Instruction, instruction_operand: int) -> Optional[int]: ...
	def format_operand(self, instruction: Instruction, operand: int) -> str: ...
	def format_operand_separator(self, instruction: Instruction) -> str: ...
	def format_all_operands(self, instruction: Instruction) -> str: ...
	def format_register(self, register: Register) -> str: ...
	def format_i8(self, value: int) -> str: ...
	def format_i16(self, value: int) -> str: ...
	def format_i32(self, value: int) -> str: ...
	def format_i64(self, value: int) -> str: ...
	def format_u8(self, value: int) -> str: ...
	def format_u16(self, value: int) -> str: ...
	def format_u32(self, value: int) -> str: ...
	def format_u64(self, value: int) -> str: ...
	@property
	def uppercase_prefixes(self) -> bool: ...
	@uppercase_prefixes.setter
	def uppercase_prefixes(self, new_value: bool) -> None: ...
	@property
	def uppercase_mnemonics(self) -> bool: ...
	@uppercase_mnemonics.setter
	def uppercase_mnemonics(self, new_value: bool) -> None: ...
	@property
	def uppercase_registers(self) -> bool: ...
	@uppercase_registers.setter
	def uppercase_registers(self, new_value: bool) -> None: ...
	@property
	def uppercase_keywords(self) -> bool: ...
	@uppercase_keywords.setter
	def uppercase_keywords(self, new_value: bool) -> None: ...
	@property
	def uppercase_decorators(self) -> bool: ...
	@uppercase_decorators.setter
	def uppercase_decorators(self, new_value: bool) -> None: ...
	@property
	def uppercase_all(self) -> bool: ...
	@uppercase_all.setter
	def uppercase_all(self, new_value: bool) -> None: ...
	@property
	def first_operand_char_index(self) -> int: ...
	@first_operand_char_index.setter
	def first_operand_char_index(self, new_value: int) -> None: ...
	@property
	def tab_size(self) -> int: ...
	@tab_size.setter
	def tab_size(self, new_value: int) -> None: ...
	@property
	def space_after_operand_separator(self) -> bool: ...
	@space_after_operand_separator.setter
	def space_after_operand_separator(self, new_value: bool) -> None: ...
	@property
	def space_after_memory_bracket(self) -> bool: ...
	@space_after_memory_bracket.setter
	def space_after_memory_bracket(self, new_value: bool) -> None: ...
	@property
	def space_between_memory_add_operators(self) -> bool: ...
	@space_between_memory_add_operators.setter
	def space_between_memory_add_operators(self, new_value: bool) -> None: ...
	@property
	def space_between_memory_mul_operators(self) -> bool: ...
	@space_between_memory_mul_operators.setter
	def space_between_memory_mul_operators(self, new_value: bool) -> None: ...
	@property
	def scale_before_index(self) -> bool: ...
	@scale_before_index.setter
	def scale_before_index(self, new_value: bool) -> None: ...
	@property
	def always_show_scale(self) -> bool: ...
	@always_show_scale.setter
	def always_show_scale(self, new_value: bool) -> None: ...
	@property
	def always_show_segment_register(self) -> bool: ...
	@always_show_segment_register.setter
	def always_show_segment_register(self, new_value: bool) -> None: ...
	@property
	def show_zero_displacements(self) -> bool: ...
	@show_zero_displacements.setter
	def show_zero_displacements(self, new_value: bool) -> None: ...
	@property
	def hex_prefix(self) -> str: ...
	@hex_prefix.setter
	def hex_prefix(self, new_value: str) -> None: ...
	@property
	def hex_suffix(self) -> str: ...
	@hex_suffix.setter
	def hex_suffix(self, new_value: str) -> None: ...
	@property
	def hex_digit_group_size(self) -> int: ...
	@hex_digit_group_size.setter
	def hex_digit_group_size(self, new_value: int) -> None: ...
	@property
	def decimal_prefix(self) -> str: ...
	@decimal_prefix.setter
	def decimal_prefix(self, new_value: str) -> None: ...
	@property
	def decimal_suffix(self) -> str: ...
	@decimal_suffix.setter
	def decimal_suffix(self, new_value: str) -> None: ...
	@property
	def decimal_digit_group_size(self) -> int: ...
	@decimal_digit_group_size.setter
	def decimal_digit_group_size(self, new_value: int) -> None: ...
	@property
	def octal_prefix(self) -> str: ...
	@octal_prefix.setter
	def octal_prefix(self, new_value: str) -> None: ...
	@property
	def octal_suffix(self) -> str: ...
	@octal_suffix.setter
	def octal_suffix(self, new_value: str) -> None: ...
	@property
	def octal_digit_group_size(self) -> int: ...
	@octal_digit_group_size.setter
	def octal_digit_group_size(self, new_value: int) -> None: ...
	@property
	def binary_prefix(self) -> str: ...
	@binary_prefix.setter
	def binary_prefix(self, new_value: str) -> None: ...
	@property
	def binary_suffix(self) -> str: ...
	@binary_suffix.setter
	def binary_suffix(self, new_value: str) -> None: ...
	@property
	def binary_digit_group_size(self) -> int: ...
	@binary_digit_group_size.setter
	def binary_digit_group_size(self, new_value: int) -> None: ...
	@property
	def digit_separator(self) -> str: ...
	@digit_separator.setter
	def digit_separator(self, new_value: str) -> None: ...
	@property
	def leading_zeroes(self) -> bool: ...
	@leading_zeroes.setter
	def leading_zeroes(self, new_value: bool) -> None: ...
	@property
	def uppercase_hex(self) -> bool: ...
	@uppercase_hex.setter
	def uppercase_hex(self, new_value: bool) -> None: ...
	@property
	def small_hex_numbers_in_decimal(self) -> bool: ...
	@small_hex_numbers_in_decimal.setter
	def small_hex_numbers_in_decimal(self, new_value: bool) -> None: ...
	@property
	def add_leading_zero_to_hex_numbers(self) -> bool: ...
	@add_leading_zero_to_hex_numbers.setter
	def add_leading_zero_to_hex_numbers(self, new_value: bool) -> None: ...
	@property
	def number_base(self) -> int: ...
	@number_base.setter
	def number_base(self, new_value: int) -> None: ...
	@property
	def branch_leading_zeroes(self) -> bool: ...
	@branch_leading_zeroes.setter
	def branch_leading_zeroes(self, new_value: bool) -> None: ...
	@property
	def signed_immediate_operands(self) -> bool: ...
	@signed_immediate_operands.setter
	def signed_immediate_operands(self, new_value: bool) -> None: ...
	@property
	def signed_memory_displacements(self) -> bool: ...
	@signed_memory_displacements.setter
	def signed_memory_displacements(self, new_value: bool) -> None: ...
	@property
	def displacement_leading_zeroes(self) -> bool: ...
	@displacement_leading_zeroes.setter
	def displacement_leading_zeroes(self, new_value: bool) -> None: ...
	@property
	def memory_size_options(self) -> MemorySizeOptions: ...
	@memory_size_options.setter
	def memory_size_options(self, new_value: MemorySizeOptions) -> None: ...
	@property
	def rip_relative_addresses(self) -> bool: ...
	@rip_relative_addresses.setter
	def rip_relative_addresses(self, new_value: bool) -> None: ...
	@property
	def show_branch_size(self) -> bool: ...
	@show_branch_size.setter
	def show_branch_size(self, new_value: bool) -> None: ...
	@property
	def use_pseudo_ops(self) -> bool: ...
	@use_pseudo_ops.setter
	def use_pseudo_ops(self, new_value: bool) -> None: ...
	@property
	def show_symbol_address(self) -> bool: ...
	@show_symbol_address.setter
	def show_symbol_address(self, new_value: bool) -> None: ...
	@property
	def gas_naked_registers(self) -> bool: ...
	@gas_naked_registers.setter
	def gas_naked_registers(self, new_value: bool) -> None: ...
	@property
	def gas_show_mnemonic_size_suffix(self) -> bool: ...
	@gas_show_mnemonic_size_suffix.setter
	def gas_show_mnemonic_size_suffix(self, new_value: bool) -> None: ...
	@property
	def gas_space_after_memory_operand_comma(self) -> bool: ...
	@gas_space_after_memory_operand_comma.setter
	def gas_space_after_memory_operand_comma(self, new_value: bool) -> None: ...
	@property
	def masm_add_ds_prefix32(self) -> bool: ...
	@masm_add_ds_prefix32.setter
	def masm_add_ds_prefix32(self, new_value: bool) -> None: ...
	@property
	def masm_symbol_displ_in_brackets(self) -> bool: ...
	@masm_symbol_displ_in_brackets.setter
	def masm_symbol_displ_in_brackets(self, new_value: bool) -> None: ...
	@property
	def masm_displ_in_brackets(self) -> bool: ...
	@masm_displ_in_brackets.setter
	def masm_displ_in_brackets(self, new_value: bool) -> None: ...
	@property
	def nasm_show_sign_extended_immediate_size(self) -> bool: ...
	@nasm_show_sign_extended_immediate_size.setter
	def nasm_show_sign_extended_immediate_size(self, new_value: bool) -> None: ...
	@property
	def prefer_st0(self) -> bool: ...
	@prefer_st0.setter
	def prefer_st0(self, new_value: bool) -> None: ...
	@property
	def show_useless_prefixes(self) -> bool: ...
	@show_useless_prefixes.setter
	def show_useless_prefixes(self, new_value: bool) -> None: ...
	@property
	def cc_b(self) -> CC_b: ...
	@cc_b.setter
	def cc_b(self, new_value: CC_b) -> None: ...
	@property
	def cc_ae(self) -> CC_ae: ...
	@cc_ae.setter
	def cc_ae(self, new_value: CC_ae) -> None: ...
	@property
	def cc_e(self) -> CC_e: ...
	@cc_e.setter
	def cc_e(self, new_value: CC_e) -> None: ...
	@property
	def cc_ne(self) -> CC_ne: ...
	@cc_ne.setter
	def cc_ne(self, new_value: CC_ne) -> None: ...
	@property
	def cc_be(self) -> CC_be: ...
	@cc_be.setter
	def cc_be(self, new_value: CC_be) -> None: ...
	@property
	def cc_a(self) -> CC_a: ...
	@cc_a.setter
	def cc_a(self, new_value: CC_a) -> None: ...
	@property
	def cc_p(self) -> CC_p: ...
	@cc_p.setter
	def cc_p(self, new_value: CC_p) -> None: ...
	@property
	def cc_np(self) -> CC_np: ...
	@cc_np.setter
	def cc_np(self, new_value: CC_np) -> None: ...
	@property
	def cc_l(self) -> CC_l: ...
	@cc_l.setter
	def cc_l(self, new_value: CC_l) -> None: ...
	@property
	def cc_ge(self) -> CC_ge: ...
	@cc_ge.setter
	def cc_ge(self, new_value: CC_ge) -> None: ...
	@property
	def cc_le(self) -> CC_le: ...
	@cc_le.setter
	def cc_le(self, new_value: CC_le) -> None: ...
	@property
	def cc_g(self) -> CC_g: ...
	@cc_g.setter
	def cc_g(self, new_value: CC_g) -> None: ...

class FastFormatter:
	def __init__(self) -> None: ...
	def format(self, instruction: Instruction) -> str: ...
	@property
	def space_after_operand_separator(self) -> bool: ...
	@space_after_operand_separator.setter
	def space_after_operand_separator(self, new_value: bool) -> None: ...
	@property
	def rip_relative_addresses(self) -> bool: ...
	@rip_relative_addresses.setter
	def rip_relative_addresses(self, new_value: bool) -> None: ...
	@property
	def use_pseudo_ops(self) -> bool: ...
	@use_pseudo_ops.setter
	def use_pseudo_ops(self, new_value: bool) -> None: ...
	@property
	def show_symbol_address(self) -> bool: ...
	@show_symbol_address.setter
	def show_symbol_address(self, new_value: bool) -> None: ...
	@property
	def always_show_segment_register(self) -> bool: ...
	@always_show_segment_register.setter
	def always_show_segment_register(self, new_value: bool) -> None: ...
	@property
	def always_show_memory_size(self) -> bool: ...
	@always_show_memory_size.setter
	def always_show_memory_size(self, new_value: bool) -> None: ...
	@property
	def uppercase_hex(self) -> bool: ...
	@uppercase_hex.setter
	def uppercase_hex(self, new_value: bool) -> None: ...
	@property
	def use_hex_prefix(self) -> bool: ...
	@use_hex_prefix.setter
	def use_hex_prefix(self, new_value: bool) -> None: ...

class BlockEncoder:
	def __init__(self, bitness: int, fix_branches: bool = True) -> None: ...
	def add(self, instruction: Instruction) -> None: ...
	def add_many(self, instructions: List[Instruction]) -> None: ...
	def encode(self, rip: int) -> bytes: ...
