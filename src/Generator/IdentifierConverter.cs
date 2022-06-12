// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using Generator.Enums;

namespace Generator; 
/// <summary>
/// Converts C# PascalCase identifiers to eg. snake_case
/// </summary>
static class IdentifierConverter {
	public static string ToDeclTypeAndValue(EnumValue value) =>
		$"{value.DeclaringType.Name()}.{value.Name()}";

	static readonly HashSet<string> keywords = new(StringComparer.Ordinal) {
		"abstract", "as", "base", "bool",
		"break", "byte", "case", "catch",
		"char", "checked", "class", "const",
		"continue", "decimal", "default", "delegate",
		"do", "double", "else", "enum",
		"event", "explicit", "extern", "false",
		"finally", "fixed", "float", "for",
		"foreach", "goto", "if", "implicit",
		"in", "int", "interface", "internal",
		"is", "lock", "long", "namespace",
		"new", "null", "object", "operator",
		"out", "override", "params", "private",
		"protected", "public", "readonly", "ref",
		"return", "sbyte", "sealed", "short",
		"sizeof", "stackalloc", "static", "string",
		"struct", "switch", "this", "throw",
		"true", "try", "typeof", "uint",
		"ulong", "unchecked", "unsafe", "ushort",
		"using", "using", "static", "virtual", "void",
		"volatile", "while",
	};

	public static string Escape(string name) => keywords.Contains(name) ? "@" + name : name;
}
