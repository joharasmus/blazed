// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTests.Intel.FormatterTests {
	static class OptionsTestsUtils {
		public static IEnumerable<object[]> GetFormatData_Common(string formattedStringsFile) {
			var (infos, ignored) = FormatterOptionsTests.CommonInfos;
			return GetFormatData(formattedStringsFile, infos, ignored);
		}

		public static IEnumerable<object[]> GetFormatData_All(string formattedStringsFile) {
			var (infos, ignored) = FormatterOptionsTests.AllInfos;
			return GetFormatData(formattedStringsFile, infos, ignored);
		}

		public static IEnumerable<object[]> GetFormatData(string formattedStringsFile, string optionsFile) {
			var infosFilename = FileUtils.GetFormatterFilename(Path.Combine("Nasm", optionsFile));
			var ignored = new HashSet<int>();
			var infos = OptionsTestsReader.ReadFile(infosFilename, ignored).ToArray();
			return GetFormatData(formattedStringsFile, infos, ignored);
		}

		static IEnumerable<object[]> GetFormatData(string formattedStringsFile, OptionsInstructionInfo[] infos, HashSet<int> ignored) {
			var formattedStrings = FileUtils.ReadRawStrings(Path.Combine("Nasm", formattedStringsFile)).ToArray();
			formattedStrings = Utils.Filter(formattedStrings, ignored);
			if (infos.Length != formattedStrings.Length)
				throw new ArgumentException($"(infos.Length) {infos.Length} != (formattedStrings.Length) {formattedStrings.Length} . infos[0].HexBytes = {(infos.Length == 0 ? "<EMPTY>" : infos[0].HexBytes)} & formattedStrings[0] = {(formattedStrings.Length == 0 ? "<EMPTY>" : formattedStrings[0])}");
			var res = new object[infos.Length][];
			for (int i = 0; i < infos.Length; i++)
				res[i] = new object[3] { i, infos[i], formattedStrings[i] };
			return res;
		}
	}
}
