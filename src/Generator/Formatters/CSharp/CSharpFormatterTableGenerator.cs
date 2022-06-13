// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System.Collections.Generic;
using Generator.IO;

namespace Generator.Formatters.CSharp;

[Generator(TargetLanguage.CSharp)]
sealed class CSharpFormatterTableGenerator {
	readonly GenTypes genTypes;

	public CSharpFormatterTableGenerator(GeneratorContext generatorContext) =>
		genTypes = generatorContext.Types;

	public void Generate() {
		var serializers = new List<IFormatterTableSerializer>();

		if (genTypes.Options.HasNasmFormatter)
			serializers.Add(new CSharpFormatterTableSerializer(genTypes.GetObject<Nasm.CtorInfos>(TypeIds.NasmCtorInfos).Infos, genTypes[TypeIds.NasmCtorKind], CSharpConstants.NasmFormatterDefine, CSharpConstants.NasmFormatterNamespace));

		var stringsTable = new StringsTable();

		foreach (var serializer in serializers)
			serializer.Initialize(genTypes, stringsTable);

		stringsTable.Freeze();

		const string FormatterStringsTableName = "FormatterStringsTable";
		using (var writer = new FileWriter(TargetLanguage.CSharp, FileUtils.OpenWrite(CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, FormatterStringsTableName + ".g.cs")))) {
			var serializer = new CSharpStringsTableSerializer(stringsTable, CSharpConstants.FormatterNamespace, FormatterStringsTableName, CSharpConstants.AnyFormatterDefine);
			serializer.Serialize(writer);
		}

		foreach (var serializer in serializers) {
			using (var writer = new FileWriter(TargetLanguage.CSharp, FileUtils.OpenWrite(serializer.GetFilename(genTypes))))
				serializer.Serialize(genTypes, writer, stringsTable);
		}
	}
}
