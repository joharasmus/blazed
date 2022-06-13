// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Text;
using Generator.Constants;
using Generator.Enums;
using Generator.IO;
using Generator.Tables;

namespace Generator.Formatters.CSharp;

[Generator(TargetLanguage.CSharp)]
sealed class CSharpTableGen : TableGen {

	public CSharpTableGen(GeneratorContext generatorContext)
		: base(generatorContext.Types) { }

	protected override void Generate(MemorySizeDef[] defs) {
		GenerateNasm(defs);
	}

	void GenerateNasm(MemorySizeDef[] defs) {
		var blazedConstants = genTypes.GetConstantsType(TypeIds.BlazedConstants);
		var broadcastToKindValues = genTypes[TypeIds.BroadcastToKind].Values;
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.NasmFormatterNamespace, "MemorySizes.cs");
		var nasmKeywords = genTypes[TypeIds.NasmMemoryKeywords].Values;
		new FileUpdater(TargetLanguage.CSharp, "ConstData", filename).Generate(writer => {
			foreach (var kw in nasmKeywords) {
				if ((NasmMemoryKeywords)kw.Value == NasmMemoryKeywords.None)
					continue;
				writer.WriteLine($"var {EscapeKeyword(kw.RawName)} = new FormatterString(\"{kw.RawName}\");");
			}
			foreach (var bcst in broadcastToKindValues) {
				if ((BroadcastToKind)bcst.Value == BroadcastToKind.None)
					writer.WriteLine($"var empty = new FormatterString(\"\");");
				else {
					var name = bcst.RawName;
					if (!name.StartsWith("b", StringComparison.Ordinal))
						throw new InvalidOperationException();
					var s = name[1..];
					writer.WriteLine($"var {name} = new FormatterString(\"{s}\");");
				}
			}
		});
		new FileUpdater(TargetLanguage.CSharp, "MemorySizes", filename).Generate(writer => {
			foreach (var def in defs) {
				writer.WriteByte(checked((byte)def.Nasm.Value));
				writer.WriteLine();
			}
		});
		new FileUpdater(TargetLanguage.CSharp, "BcstTo", filename).Generate(writer => {
			int first = (int)blazedConstants[BlazedConstants.FirstBroadcastMemorySizeName].ValueUInt64;
			for (int i = first; i < defs.Length; i++) {
				writer.WriteByte(checked((byte)defs[i].BroadcastToKind.Value));
				writer.WriteLine();
			}
		});
		new FileUpdater(TargetLanguage.CSharp, "MemoryKeywordsSwitch", filename).Generate(writer => {
			foreach (var kw in nasmKeywords) {
				writer.Write($"0x{kw.Value:X2} => ");
				if ((NasmMemoryKeywords)kw.Value == NasmMemoryKeywords.None)
					writer.WriteLine("empty,");
				else
					writer.WriteLine($"{EscapeKeyword(kw.RawName)},");
			}
		});
		new FileUpdater(TargetLanguage.CSharp, "BroadcastToKindSwitch", filename).Generate(writer => {
			foreach (var bcst in broadcastToKindValues) {
				writer.Write($"0x{bcst.Value:X2} => ");
				if ((BroadcastToKind)bcst.Value == BroadcastToKind.None)
					writer.WriteLine("empty,");
				else
					writer.WriteLine($"{bcst.RawName},");
			}
		});
	}

	static string EscapeKeyword(string s) => s == "byte" ? "@" + s : s;

	protected override void GenerateRegisters(string[] registers) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "RegistersTable.cs");
		new FileUpdater(TargetLanguage.CSharp, "Registers", filename).Generate(writer => {
			writer.WriteLine("static ReadOnlySpan<byte> GetRegistersData() =>");
			int maxLen = 0;
			using (writer.Indent()) {
				writer.WriteLine("new byte[] {");
				using (writer.Indent()) {
					foreach (var register in registers) {
						maxLen = Math.Max(maxLen, register.Length);
						var bytes = Encoding.UTF8.GetBytes(register);
						writer.Write($"0x{bytes.Length:X2}");
						foreach (var b in bytes)
							writer.Write($", 0x{b:X2}");
						writer.Write(",");
						writer.WriteCommentLine(register);
					}
				}
				writer.WriteLine("};");
			}
			writer.WriteLine($"const int MaxStringLength = {maxLen};");
		});
	}

	protected override void GenerateFormatterFlowControl((EnumValue flowCtrl, EnumValue[] code)[] infos) {
		var filename = CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "FormatterUtils.cs");
		new FileUpdater(TargetLanguage.CSharp, "FormatterFlowControlSwitch", filename).Generate(writer => {
			foreach (var info in infos) {
				if (info.code.Length == 0)
					continue;
				foreach (var c in info.code)
					writer.WriteLine($"case {IdentifierConverter.ToDeclTypeAndValue(c)}:");
				using (writer.Indent())
					writer.WriteLine($"return {IdentifierConverter.ToDeclTypeAndValue(info.flowCtrl)};");
			}
		});
	}
}
