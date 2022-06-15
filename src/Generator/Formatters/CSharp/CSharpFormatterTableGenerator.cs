// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using Generator.IO;

namespace Generator.Formatters.CSharp;

[Generator(TargetLanguage.CSharp)]
sealed class CSharpFormatterTableGenerator {
	readonly GenTypes genTypes;

	public CSharpFormatterTableGenerator(GeneratorContext generatorContext) =>
		genTypes = generatorContext.Types;

	public void Generate() {

		var cSharpSerializer = new CSharpFormatterTableSerializer(
			genTypes.GetObject<CtorInfos>(TypeIds.CtorInfos).Infos,
			genTypes[TypeIds.CtorKind],
			CSharpConstants.FormatterNamespace);

		var stringsTable = new StringsTable();

		cSharpSerializer.Initialize(genTypes, stringsTable);

		stringsTable.Freeze();

		const string FormatterStringsTableName = "FormatterStringsTable";
		using (var writer = new FileWriter(TargetLanguage.CSharp, FileUtils.OpenWrite(CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, FormatterStringsTableName + ".g.cs")))) {
			var serializer = new CSharpStringsTableSerializer(stringsTable, CSharpConstants.FormatterNamespace, FormatterStringsTableName);
			serializer.Serialize(writer);
		}

		using (var writer = new FileWriter(TargetLanguage.CSharp, FileUtils.OpenWrite(cSharpSerializer.GetFilename(genTypes))))
			cSharpSerializer.Serialize(genTypes, writer, stringsTable);
	}
}
