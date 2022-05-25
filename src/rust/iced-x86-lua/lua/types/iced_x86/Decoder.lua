-- SPDX-License-Identifier: MIT
-- Copyright (C) 2018-present iced project and contributors

-- ⚠️This file was generated by GENERATOR!🦹‍♂️

---@meta
---@diagnostic disable unused-local

---Decodes 16/32/64-bit x86 instructions
---
---@class Decoder
local Decoder = {}

---Creates a new decoder
---
---@param bitness integer #16, 32 or 64
---@param data string #Data to decode
---@param options? integer #(optional, default = `None`) Decoder options, eg. `DecoderOptions.NoInvalidCheck + DecoderOptions.AMD`
---@param ip? integer #(optional, default = `0`) Address of first decoded instruction
---@return Decoder
---
---# Examples
---
---```lua
---local Decoder = require("iced_x86.Decoder")
---local DecoderOptions = require("iced_x86.DecoderOptions")
---local Code = require("iced_x86.Code")
---local Mnemonic = require("iced_x86.Mnemonic")
---
----- xchg ah,[rdx+rsi+16h]
----- xacquire lock add dword ptr [rax],5Ah
----- vmovdqu64 zmm18{k3}{z},zmm11
---local bytes = "\134\100\050\022\240\242\131\000\090\098\193\254\203\111\211"
---local decoder = Decoder:new(64, bytes, DecoderOptions.None, 0x12345678)
---
---local instr1 = decoder:decode()
---assert(instr1:code() == Code.Xchg_rm8_r8)
---assert(instr1:mnemonic() == Mnemonic.Xchg)
---assert(instr1:len() == 4)
---
---local instr2 = decoder:decode()
---assert(instr2:code() == Code.Add_rm32_imm8)
---assert(instr2:mnemonic() == Mnemonic.Add)
---assert(instr2:len() == 5)
---
---local instr3 = decoder:decode()
---assert(instr3:code() == Code.EVEX_Vmovdqu64_zmm_k1z_zmmm512)
---assert(instr3:mnemonic() == Mnemonic.Vmovdqu64)
---assert(instr3:len() == 6)
---```
---
---It's sometimes useful to decode some invalid instructions, eg. `lock add esi,ecx`.
---Pass in `DecoderOptions.NO_INVALID_CHECK` to the constructor and the decoder
---will decode some invalid encodings.
---
---```lua
---local Decoder = require("iced_x86.Decoder")
---local DecoderOptions = require("iced_x86.DecoderOptions")
---local Code = require("iced_x86.Code")
---
----- lock add esi,ecx    lock not allowed
---local bytes = "\240\001\206"
---local decoder = Decoder:new(64, bytes, DecoderOptions.None, 0x12345678)
---local instr = decoder:decode()
---assert(instr:code() == Code.INVALID)
---
----- We want to decode some instructions with invalid encodings
---local decoder2 = Decoder:new(64, bytes, DecoderOptions.NoInvalidCheck, 0x12345678)
---local instr2 = decoder2:decode()
---assert(instr2:code() == Code.Add_rm32_r32)
---assert(instr2:has_lock_prefix())
---```
function Decoder:new(bitness, data, options, ip) end

---The current `IP`/`EIP`/`RIP` value, see also `Decoder:position()`
---
---@return integer
function Decoder:ip() end

---The current `IP`/`EIP`/`RIP` value, see also `Decoder:position()`
---
---@param ip integer #New value
function Decoder:set_ip(ip) end

---Gets the bitness (16, 32 or 64)
---
---@return integer
function Decoder:bitness() end

---Gets the max value that can be written to `Decoder:position()`
---
---This is the size of the data that gets decoded to instructions and it's the length of the data that was passed to the constructor.
---
---@return integer
function Decoder:max_position() end

---The current data position, which is the index into the data passed to the constructor.
---
---This value is always <= `Decoder:max_position()`. When `Decoder:position()` == `Decoder:max_position()`, it's not possible to decode more
---instructions and `Decoder:can_decode()` returns `false`.
---
---@return integer
---
---# Examples
---
---```lua
---local Decoder = require("iced_x86.Decoder")
---local Code = require("iced_x86.Code")
---
----- nop and pause
---local data = "\144\243\144"
---local decoder = Decoder:new(64, data)
---
---assert(decoder:position() == 0)
---assert(decoder:max_position() == 3)
---local instr = decoder:decode()
---assert(decoder:position() == 1)
---assert(instr:code() == Code.Nopd)
---
---instr = decoder:decode()
---assert(decoder:position() == 3)
---assert(instr:code() == Code.Pause)
---
----- Start all over again
---decoder:set_position(0)
---decoder:set_ip(0)
---assert(decoder:position() == 0)
---assert(decoder:decode():code() == Code.Nopd)
---assert(decoder:decode():code() == Code.Pause)
---assert(decoder:position() == 3)
---```
function Decoder:position() end

