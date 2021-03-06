// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using Generator.IO;

namespace Generator.Formatters.CSharp;

struct CSharpStringsTableSerializer {
	readonly StringsTable stringsTable;
	readonly string @namespace;
	readonly string className;

	public CSharpStringsTableSerializer(StringsTable stringsTable, string @namespace, string className) {
		this.stringsTable = stringsTable;
		this.@namespace = @namespace;
		this.className = className;
	}

	public void Serialize(FileWriter writer) {
		if (!stringsTable.IsFrozen)
			throw new InvalidOperationException();

		var sortedInfos = stringsTable.Infos;
		int maxStringLength = 0;
		foreach (var info in sortedInfos)
			maxStringLength = Math.Max(maxStringLength, info.String.Length);

		writer.WriteFileHeader();
		writer.WriteLine($"namespace {@namespace} {{");
		using (writer.Indent()) {
			writer.WriteLine($"static partial class {className} {{");
			using (writer.Indent()) {
				writer.WriteLine($"const int MaxStringLength = {maxStringLength};");
				writer.WriteLine($"const int StringsCount = {sortedInfos.Length};");
				writer.WriteLine("static System.ReadOnlySpan<byte> GetSerializedStrings() =>");
				using (writer.Indent()) {
					writer.WriteLine("new byte[] {");
					using (writer.Indent())
						StringsTableSerializerUtils.SerializeTable(writer, sortedInfos);
					writer.WriteLine("};");
				}
			}
			writer.WriteLine("}");
		}
		writer.WriteLine("}");
	}
}
