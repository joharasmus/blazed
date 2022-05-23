-- SPDX-License-Identifier: MIT
-- Copyright (C) 2018-present iced project and contributors

local from_hex = require("iced_test_utils").from_hex
local has_int64 = require("iced_test_utils").has_int64

describe("Decoder", function()
	local Code = require("iced_x86.Code")
	local Decoder = require("iced_x86.Decoder")
	local DecoderError = require("iced_x86.DecoderError")
	local DecoderOptions = require("iced_x86.DecoderOptions")
	local Instruction = require("iced_x86.Instruction")

	it("empty ctor", function()
		local decoder = Decoder:new(64, from_hex(""))
		local instr = decoder:decode()
		assert.equals(Code.INVALID, instr:code())
	end)

	it("defaults", function()
		local decoder = Decoder:new(64, from_hex("F390"))
		assert.equals(0, decoder:ip())
		assert.equals(64, decoder:bitness())
		assert.equals(0, decoder:position())
		assert.equals(DecoderError.None, decoder:last_error())
	end)

	it("defaults with ip", function()
		local decoder = Decoder:new(64, from_hex("F390"), nil, 0x12345678)
		assert.equals(0x12345678, decoder:ip())
	end)

	it("defaults with options ip=none", function()
		local decoder = Decoder:new(64, from_hex("F390"), DecoderOptions.NoPause)
		assert.equals(0, decoder:ip())
		local instr = decoder:decode()
		assert.equals(Code.Nopd, instr:code())
	end)

	it("defaults with options ip=nil", function()
		local decoder = Decoder:new(64, from_hex("F390"), DecoderOptions.MPX, nil)
		assert.equals(0, decoder:ip())
		local instr = decoder:decode()
		assert.equals(Code.Pause, instr:code())
	end)

	it("bitness", function()
		for _, bitness in ipairs({ 16, 32, 64 }) do
			local decoder = Decoder:new(bitness, from_hex(""))
			assert.equals(bitness, decoder:bitness())
		end
	end)

	it("invalid bitness", function()
		assert.has_error(function()
			local _ = Decoder:new(1, from_hex(""))
		end)
		assert.has_error(function()
			local _ = Decoder:new(-0x80000001, from_hex(""))
		end)
		assert.has_error(function()
			local _ = Decoder:new(0x100000000, from_hex(""))
		end)
	end)

	it("invalid bytes", function()
		assert.has_error(function()
			local _ = Decoder:new(64, {})
		end)
		assert.has_error(function()
			local _ = Decoder:new(64, true)
		end)
	end)

	it("ip", function()
		local decoder = Decoder:new(64, from_hex("F390"), nil, 0x12345678)
		assert.equals(0x12345678, decoder:ip())
		local _ = decoder:decode()
		assert.equals(0x1234567A, decoder:ip())
		decoder:set_ip(0x456789AB)
		assert.equals(0x456789AB, decoder:ip())
		decoder:set_ip(-0x456789AB)
		assert.equals(-0x456789AB, decoder:ip())
		if has_int64 then
			decoder = Decoder:new(64, from_hex("F390"), nil, 0xFEDCBA987654321F)
			assert.equals(0xFEDCBA987654321F, decoder:ip())
			decoder:set_ip(0xE123456789ABCDF1)
			assert.equals(0xE123456789ABCDF1, decoder:ip())
		end
	end)

	it("position", function()
		local decoder = Decoder:new(64, from_hex("F390" .. "90"), nil, 0x12345678)
		assert.equals(3, decoder:max_position())
		assert.equals(0, decoder:position())
		local _ = decoder:decode()
		assert.equals(2, decoder:position())
		local _ = decoder:decode()
		assert.equals(3, decoder:position())
		local _ = decoder:decode()
		assert.equals(3, decoder:position())
		decoder:set_position(0)
		assert.equals(0, decoder:position())
		decoder:set_position(1)
		assert.equals(1, decoder:position())
		decoder:set_position(3)
		assert.equals(3, decoder:position())
		assert.has_error(function()
			decoder:set_position(-1)
		end)
		assert.has_error(function()
			decoder:set_position(4)
		end)
	end)

	it("can_decode", function()
		local decoder = Decoder:new(64, from_hex("F390" .. "90"), nil, 0x12345678)
		assert.is_true(decoder:can_decode())
		local _ = decoder:decode()
		assert.is_true(decoder:can_decode())
		local _ = decoder:decode()
		assert.is_false(decoder:can_decode())
	end)

	it("last_error", function()
		local decoder = Decoder:new(64, from_hex("F390" .. "90"), nil, 0x12345678)
		assert.equals(DecoderError.None, decoder:last_error())
		local _ = decoder:decode()
		assert.equals(DecoderError.None, decoder:last_error())
		local _ = decoder:decode()
		assert.equals(DecoderError.None, decoder:last_error())
		local _ = decoder:decode()
		assert.equals(DecoderError.NoMoreBytes, decoder:last_error())
	end)

	it("last_error invalid instr", function()
		local decoder = Decoder:new(64, from_hex("F090"), nil, 0x12345678)
		assert.equals(DecoderError.None, decoder:last_error())
		local _ = decoder:decode()
		assert.equals(DecoderError.InvalidInstruction, decoder:last_error())
		local _ = decoder:decode()
		assert.equals(DecoderError.NoMoreBytes, decoder:last_error())
	end)

	it("decode invalid instr option", function()
		local decoder = Decoder:new(64, from_hex("F090"), DecoderOptions.NoInvalidCheck, 0x12345678)
		assert.equals(DecoderError.None, decoder:last_error())
		local _ = decoder:decode()
		assert.equals(DecoderError.None, decoder:last_error())
		local _ = decoder:decode()
		assert.equals(DecoderError.NoMoreBytes, decoder:last_error())
	end)

	it("decode_out", function()
		local decoder = Decoder:new(64, from_hex("F390" .. "90"), nil, 0x12345678)
		local instr = Instruction:new()
		decoder:decode_out(instr)
		assert.equals(Code.Pause, instr:code())
		decoder:decode_out(instr)
		assert.equals(Code.Nopd, instr:code())
		assert.is_false(decoder:can_decode())
	end)

	it("decode_out invalid arg", function()
		assert.has_error(function()
			local decoder = Decoder:new(64, from_hex("F390" .. "90"))
			decoder:decode_out()
		end)
		assert.has_error(function()
			local decoder = Decoder:new(64, from_hex("F390" .. "90"))
			decoder:decode_out(nil)
		end)
		assert.has_error(function()
			local decoder = Decoder:new(64, from_hex("F390" .. "90"))
			decoder:decode_out("hello")
		end)
		assert.has_error(function()
			local decoder = Decoder:new(64, from_hex("F390" .. "90"))
			decoder:decode_out(1)
		end)
		assert.has_error(function()
			local decoder = Decoder:new(64, from_hex("F390" .. "90"))
			decoder:decode_out(decoder)
		end)
	end)

	it("decode iter_out no arg", function()
		local decoder = Decoder:new(64, from_hex("F390" .. "90"), nil, 0x12345678)
		local result = {}
		for instr in decoder:iter_out() do
			result[#result + 1] = instr
		end
		assert.equals(2, #result)
		assert.is_true(result[1]:eq_all_bits(result[2]))
	end)

	it("decode iter_out instr arg", function()
		local decoder = Decoder:new(64, from_hex("F390" .. "90"), nil, 0x12345678)
		local result = {}
		local orig_instr = Instruction:new()
		for instr in decoder:iter_out(orig_instr) do
			assert.is_true(orig_instr:eq_all_bits(instr))
			result[#result + 1] = instr
		end
		assert.equals(2, #result)
		assert.is_true(result[1]:eq_all_bits(result[2]))
	end)

	it("decode in all modes", function()
		local decoder
		local instr

		decoder = Decoder:new(16, from_hex("50"))
		instr = decoder:decode()
		assert.equals(Code.Push_r16, instr:code())

		decoder = Decoder:new(32, from_hex("50"))
		instr = decoder:decode()
		assert.equals(Code.Push_r32, instr:code())

		decoder = Decoder:new(64, from_hex("50"))
		instr = decoder:decode()
		assert.equals(Code.Push_r64, instr:code())
	end)

	it("constant offsets", function()
		local decoder = Decoder:new(64, from_hex("48 1D A55A34A2" .. "90"))
		local instr = decoder:decode()
		local instr2 = decoder:decode()
		local co = decoder:get_constant_offsets(instr)
		local co2 = decoder:get_constant_offsets(instr2)

		assert.equals(0, co:displacement_offset())
		assert.equals(0, co:displacement_size())
		assert.equals(2, co:immediate_offset())
		assert.equals(4, co:immediate_size())
		assert.equals(0, co:immediate_offset2())
		assert.equals(0, co:immediate_size2())
		assert.is_false(co:has_displacement())
		assert.is_true(co:has_immediate())
		assert.is_false(co:has_immediate2())

		local co3 = co:copy()
		assert.is_true(co == co3)
		assert.is_true(co3 == co)
		assert.is_false(co == co2)
	end)
end)