---The current data position, which is the index into the data passed to the constructor.
---
---This value is always <= `Decoder:max_position()`. When `Decoder:position()` == `Decoder:max_position()`, it's not possible to decode more
---instructions and `Decoder:can_decode()` returns `false`.
---
---@param pos integer #New value
---
---# Examples
---
---```lua
---local Decoder = require("iced_x86.Decoder")
---local Code = require("iced_x86.Code")
---
----- nop and pause
---local data = "\144\243\144"
---local decoder = Decoder:new(64, data)
---
---assert(decoder:position() == 0)
---assert(decoder:max_position() == 3)
---local instr = decoder:decode()
---assert(decoder:position() == 1)
---assert(instr:code() == Code.Nopd)
---
---instr = decoder:decode()
---assert(decoder:position() == 3)
---assert(instr:code() == Code.Pause)
---
----- Start all over again
---decoder:set_position(0)
---decoder:set_ip(0)
---assert(decoder:position() == 0)
---assert(decoder:decode():code() == Code.Nopd)
---assert(decoder:decode():code() == Code.Pause)
---assert(decoder:position() == 3)
---```
function Decoder:set_position(pos) end

---Returns `true` if there's at least one more byte to decode.
---
---It doesn't verify that the next instruction is valid, it only checks if there's
---at least one more byte to read. See also `Decoder:position()` and `Decoder:max_position()`.
---
---It's not required to call this method. If this method returns `false`, then `Decoder:decode_out()`
---and `Decoder:decode()` will return an instruction whose `Instruction:code()` == `Code.INVALID`.
---
---@return boolean
---
---# Examples
---
---```lua
---local Decoder = require("iced_x86.Decoder")
---local Code = require("iced_x86.Code")
---local DecoderError = require("iced_x86.DecoderError")
---
----- nop and an incomplete instruction
---local data = "\144\243\015"
---local decoder = Decoder:new(64, data)
---
----- 3 bytes left to read
---assert(decoder:can_decode())
---local instr = decoder:decode()
---assert(instr:code() == Code.Nopd)
---
----- 2 bytes left to read
---assert(decoder:can_decode())
---instr = decoder:decode()
----- Not enough bytes left to decode a full instruction
---assert(decoder:last_error() == DecoderError.NoMoreBytes)
---assert(instr:code() == Code.INVALID)
---assert(instr:is_invalid())
---
----- 0 bytes left to read
---assert(not decoder:can_decode())
---```
function Decoder:can_decode() end

---Gets the last decoder error (a `DecoderError` enum value).
---
---Unless you need to know the reason it failed, it's better to check `Instruction:is_invalid()`.
---
---@return integer #`DecoderError` enum value
function Decoder:last_error() end

---Decodes and returns the next instruction.
---
---See also `Decoder:decode_out()` which avoids copying the decoded instruction to the caller's return variable.
---See also `Decoder:last_error()`.
---
---@return Instruction #The next instruction
---
---# Examples
---
---```lua
---local Decoder = require("iced_x86.Decoder")
---local Code = require("iced_x86.Code")
---local Mnemonic = require("iced_x86.Mnemonic")
---local OpKind = require("iced_x86.OpKind")
---local Register = require("iced_x86.Register")
---local MemorySize = require("iced_x86.MemorySize")
---
----- xrelease lock add [rax],ebx
---local data = "\240\243\001\024"
---local decoder = Decoder:new(64, data)
---local instr = decoder:decode()
---
---assert(instr:code() == Code.Add_rm32_r32)
---assert(instr:mnemonic() == Mnemonic.Add)
---assert(instr:len() == 4)
---assert(instr:op_count() == 2)
---
---assert(instr:op0_kind() == OpKind.Memory)
---assert(instr:memory_base() == Register.RAX)
---assert(instr:memory_index() == Register.None)
---assert(instr:memory_index_scale() == 1)
---assert(instr:memory_displacement() == 0)
---assert(instr:memory_segment() == Register.DS)
---assert(instr:segment_prefix() == Register.None)
---assert(instr:memory_size() == MemorySize.UInt32)
---
---assert(instr:op1_kind() == OpKind.Register)
---assert(instr:op1_register() == Register.EBX)
---
---assert(instr:has_lock_prefix())
---assert(instr:has_xrelease_prefix())
---```
function Decoder:decode() end

