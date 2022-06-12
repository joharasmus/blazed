// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;

namespace Generator; 
readonly struct TypeId : IEquatable<TypeId> {

	readonly string id1;

	public TypeId(string id1) => this.id1 = id1;

	public static bool operator ==(TypeId left, TypeId right) => left.Equals(right);
	public static bool operator !=(TypeId left, TypeId right) => !left.Equals(right);

	public bool Equals(TypeId other) => id1 == other.id1;

	public override bool Equals(object? obj) => obj is TypeId other && Equals(other);

	public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(id1 ?? string.Empty);
	
	public override string ToString() => id1;
}
