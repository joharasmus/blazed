// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Diagnostics;

namespace Blazed.Intel {
	sealed class InstructionListDebugView {
		readonly InstructionList list;

		public InstructionListDebugView(InstructionList list) =>
			this.list = list ?? throw new ArgumentNullException(nameof(list));

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public Instruction[] Items => list.ToArray();
	}
}
