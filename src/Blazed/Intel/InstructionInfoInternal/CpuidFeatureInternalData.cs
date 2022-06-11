// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

#if INSTR_INFO
using System;
using Blazed.Intel.Internal;

namespace Blazed.Intel.InstructionInfoInternal {
	static partial class CpuidFeatureInternalData {
		public static readonly CpuidFeature[][] ToCpuidFeatures = GetCpuidFeatures();
		static CpuidFeature[][] GetCpuidFeatures() {
			var data = GetGetCpuidFeaturesData();
			var reader = new DataReader(data);
			reader.Index = (BlazedConstants.MaxCpuidFeatureInternalValues + 7) / 8;
			var cpuidFeatures = new CpuidFeature[BlazedConstants.MaxCpuidFeatureInternalValues][];
			for (int i = 0; i < cpuidFeatures.Length; i++) {
				byte b = data[i / 8];
				var features = new CpuidFeature[((b >> (i % 8)) & 1) + 1];
				for (int j = 0; j < features.Length; j++)
					features[j] = (CpuidFeature)reader.ReadByte();
				cpuidFeatures[i] = features;
			}
			if (reader.CanRead)
				throw new InvalidOperationException();
			return cpuidFeatures;
		}
	}
}
#endif
