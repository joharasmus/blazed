// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System.IO;
using System.Text;

namespace Generator.IO;

static class FileUtils {
	public static readonly Encoding FileEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

	// Since we do this frequently, the file may not be released by the process
	// This forces it to keep trying until it can succeed
	// ...yes, I know - this is nasty
	public static StreamWriter OpenWrite(string filename) {
		while (true){
			try {
				return new(filename, append: false, FileEncoding);
			}
			catch (IOException) {
				continue;
			}
		}
	}
}
