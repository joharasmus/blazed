// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using Generator.Constants;
using Generator.IO;
using Generator.Tables;

namespace Generator.Decoder.CSharp {
	[Generator(TargetLanguage.CSharp)]
	sealed class CSharpInstructionMemorySizesGenerator {
		readonly GenTypes genTypes;

		public CSharpInstructionMemorySizesGenerator(GeneratorContext generatorContext) {
			genTypes = generatorContext.Types;
		}

		public void Generate() {
			var blazedConstants = genTypes.GetConstantsType(TypeIds.BlazedConstants);
			var defs = genTypes.GetObject<InstructionDefs>(TypeIds.InstructionDefs).Defs;
			const string ClassName = "InstructionMemorySizes";
			using (var writer = new FileWriter(TargetLanguage.CSharp, FileUtils.OpenWrite(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, ClassName + ".g.cs")))) {
				writer.WriteFileHeader();

				writer.WriteLine($"namespace {CSharpConstants.BlazedNamespace} {{");
				using (writer.Indent()) {
					writer.WriteLine($"static class {ClassName} {{");
					using (writer.Indent()) {
						writer.WriteLine($"internal static System.ReadOnlySpan<byte> SizesNormal => new byte[{blazedConstants.Name()}.{blazedConstants[BlazedConstants.GetEnumCountName(TypeIds.Code)].Name()}] {{");
						using (writer.Indent()) {
							foreach (var def in defs) {
								if (def.Memory.Value > byte.MaxValue)
									throw new InvalidOperationException();
								string value;
								if (def.Memory.Value == 0)
									value = "0";
								else
									value = $"(byte){IdentifierConverter.ToDeclTypeAndValue(def.Memory)}";
								writer.WriteLine($"{value},// {def.Code.Name()}");
							}
						}
						writer.WriteLine("};");
						writer.WriteLine();
						writer.WriteLine($"internal static System.ReadOnlySpan<byte> SizesBcst => new byte[{blazedConstants.Name()}.{blazedConstants[BlazedConstants.GetEnumCountName(TypeIds.Code)].Name()}] {{");
						using (writer.Indent()) {
							foreach (var def in defs) {
								if (def.MemoryBroadcast.Value > byte.MaxValue)
									throw new InvalidOperationException();
								string value;
								if (def.MemoryBroadcast.Value == 0)
									value = "0";
								else
									value = $"(byte){IdentifierConverter.ToDeclTypeAndValue(def.MemoryBroadcast)}";
								writer.WriteLine($"{value},// {def.Code.Name()}");
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
