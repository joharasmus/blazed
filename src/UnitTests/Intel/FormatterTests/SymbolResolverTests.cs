// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using Blazed.Intel;

namespace UnitTests.Intel.FormatterTests {
	public abstract class SymbolResolverTests {
		protected void FormatBase(int index, in SymbolResolverTestCase info, string formattedString, (Formatter formatter, ISymbolResolver symbolResolver) formatterInfo) {
			var infoCopy = info;
			var formatter = formatterInfo.formatter;
			var decoderOptions = OptionsPropsUtils.GetDecoderOptions(infoCopy.Options);
			OptionsPropsUtils.Initialize(formatter.Options, infoCopy.Options);
			FormatterTestUtils.SimpleFormatTest(infoCopy.Bitness, infoCopy.HexBytes, infoCopy.IP, infoCopy.Code, decoderOptions, formattedString,
				formatter, decoder => OptionsPropsUtils.Initialize(decoder, infoCopy.Options));
		}
	}
}
