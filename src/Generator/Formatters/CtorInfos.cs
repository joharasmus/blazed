// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using System.Linq;
using Generator.Enums;
using Generator.Tables;

namespace Generator.Formatters;

[TypeGen(TypeGenOrders.PreCreateInstructions)]
sealed class CtorInfos : ICreatedInstructions {
	public FmtInstructionDef[] Infos {
		get {
			if (!filtered)
				throw new InvalidOperationException();
			return infos;
		}
	}

	FmtInstructionDef[] infos;
	bool filtered;

	CtorInfos(GenTypes genTypes) {
		infos = Array.Empty<FmtInstructionDef>();
		genTypes.AddObject(TypeIds.CtorInfos, this);
	}

	void ICreatedInstructions.OnCreatedInstructions(GenTypes genTypes, HashSet<EnumValue> filteredCodeValues) {
		var defs = genTypes.GetObject<InstructionDefs>(TypeIds.InstructionDefs).Defs;
		infos = defs.Select(a => a.FmtInstrDef).ToArray();
		filtered = true;
	}
}
