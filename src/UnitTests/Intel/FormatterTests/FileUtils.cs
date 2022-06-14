// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System.Collections.Generic;
using System.IO;

namespace UnitTests.Intel.FormatterTests {
	static class FileUtils {
		public static string GetFormatterFilename(string filename) =>
			PathUtils.GetTestTextFilename(filename + ".txt", "Formatter");

		public static IEnumerable<string> ReadRawStrings(string filename) {
			foreach (var line in File.ReadLines(GetFormatterFilename(filename))) {
				if (line.Length == 0 || line[0] == '#')
					continue;
				yield return line;
			}
		}
	}
}
