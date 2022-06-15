// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Linq;
using Generator.Enums;
using Generator.Enums.CSharp;
using Generator.IO;
using Generator.Tables;

namespace Generator.Encoder.CSharp;

[Generator(TargetLanguage.CSharp)]
sealed class CSharpEncoderGenerator : EncoderGenerator {
	readonly CSharpEnumsGenerator enumGenerator;

	public CSharpEncoderGenerator(GeneratorContext generatorContext)
		: base(generatorContext.Types) => enumGenerator = new CSharpEnumsGenerator(generatorContext);

	protected override void Generate(EnumType enumType) => enumGenerator.Generate(enumType);

	protected override void Generate(OpCodeHandlers handlers) {
		GenerateOpCodeOperandKindTables(handlers);
		GenerateOpTables(handlers);
	}

	void GenerateOpCodeOperandKindTables(OpCodeHandlers handlers) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "OpCodeOperandKinds.g.cs");
		using (var writer = new FileWriter(TargetLanguage.CSharp, FileUtils.OpenWrite(filename))) {
			writer.WriteFileHeader();
			writer.WriteLineNoIndent($"#if {CSharpConstants.OpCodeInfoDefine}");

			writer.WriteLine($"namespace {CSharpConstants.EncoderNamespace} {{");
			using (writer.Indent()) {
				writer.WriteLine("static class OpCodeOperandKinds {");
				using (writer.Indent()) {
					Generate(writer, "LegacyOpKinds", null, handlers.Legacy);
					Generate(writer, "VexOpKinds", CSharpConstants.VexDefine, handlers.Vex);
					Generate(writer, "XopOpKinds", CSharpConstants.XopDefine, handlers.Xop);
					Generate(writer, "EvexOpKinds", CSharpConstants.EvexDefine, handlers.Evex);
				}
				writer.WriteLine("}");
			}
			writer.WriteLine("}");
			writer.WriteLineNoIndent("#endif");
		}

		void Generate(FileWriter writer, string name, string? define, (EnumValue opCodeOperandKind, OpHandlerKind opHandlerKind, object[] args)[] table) {
			if (define is not null)
				writer.WriteLineNoIndent($"#if {define}");
			writer.WriteLine($"public static System.ReadOnlySpan<byte> {name} => new byte[{table.Length}] {{");
			using (writer.Indent()) {
				foreach (var info in table)
					writer.WriteLine($"(byte){IdentifierConverter.ToDeclTypeAndValue(info.opCodeOperandKind)},");
			}
			writer.WriteLine("};");
			if (define is not null)
				writer.WriteLineNoIndent("#endif");
		}
	}

	void GenerateOpTables(OpCodeHandlers handlers) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "OpTables.g.cs");
		using (var writer = new FileWriter(TargetLanguage.CSharp, FileUtils.OpenWrite(filename))) {
			writer.WriteFileHeader();
			writer.WriteLineNoIndent($"#if {CSharpConstants.EncoderDefine}");

			writer.WriteLine($"namespace {CSharpConstants.EncoderNamespace} {{");
			using (writer.Indent()) {
				writer.WriteLine("static class OpHandlerData {");
				using (writer.Indent()) {
					Generate(writer, "LegacyOps", null, handlers.Legacy);
					Generate(writer, "VexOps", CSharpConstants.VexDefine, handlers.Vex);
					Generate(writer, "XopOps", CSharpConstants.XopDefine, handlers.Xop);
					Generate(writer, "EvexOps", CSharpConstants.EvexDefine, handlers.Evex);
				}
				writer.WriteLine("}");
			}
			writer.WriteLine("}");
			writer.WriteLineNoIndent("#endif");
		}

		void Generate(FileWriter writer, string name, string? define, (EnumValue opCodeOperandKind, OpHandlerKind opHandlerKind, object[] args)[] table) {
			var declTypeStr = genTypes[TypeIds.OpCodeOperandKind].Name();
			if (table[0].opHandlerKind != OpHandlerKind.None)
				throw new InvalidOperationException();
			if (define is not null)
				writer.WriteLineNoIndent($"#if {define}");
			writer.WriteLine($"public static readonly Op[] {name} = new Op[{table.Length - 1}] {{");
			using (writer.Indent()) {
				for (int i = 1; i < table.Length; i++) {
					var info = table[i];
					writer.Write("new ");
					writer.Write(info.opHandlerKind.ToString());
					writer.Write("(");
					var ctorArgs = info.args;
					for (int j = 0; j < ctorArgs.Length; j++) {
						if (j > 0)
							writer.Write(", ");
						switch (ctorArgs[j]) {
						case EnumValue value:
							writer.Write(IdentifierConverter.ToDeclTypeAndValue(value));
							break;
						case int value:
							writer.Write(value.ToString());
							break;
						case bool value:
							writer.Write(value ? "true" : "false");
							break;
						default:
							throw new InvalidOperationException();
						}
					}
					writer.WriteLine("),");
				}
			}
			writer.WriteLine("};");
			if (define is not null)
				writer.WriteLineNoIndent("#endif");
		}
	}

	protected override void GenerateOpCodeInfo(InstructionDef[] defs) {
		var allData = GetData(defs).ToArray();
		var encFlags1 = allData.Select(a => (a.def, a.encFlags1)).ToArray();
		var encFlags2 = allData.Select(a => (a.def, a.encFlags2)).ToArray();
		var encFlags3 = allData.Select(a => (a.def, a.encFlags3)).ToArray();
		var opcFlags1 = allData.Select(a => (a.def, a.opcFlags1)).ToArray();
		var opcFlags2 = allData.Select(a => (a.def, a.opcFlags2)).ToArray();

		var encoderInfo = new (string name, (InstructionDef def, uint value)[] values)[] {
			("EncFlags1", encFlags1),
			("EncFlags2", encFlags2),
			("EncFlags3", encFlags3),
		};
		var opCodeInfo = new (string name, (InstructionDef def, uint value)[] values)[] {
			("OpcFlags1", opcFlags1),
			("OpcFlags2", opcFlags2),
		};

		GenerateTables(defs, encoderInfo, CSharpConstants.EncoderDefine, "EncoderData", "EncoderData.g.cs");
		GenerateTables(defs, opCodeInfo, CSharpConstants.OpCodeInfoDefine, "OpCodeInfoData", "OpCodeInfoData.g.cs");
	}

	void GenerateTables(InstructionDef[] defs, (string name, (InstructionDef def, uint value)[] values)[] tableData, string define, string className, string filename) {
		var fullFilename = CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, filename);
		using (var writer = new FileWriter(TargetLanguage.CSharp, FileUtils.OpenWrite(fullFilename))) {
			writer.WriteFileHeader();
			writer.WriteLineNoIndent($"#if {define}");
			writer.WriteLine($"namespace {CSharpConstants.EncoderNamespace} {{");
			using (writer.Indent()) {
				writer.WriteLine($"static class {className} {{");
				using (writer.Indent()) {
					foreach (var info in tableData)
						writer.WriteLine($"internal static readonly uint[] {info.name} = Get{info.name}();");
					foreach (var info in tableData) {
						writer.WriteLine();
						writer.WriteLine($"static uint[] Get{info.name}() =>");
						using (writer.Indent()) {
							writer.WriteLine($"new uint[{defs.Length}] {{");
							using (writer.Indent()) {
								foreach (var vinfo in info.values)
									writer.WriteLine($"0x{vinfo.value:X8},// {vinfo.def.Code.Name()}");
							}
							writer.WriteLine("};");
						}
					}
				}
				writer.WriteLine("}");
			}
			writer.WriteLine("}");
			writer.WriteLineNoIndent("#endif");
		}
	}

	protected override void Generate((EnumValue value, uint size)[] immSizes) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "Encoder.cs");
		new FileUpdater(TargetLanguage.CSharp, "ImmSizes", filename).Generate(writer => {
			writer.WriteLine($"static readonly uint[] s_immSizes = new uint[{immSizes.Length}] {{");
			using (writer.Indent()) {
				foreach (var info in immSizes)
					writer.WriteLine($"{info.size},// {info.value.Name()}");
			}
			writer.WriteLine("};");
		});
	}

	void GenerateCases(string filename, string id, EnumValue[] codeValues, params string[] statements) =>
		new FileUpdater(TargetLanguage.CSharp, id, filename).Generate(writer => {
			if (codeValues.Length == 0)
				return;
			foreach (var value in codeValues)
				writer.WriteLine($"case {IdentifierConverter.ToDeclTypeAndValue(value)}:");
			using (writer.Indent()) {
				foreach (var statement in statements)
					writer.WriteLine(statement);
				if (!statements[^1].StartsWith("return ", StringComparison.Ordinal))
					writer.WriteLine("break;");
			}
		});

	void GenerateNotInstrCases(string filename, string id, (EnumValue code, string result)[] notInstrStrings) =>
		new FileUpdater(TargetLanguage.CSharp, id, filename).Generate(writer => {
			foreach (var info in notInstrStrings)
				writer.WriteLine($"{IdentifierConverter.ToDeclTypeAndValue(info.code)} => \"{info.result}\",");
		});

	protected override void GenerateInstructionFormatter((EnumValue code, string result)[] notInstrStrings) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "InstructionFormatter.cs");
		GenerateNotInstrCases(filename, "InstrFmtNotInstructionString", notInstrStrings);
	}

	protected override void GenerateOpCodeFormatter((EnumValue code, string result)[] notInstrStrings, EnumValue[] hasModRM, EnumValue[] hasVsib) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "OpCodeFormatter.cs");
		GenerateNotInstrCases(filename, "OpCodeFmtNotInstructionString", notInstrStrings);
		GenerateCases(filename, "HasModRM", hasModRM, "return true;");
		GenerateCases(filename, "HasVsib", hasVsib, "return true;");
	}

	protected override void GenerateCore() {
	}

	protected override void GenerateInstrSwitch(EnumValue[] jccInstr, EnumValue[] simpleBranchInstr, EnumValue[] callInstr, EnumValue[] jmpInstr, EnumValue[] xbeginInstr) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.BlockEncoderNamespace, "Instr.cs");
		GenerateCases(filename, "JccInstr", jccInstr, "return new JccInstr(blockEncoder, block, instruction);");
		GenerateCases(filename, "SimpleBranchInstr", simpleBranchInstr, "return new SimpleBranchInstr(blockEncoder, block, instruction);");
		GenerateCases(filename, "CallInstr", callInstr, "return new CallInstr(blockEncoder, block, instruction);");
		GenerateCases(filename, "JmpInstr", jmpInstr, "return new JmpInstr(blockEncoder, block, instruction);");
		GenerateCases(filename, "XbeginInstr", xbeginInstr, "return new XbeginInstr(blockEncoder, block, instruction);");
	}

	protected override void GenerateVsib(EnumValue[] vsib32, EnumValue[] vsib64) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "Instruction.cs");
		GenerateCases(filename, "Vsib32", vsib32, "vsib64 = false;", "return true;");
		GenerateCases(filename, "Vsib64", vsib64, "vsib64 = true;", "return true;");
	}

	protected override void GenerateDecoderOptionsTable((EnumValue decOptionValue, EnumValue decoderOptions)[] values) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "OpCodeInfo.cs");
		new FileUpdater(TargetLanguage.CSharp, "ToDecoderOptionsTable", filename).Generate(writer => {
			foreach (var (_, decoderOptions) in values)
				writer.WriteLine($"{IdentifierConverter.ToDeclTypeAndValue(decoderOptions)},");
		});
	}

	protected override void GenerateImpliedOps((EncodingKind Encoding, InstrStrImpliedOp[] Ops, InstructionDef[] defs)[] impliedOpsInfo) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "InstructionFormatter.cs");
		new FileUpdater(TargetLanguage.CSharp, "PrintImpliedOps", filename).Generate(writer => {
			foreach (var info in impliedOpsInfo) {
				var feature = CSharpConstants.GetDefine(info.Encoding);
				if (feature is not null)
					writer.WriteLineNoIndent($"#if {feature}");
				foreach (var def in info.defs)
					writer.WriteLine($"case {IdentifierConverter.ToDeclTypeAndValue(def.Code)}:");
				using (writer.Indent()) {
					foreach (var op in info.Ops) {
						writer.WriteLine("WriteOpSeparator();");
						writer.WriteLine($"Write(\"{op.Operand}\", upper: {(op.IsUpper ? "true" : "false")});");
					}
					writer.WriteLine("break;");
				}
				if (feature is not null)
					writer.WriteLineNoIndent("#endif");
			}
		});
	}
}
