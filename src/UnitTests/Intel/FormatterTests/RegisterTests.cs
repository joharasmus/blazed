// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Blazed.Intel;
using Xunit;

namespace UnitTests.Intel.FormatterTests {
	public abstract class RegisterTests {
		protected static IEnumerable<object[]> GetFormatData(string formattedRegistersFile) {
			var formattedRegisters = FileUtils.ReadRawStrings(Path.Combine("Nasm", formattedRegistersFile)).ToArray();
			if (BlazedConstants.RegisterEnumCount != formattedRegisters.Length)
				throw new ArgumentException($"({nameof(BlazedConstants.RegisterEnumCount)}) {BlazedConstants.RegisterEnumCount} != (formattedRegisters.Length) {formattedRegisters.Length}");
			var res = new object[formattedRegisters.Length][];
			for (int i = 0; i < res.Length; i++)
				res[i] = new object[2] { (Register)i, formattedRegisters[i] };
			return res;
		}

		protected void FormatBase(Register register, string formattedString, Formatter formatter) {
			{
				var actualFormattedString = formatter.Format(register);
				Assert.Equal(formattedString, actualFormattedString);
			}
			{
				formatter.Options.UppercaseRegisters = false;
				var actualFormattedString = formatter.Format(register);
				Assert.Equal(formattedString.ToLowerInvariant(), actualFormattedString);
			}
			{
				formatter.Options.UppercaseRegisters = true;
				var actualFormattedString = formatter.Format(register);
				Assert.Equal(formattedString.ToUpperInvariant(), actualFormattedString);
			}
		}
	}
}
