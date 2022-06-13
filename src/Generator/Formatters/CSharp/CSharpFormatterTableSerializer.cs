// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using Generator.Enums;
using Generator.IO;

namespace Generator.Formatters.CSharp;

sealed class CSharpFormatterTableSerializer : FormatterTableSerializer {
	readonly string @namespace;

	public CSharpFormatterTableSerializer(FmtInstructionDef[] defs, EnumType ctorKindEnum, string @namespace)
		: base(defs, ctorKindEnum["Previous"]) => this.@namespace = @namespace;

	public override string GetFilename(GenTypes genTypes) =>
		CSharpConstants.GetFilename(genTypes, @namespace, "InstrInfos.g.cs");

	public override void Serialize(GenTypes genTypes, FileWriter writer, StringsTable stringsTable) {
		writer.WriteFileHeader();
		writer.WriteLine($"namespace {@namespace} {{");
		using (writer.Indent()) {
			writer.WriteLine("static partial class InstrInfos {");
			using (writer.Indent()) {
				writer.WriteLine("static System.ReadOnlySpan<byte> GetSerializedInstrInfos() =>");
				using (writer.Indent()) {
					writer.WriteLine("new byte[] {");
					using (writer.Indent())
						SerializeTable(writer, stringsTable);
					writer.WriteLine("};");
				}
			}
			writer.WriteLine("}");
		}
		writer.WriteLine("}");
	}
}