---Decodes the next instruction. Returns a boolean indicating whether there was at least one
---byte available to read when this method was called.
---
---The difference between this method and `Decoder:decode` is that this method doesn't need to
---allocate a new instruction since it overwrites the input instruction.
---
---@param instr Instruction #Updated with the decoded instruction
---
---# Examples
---
---```lua
---local Decoder = require("iced_x86.Decoder")
---local Instruction = require("iced_x86.Instruction")
---local Code = require("iced_x86.Code")
---local Mnemonic = require("iced_x86.Mnemonic")
---local OpKind = require("iced_x86.OpKind")
---local Register = require("iced_x86.Register")
---local MemorySize = require("iced_x86.MemorySize")
---
----- xrelease lock add [rax],ebx
---local data = "\240\243\001\024"
---local decoder = Decoder:new(64, data)
---local instr = Instruction:new()
---decoder:decode_out(instr)
---
---assert(instr:code() == Code.Add_rm32_r32)
---assert(instr:mnemonic() == Mnemonic.Add)
---assert(instr:len() == 4)
---assert(instr:op_count() == 2)
---
---assert(instr:op0_kind() == OpKind.Memory)
---assert(instr:memory_base() == Register.RAX)
---assert(instr:memory_index() == Register.None)
---assert(instr:memory_index_scale() == 1)
---assert(instr:memory_displacement() == 0)
---assert(instr:memory_segment() == Register.DS)
---assert(instr:segment_prefix() == Register.None)
---assert(instr:memory_size() == MemorySize.UInt32)
---
---assert(instr:op1_kind() == OpKind.Register)
---assert(instr:op1_register() == Register.EBX)
---
---assert(instr:has_lock_prefix())
---assert(instr:has_xrelease_prefix())
---```
function Decoder:decode_out(instr) end

---An iterator that returns the remaining instructions.
---
---The iterator returns the passed in instruction, which gets overwritten with the next
---decoded instruction. If no instruction is passed in, a new one is created and that one
---is returned every iteration.
---
---@param instr? Instruction #(optional) Overwrite this instruction with the new decoded instruction
---
---# Examples
---
---```lua
---local Decoder = require("iced_x86.Decoder")
---local DecoderOptions = require("iced_x86.DecoderOptions")
---
---local bytes = "\134\100\050\022\240\242\131\000\090\098\193\254\203\111\211"
---local decoder = Decoder:new(64, bytes, DecoderOptions.None, 0x12345678)
---
---local instrs = {}
----- This iterator stops when there's nothing left to decode, but the
----- `instr` it returns is always the same instruction instance (for
----- performance)
---for instr in decoder:iter_out() do
---	-- Copy the instruction or we'd store the same instance (overwritten
---	-- each iteartion) instead of a new value.
---	instrs[#instrs + 1] = instr:copy()
---end
---for _, instr in ipairs(instrs) do
---	print(string.format("0x%08X %s", instr:ip(), tostring(instr)))
---end
---
----- Output:
-----     0x12345678 xchg ah,[rdx+rsi+16h]
-----     0x1234567C xacquire lock add dword ptr [rax],5Ah
-----     0x12345681 vmovdqu64 zmm18{k3}{z},zmm11
---```
function Decoder:iter_out(instr) end

---An iterator that decodes and returns the remaining instructions.
---
---This iterator is slower than `iter_out()` because it allocates and returns a new
---instruction. `iter_out()` overwrites the passed in instruction and never allocates.
---
---# Examples
---
---```lua
---local Decoder = require("iced_x86.Decoder")
---local DecoderOptions = require("iced_x86.DecoderOptions")
---
---local bytes = "\134\100\050\022\240\242\131\000\090\098\193\254\203\111\211"
---local decoder = Decoder:new(64, bytes, DecoderOptions.None, 0x12345678)
---
---local instrs = {}
----- Decoder:iter_out() will overwrite the returned instruction
----- instance (for performance reasons) but this slower iterator
----- will always create a new instance.
---for instr in decoder:iter_slow_copy() do
---	instrs[#instrs + 1] = instr
---end
---for _, instr in ipairs(instrs) do
---	print(string.format("0x%08X %s", instr:ip(), tostring(instr)))
---end
---
----- Output:
-----     0x12345678 xchg ah,[rdx+rsi+16h]
-----     0x1234567C xacquire lock add dword ptr [rax],5Ah
-----     0x12345681 vmovdqu64 zmm18{k3}{z},zmm11
---```
function Decoder:iter_slow_copy() end

---Gets the offsets of the constants (memory displacement and immediate) in the decoded instruction.
---
---The caller can check if there are any relocations at those addresses.
---
---@param instr Instruction #The latest instruction that was decoded by this decoder
---@return ConstantOffsets #Offsets and sizes of immediates
---
---# Examples
---
---```lua
---local Code = require("iced_x86.Code")
---local Decoder = require("iced_x86.Decoder")
---
----- nop
----- xor dword ptr [rax-5AA5EDCCh],5Ah
-----                  00  01  02  03  04  05  06
-----                \opc\mrm\displacement___\imm
---local data = "\144\131\179\052\018\090\165\090"
---local decoder = Decoder:new(64, data, nil, 0x12345678)
---assert(decoder:decode():code() == Code.Nopd)
---local instr = decoder:decode()
---local co = decoder:get_constant_offsets(instr)
---
---assert(co:has_displacement())
---assert(co:displacement_offset() == 2)
---assert(co:displacement_size() == 4)
---assert(co:has_immediate())
---assert(co:immediate_offset() == 6)
---assert(co:immediate_size() == 1)
----- It's not an instruction with two immediates (e.g. enter)
---assert(not co:has_immediate2())
---assert(co:immediate_offset2() == 0)
---assert(co:immediate_size2() == 0)
---```
function Decoder:get_constant_offsets(instr) end

return Decoder
