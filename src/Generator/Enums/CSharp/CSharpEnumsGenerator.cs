// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System.Collections.Generic;
using Generator.Documentation;
using Generator.Documentation.CSharp;
using Generator.IO;

namespace Generator.Enums.CSharp;

[Generator(TargetLanguage.CSharp)]
sealed class CSharpEnumsGenerator : EnumsGenerator {
	readonly Dictionary<TypeId, FullEnumFileInfo?> toFullFileInfo;
	readonly Dictionary<TypeId, PartialEnumFileInfo?> toPartialFileInfo;
	readonly CSharpDocCommentWriter docWriter;
	readonly DeprecatedWriter deprecatedWriter;

	sealed class FullEnumFileInfo {
		public readonly string Filename;
		public readonly string Namespace;
		public readonly string? Define;
		public readonly string? BaseType;

		public FullEnumFileInfo(string filename, string @namespace, string? define = null, string? baseType = null) {
			Filename = filename;
			Namespace = @namespace;
			Define = define;
			BaseType = baseType;
		}
	}

	sealed class PartialEnumFileInfo {
		public readonly string Id;
		public readonly string Filename;
		public readonly string? BaseType;

		public PartialEnumFileInfo(string id, string filename, string? baseType) {
			Id = id;
			Filename = filename;
			BaseType = baseType;
		}
	}

