// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using Blazed.Intel;

namespace UnitTests.Intel.FormatterTests {
	static class FormatterFactory {
		static FormatterOptions CreateOptions() {
			var options = FormatterOptions.CreateFormatterOptions();
			options.UppercaseHex = false;
			options.HexPrefix = "0x";
			options.HexSuffix = null;
			options.OctalPrefix = "0o";
			options.OctalSuffix = null;
			options.BinaryPrefix = "0b";
			options.BinarySuffix = null;
			return options;
		}

		public static Formatter Create_MemDefault() {
			var options = CreateOptions();
			options.MemorySizeOptions = MemorySizeOptions.Default;
			options.ShowSignExtendedImmediateSize = true;
			options.ShowBranchSize = false;
			options.RipRelativeAddresses = true;
			options.SignedImmediateOperands = false;
			options.SpaceAfterOperandSeparator = false;
			return new Formatter(options);
		}

		public static Formatter Create_MemAlways() {
			var options = CreateOptions();
			options.MemorySizeOptions = MemorySizeOptions.Always;
			options.ShowSignExtendedImmediateSize = true;
			options.ShowBranchSize = true;
			options.RipRelativeAddresses = false;
			options.SignedImmediateOperands = true;
			options.SpaceAfterOperandSeparator = true;
			return new Formatter(options);
		}

		public static Formatter Create_MemMinimum() {
			var options = CreateOptions();
			options.MemorySizeOptions = MemorySizeOptions.Minimal;
			options.ShowSignExtendedImmediateSize = true;
			options.ShowBranchSize = true;
			options.RipRelativeAddresses = false;
			options.SignedImmediateOperands = true;
			options.SpaceAfterOperandSeparator = true;
			return new Formatter(options);
		}

		public static Formatter Create() {
			var options = CreateOptions();
			options.MemorySizeOptions = MemorySizeOptions.Default;
			options.ShowSignExtendedImmediateSize = true;
			options.ShowBranchSize = false;
			options.RipRelativeAddresses = true;
			return new Formatter(options);
		}

		public static Formatter Create_Options() {
			var options = CreateOptions();
			options.MemorySizeOptions = MemorySizeOptions.Default;
			options.ShowSignExtendedImmediateSize = false;
			options.ShowBranchSize = false;
			options.RipRelativeAddresses = true;
			return new Formatter(options);
		}

		public static Formatter Create_Registers() {
			var options = CreateOptions();
			return new Formatter(options);
		}

		public static Formatter Create_Numbers() {
			var options = CreateOptions();
			options.UppercaseHex = true;
			options.HexPrefix = null;
			options.HexSuffix = null;
			options.OctalPrefix = null;
			options.OctalSuffix = null;
			options.BinaryPrefix = null;
			options.BinarySuffix = null;
			return new Formatter(options);
		}

		public static (Formatter formatter, ISymbolResolver symbolResolver) Create_Resolver(ISymbolResolver symbolResolver) {
			var options = CreateOptions();
			options.MemorySizeOptions = MemorySizeOptions.Default;
			options.ShowSignExtendedImmediateSize = false;
			options.ShowBranchSize = false;
			options.RipRelativeAddresses = true;
			return (new Formatter(options, symbolResolver), symbolResolver);
		}
	}
}
