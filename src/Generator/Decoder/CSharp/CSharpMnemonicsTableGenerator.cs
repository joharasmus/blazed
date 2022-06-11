// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using Generator.Constants;
using Generator.IO;
using Generator.Tables;

namespace Generator.Decoder.CSharp {
	[Generator(TargetLanguage.CSharp)]
	sealed class CSharpMnemonicsTableGenerator {
		readonly IdentifierConverter idConverter;
		readonly GenTypes genTypes;

		public CSharpMnemonicsTableGenerator(GeneratorContext generatorContext) {
			idConverter = CSharpIdentifierConverter.Create();
			genTypes = generatorContext.Types;
		}

		public void Generate() {
			var blazedConstants = genTypes.GetConstantsType(TypeIds.BlazedConstants);
			var defs = genTypes.GetObject<InstructionDefs>(TypeIds.InstructionDefs).Defs;
			const string ClassName = "MnemonicUtilsData";
			using (var writer = new FileWriter(TargetLanguage.CSharp, FileUtils.OpenWrite(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, ClassName + ".g.cs")))) {
				writer.WriteFileHeader();

				writer.WriteLine($"namespace {CSharpConstants.BlazedNamespace} {{");
				using (writer.Indent()) {
					writer.WriteLine($"static class {ClassName} {{");
					using (writer.Indent()) {
						writer.WriteLine($"internal static readonly ushort[] toMnemonic = new ushort[{blazedConstants.Name(idConverter)}.{blazedConstants[BlazedConstants.GetEnumCountName(TypeIds.Code)].Name(idConverter)}] {{");
						using (writer.Indent()) {
							foreach (var def in defs) {
								if (def.Mnemonic.Value > ushort.MaxValue)
									throw new InvalidOperationException();
								writer.WriteLine($"(ushort){idConverter.ToDeclTypeAndValue(def.Mnemonic)},// {def.Code.Name(idConverter)}");
							}
						}
						writer.WriteLine("};");
					}
					writer.WriteLine("}");
				}
				writer.WriteLine("}");
			}
		}
	}
}