	public CSharpEnumsGenerator(GeneratorContext generatorContext)
		: base(generatorContext.Types) {
		docWriter = new CSharpDocCommentWriter();
		deprecatedWriter = new DeprecatedWriter();

		var dirs = genTypes.Dirs;
		toFullFileInfo = new();
		toFullFileInfo.Add(TypeIds.Code, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.Code) + ".g.cs"), CSharpConstants.BlazedNamespace));
		toFullFileInfo.Add(TypeIds.CodeSize, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.CodeSize) + ".g.cs"), CSharpConstants.BlazedNamespace));
		toFullFileInfo.Add(TypeIds.ConditionCode, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.ConditionCode) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.InstructionInfoDefine));
		toFullFileInfo.Add(TypeIds.CpuidFeature, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.CpuidFeature) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.InstructionInfoDefine));
		toFullFileInfo.Add(TypeIds.CpuidFeatureInternal, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.InstructionInfoNamespace, nameof(TypeIds.CpuidFeatureInternal) + ".g.cs"), CSharpConstants.InstructionInfoNamespace, CSharpConstants.InstructionInfoDefine));
		toFullFileInfo.Add(TypeIds.DecoderError, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.DecoderError) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.DecoderDefine));
		toFullFileInfo.Add(TypeIds.DecoderOptions, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.DecoderOptions) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.DecoderDefine, baseType: "uint"));
		toFullFileInfo.Add(TypeIds.DecoderTestOptions, new FullEnumFileInfo(dirs.GetCSharpTestFilename("Intel", "DecoderTests", nameof(TypeIds.DecoderTestOptions) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.DecoderDefine, baseType: "uint"));
		toFullFileInfo.Add(TypeIds.EvexOpCodeHandlerKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.DecoderNamespace, nameof(TypeIds.EvexOpCodeHandlerKind) + ".g.cs"), CSharpConstants.DecoderNamespace, CSharpConstants.DecoderEvexDefine, baseType: "byte"));
		toFullFileInfo.Add(TypeIds.HandlerFlags, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.DecoderNamespace, nameof(TypeIds.HandlerFlags) + ".g.cs"), CSharpConstants.DecoderNamespace, CSharpConstants.DecoderDefine, baseType: "uint"));
		toFullFileInfo.Add(TypeIds.LegacyHandlerFlags, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.DecoderNamespace, nameof(TypeIds.LegacyHandlerFlags) + ".g.cs"), CSharpConstants.DecoderNamespace, CSharpConstants.DecoderDefine, baseType: "uint"));
		toFullFileInfo.Add(TypeIds.MemorySize, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.MemorySize) + ".g.cs"), CSharpConstants.BlazedNamespace));
		toFullFileInfo.Add(TypeIds.LegacyOpCodeHandlerKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.DecoderNamespace, nameof(TypeIds.LegacyOpCodeHandlerKind) + ".g.cs"), CSharpConstants.DecoderNamespace, CSharpConstants.DecoderDefine, baseType: "byte"));
		toFullFileInfo.Add(TypeIds.PseudoOpsKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, nameof(TypeIds.PseudoOpsKind) + ".g.cs"), CSharpConstants.FormatterNamespace));
		toFullFileInfo.Add(TypeIds.Register, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.Register) + ".g.cs"), CSharpConstants.BlazedNamespace));
		toFullFileInfo.Add(TypeIds.SerializedDataKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.DecoderNamespace, nameof(TypeIds.SerializedDataKind) + ".g.cs"), CSharpConstants.DecoderNamespace, CSharpConstants.DecoderDefine, baseType: "byte"));
		toFullFileInfo.Add(TypeIds.TupleType, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.TupleType) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.DecoderOrEncoderOrOpCodeInfoDefine));
		toFullFileInfo.Add(TypeIds.VexOpCodeHandlerKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.DecoderNamespace, nameof(TypeIds.VexOpCodeHandlerKind) + ".g.cs"), CSharpConstants.DecoderNamespace, CSharpConstants.DecoderVexOrXopDefine, baseType: "byte"));
		toFullFileInfo.Add(TypeIds.Mnemonic, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.Mnemonic) + ".g.cs"), CSharpConstants.BlazedNamespace));
		toFullFileInfo.Add(TypeIds.CtorKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "CtorKind.g.cs"), CSharpConstants.FormatterNamespace));
		toFullFileInfo.Add(TypeIds.SignExtendInfo, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "SignExtendInfo.g.cs"), CSharpConstants.FormatterNamespace));
		toFullFileInfo.Add(TypeIds.SizeOverride, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "SizeOverride.g.cs"), CSharpConstants.FormatterNamespace));
		toFullFileInfo.Add(TypeIds.BranchSizeInfo, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "BranchSizeInfo.g.cs"), CSharpConstants.FormatterNamespace));
		toFullFileInfo.Add(TypeIds.InstrOpInfoFlags, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "InstrOpInfoFlags.g.cs"), CSharpConstants.FormatterNamespace, baseType: "uint"));
		toFullFileInfo.Add(TypeIds.RoundingControl, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.RoundingControl) + ".g.cs"), CSharpConstants.BlazedNamespace));
		toFullFileInfo.Add(TypeIds.OpKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.OpKind) + ".g.cs"), CSharpConstants.BlazedNamespace));
		toFullFileInfo.Add(TypeIds.InstrScale, null);
		toFullFileInfo.Add(TypeIds.VectorLength, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.VectorLength) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.DecoderOrEncoderDefine));
		toFullFileInfo.Add(TypeIds.MandatoryPrefixByte, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.MandatoryPrefixByte) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.DecoderOrEncoderDefine, "uint"));// 'uint' not 'byte' since it gets zx to uint when OR'ing values
		toFullFileInfo.Add(TypeIds.EncodingKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.EncodingKind) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.DecoderOrEncoderOrInstrInfoOrOpCodeInfoDefine));
		toFullFileInfo.Add(TypeIds.FlowControl, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.FlowControl) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.InstructionInfoDefine));
		toFullFileInfo.Add(TypeIds.OpCodeOperandKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.OpCodeOperandKind) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.OpCodeInfoDefine));
		toFullFileInfo.Add(TypeIds.RflagsBits, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.RflagsBits) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.InstructionInfoDefine));
		toFullFileInfo.Add(TypeIds.OpAccess, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.OpAccess) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.InstructionInfoDefine));
		toFullFileInfo.Add(TypeIds.MandatoryPrefix, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.MandatoryPrefix) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.OpCodeInfoDefine));
		toFullFileInfo.Add(TypeIds.OpCodeTableKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.OpCodeTableKind) + ".g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.OpCodeInfoDefine));
		toFullFileInfo.Add(TypeIds.FormatterTextKind, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.FormatterTextKind) + ".g.cs"), CSharpConstants.BlazedNamespace));
		toFullFileInfo.Add(TypeIds.MemorySizeOptions, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, nameof(TypeIds.MemorySizeOptions) + ".g.cs"), CSharpConstants.BlazedNamespace));
		toFullFileInfo.Add(TypeIds.CodeAsmMemoryOperandSize, new FullEnumFileInfo(CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "Assembler", "MemoryOperandSize.g.cs"), CSharpConstants.BlazedNamespace, CSharpConstants.CodeAssemblerDefine));

		toPartialFileInfo = new();
		toPartialFileInfo.Add(TypeIds.InstrFlags1, new PartialEnumFileInfo("InstrFlags1", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "Instruction.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.OpSize, new PartialEnumFileInfo("OpSize", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "Decoder.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.StateFlags, new PartialEnumFileInfo("StateFlags", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "Decoder.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.ImpliedAccess, new PartialEnumFileInfo("ImpliedAccess", CSharpConstants.GetFilename(genTypes, CSharpConstants.InstructionInfoNamespace, "InfoHandlerFlags.cs"), null));
		toPartialFileInfo.Add(TypeIds.RflagsInfo, new PartialEnumFileInfo("RflagsInfo", CSharpConstants.GetFilename(genTypes, CSharpConstants.InstructionInfoNamespace, "InfoHandlerFlags.cs"), null));
		toPartialFileInfo.Add(TypeIds.OpInfo0, new PartialEnumFileInfo("OpInfo0", CSharpConstants.GetFilename(genTypes, CSharpConstants.InstructionInfoNamespace, "InfoHandlerFlags.cs"), null));
		toPartialFileInfo.Add(TypeIds.OpInfo1, new PartialEnumFileInfo("OpInfo1", CSharpConstants.GetFilename(genTypes, CSharpConstants.InstructionInfoNamespace, "InfoHandlerFlags.cs"), null));
		toPartialFileInfo.Add(TypeIds.OpInfo2, new PartialEnumFileInfo("OpInfo2", CSharpConstants.GetFilename(genTypes, CSharpConstants.InstructionInfoNamespace, "InfoHandlerFlags.cs"), null));
		toPartialFileInfo.Add(TypeIds.OpInfo3, new PartialEnumFileInfo("OpInfo3", CSharpConstants.GetFilename(genTypes, CSharpConstants.InstructionInfoNamespace, "InfoHandlerFlags.cs"), null));
		toPartialFileInfo.Add(TypeIds.OpInfo4, new PartialEnumFileInfo("OpInfo4", CSharpConstants.GetFilename(genTypes, CSharpConstants.InstructionInfoNamespace, "InfoHandlerFlags.cs"), null));
		toPartialFileInfo.Add(TypeIds.InfoFlags1, new PartialEnumFileInfo("InfoFlags1", CSharpConstants.GetFilename(genTypes, CSharpConstants.InstructionInfoNamespace, "InfoHandlerFlags.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.InfoFlags2, new PartialEnumFileInfo("InfoFlags2", CSharpConstants.GetFilename(genTypes, CSharpConstants.InstructionInfoNamespace, "InfoHandlerFlags.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.MemorySizeFlags, new PartialEnumFileInfo("MemorySizeFlags", dirs.GetCSharpTestFilename("Intel", "InstructionInfoTests", "InstructionInfoConstants.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.RegisterFlags, new PartialEnumFileInfo("RegisterFlags", dirs.GetCSharpTestFilename("Intel", "InstructionInfoTests", "InstructionInfoConstants.cs"), "uint"));

		toPartialFileInfo.Add(TypeIds.LegacyOpCodeTable, new PartialEnumFileInfo("LegacyOpCodeTable", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), null));
		toPartialFileInfo.Add(TypeIds.VexOpCodeTable, new PartialEnumFileInfo("VexOpCodeTable", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), null));
		toPartialFileInfo.Add(TypeIds.XopOpCodeTable, new PartialEnumFileInfo("XopOpCodeTable", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), null));
		toPartialFileInfo.Add(TypeIds.EvexOpCodeTable, new PartialEnumFileInfo("EvexOpCodeTable", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), null));

		toPartialFileInfo.Add(TypeIds.FormatterFlowControl, new PartialEnumFileInfo("FormatterFlowControl", CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "FormatterUtils.cs"), null));
		toPartialFileInfo.Add(TypeIds.InstrOpKind, new PartialEnumFileInfo("InstrOpKind", CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "InstrInfo.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.MemorySizeInfo, new PartialEnumFileInfo("MemorySizeInfo", CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "InstrInfo.cs"), null));
		toPartialFileInfo.Add(TypeIds.FarMemorySizeInfo, new PartialEnumFileInfo("FarMemorySizeInfo", CSharpConstants.GetFilename(genTypes, CSharpConstants.FormatterNamespace, "InstrInfo.cs"), null));
		toPartialFileInfo.Add(TypeIds.NumberBase, new PartialEnumFileInfo("NumberBase", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), null));

		toPartialFileInfo.Add(TypeIds.DisplSize, new PartialEnumFileInfo("DisplSize", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), null));
		toPartialFileInfo.Add(TypeIds.ImmSize, new PartialEnumFileInfo("ImmSize", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), null));
		toPartialFileInfo.Add(TypeIds.EncoderFlags, new PartialEnumFileInfo("EncoderFlags", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.EncFlags1, new PartialEnumFileInfo("EncFlags1", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.EncFlags2, new PartialEnumFileInfo("EncFlags2", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.EncFlags3, new PartialEnumFileInfo("EncFlags3", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.OpCodeInfoFlags1, new PartialEnumFileInfo("OpCodeInfoFlags1", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "OpCodeInfosEnums.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.OpCodeInfoFlags2, new PartialEnumFileInfo("OpCodeInfoFlags2", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "OpCodeInfosEnums.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.DecOptionValue, null);
		toPartialFileInfo.Add(TypeIds.InstrStrFmtOption, new PartialEnumFileInfo("InstrStrFmtOption", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "OpCodeInfosEnums.cs"), null));
		toPartialFileInfo.Add(TypeIds.WBit, new PartialEnumFileInfo("WBit", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.LBit, new PartialEnumFileInfo("LBit", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "Enums.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.LKind, new PartialEnumFileInfo("LKind", CSharpConstants.GetFilename(genTypes, CSharpConstants.EncoderNamespace, "OpCodeFormatter.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.RepPrefixKind, new PartialEnumFileInfo("RepPrefixKind", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "Instruction.Create.cs"), null));
		toPartialFileInfo.Add(TypeIds.RelocKind, new PartialEnumFileInfo("RelocKind", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "BlockEncoder.cs"), null));
		toPartialFileInfo.Add(TypeIds.BlockEncoderOptions, new PartialEnumFileInfo("BlockEncoderOptions", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "BlockEncoder.cs"), null));
		toPartialFileInfo.Add(TypeIds.FormatMnemonicOptions, new PartialEnumFileInfo("FormatMnemonicOptions", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "Formatter.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.PrefixKind, new PartialEnumFileInfo("PrefixKind", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOutput.cs"), null));
		toPartialFileInfo.Add(TypeIds.DecoratorKind, new PartialEnumFileInfo("DecoratorKind", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOutput.cs"), null));
		toPartialFileInfo.Add(TypeIds.NumberKind, new PartialEnumFileInfo("NumberKind", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOutput.cs"), null));
		toPartialFileInfo.Add(TypeIds.SymbolFlags, new PartialEnumFileInfo("SymbolFlags", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "ISymbolResolver.cs"), "uint"));
		toPartialFileInfo.Add(TypeIds.CC_b, new PartialEnumFileInfo("CC_b", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_ae, new PartialEnumFileInfo("CC_ae", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_e, new PartialEnumFileInfo("CC_e", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_ne, new PartialEnumFileInfo("CC_ne", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_be, new PartialEnumFileInfo("CC_be", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_a, new PartialEnumFileInfo("CC_a", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_p, new PartialEnumFileInfo("CC_p", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_np, new PartialEnumFileInfo("CC_np", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_l, new PartialEnumFileInfo("CC_l", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_ge, new PartialEnumFileInfo("CC_ge", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_le, new PartialEnumFileInfo("CC_le", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));
		toPartialFileInfo.Add(TypeIds.CC_g, new PartialEnumFileInfo("CC_g", CSharpConstants.GetFilename(genTypes, CSharpConstants.BlazedNamespace, "FormatterOptions.cs"), "byte"));

		toPartialFileInfo.Add(TypeIds.OptionsProps, new PartialEnumFileInfo("OptionsProps", dirs.GetCSharpTestFilename("Intel", "FormatterTests", "OptionsProps.cs"), null));

		toPartialFileInfo.Add(TypeIds.TestInstrFlags, new PartialEnumFileInfo("TestInstrFlags", dirs.GetCSharpTestFilename("Intel", "AssemblerTests", "AssemblerTestsBase.cs"), null));
	}

	public override void Generate(EnumType enumType) {
		if (toFullFileInfo.TryGetValue(enumType.TypeId, out var fullFileInfo)) {
			if (fullFileInfo is not null)
				WriteFile(fullFileInfo, enumType);
		}
		else if (toPartialFileInfo.TryGetValue(enumType.TypeId, out var partialInfo)) {
			if (partialInfo is not null)
				new FileUpdater(TargetLanguage.CSharp, partialInfo.Id, partialInfo.Filename).Generate(writer => WriteEnum(writer, partialInfo, enumType));
		}
	}

	void WriteEnum(FileWriter writer, EnumType enumType, string? baseType) {
		if (enumType.IsPublic && enumType.IsMissingDocs)
			writer.WriteLineNoIndent(CSharpConstants.PragmaMissingDocsDisable);
		docWriter.WriteSummary(writer, enumType.Documentation.GetComment(TargetLanguage.CSharp), enumType.RawName);
		if (enumType.IsFlags)
			writer.WriteLine("[Flags]");
		var pub = enumType.IsPublic ? "public " : string.Empty;
		var theBaseType = baseType is not null ? $" : {baseType}" : string.Empty;
		writer.WriteLine($"{pub}enum {enumType.Name()}{theBaseType} {{");
		using (writer.Indent()) {
			uint expectedValue = 0;
			foreach (var value in enumType.Values) {
				docWriter.WriteSummary(writer, value.Documentation.GetComment(TargetLanguage.CSharp), enumType.RawName);
				deprecatedWriter.WriteDeprecated(writer, value);
				if (enumType.IsFlags)
					writer.WriteLine($"{value.Name()} = 0x{value.Value:X8},");
				else if (expectedValue != value.Value || enumType.IsPublic)
					writer.WriteLine($"{value.Name()} = {value.Value},");
				else
					writer.WriteLine($"{value.Name()},");
				expectedValue = value.Value + 1;
			}
		}
		writer.WriteLine("}");
		if (enumType.IsPublic && enumType.IsMissingDocs)
			writer.WriteLineNoIndent(CSharpConstants.PragmaMissingDocsRestore);
	}

	void WriteFile(FullEnumFileInfo info, EnumType enumType) {
		using (var writer = new FileWriter(TargetLanguage.CSharp, FileUtils.OpenWrite(info.Filename))) {
			writer.WriteFileHeader();
			if (info.Define is not null)
				writer.WriteLineNoIndent($"#if {info.Define}");

			if (enumType.IsFlags) {
				writer.WriteLine("using System;");
				writer.WriteLine();
			}

			writer.WriteLine($"namespace {info.Namespace} {{");

			using (writer.Indent())
				WriteEnum(writer, enumType, info.BaseType);

			writer.WriteLine("}");
			if (info.Define is not null)
				writer.WriteLineNoIndent("#endif");
		}
	}

	void WriteEnum(FileWriter writer, PartialEnumFileInfo partialInfo, EnumType enumType) =>
		WriteEnum(writer, enumType, partialInfo.BaseType);
}
