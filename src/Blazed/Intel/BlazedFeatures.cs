// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System.Runtime.CompilerServices;

namespace Blazed.Intel {
	/// <summary>
	/// Gets the available features
	/// </summary>
	public static class BlazedFeatures {

		/// <summary>
		/// Initializes some static constructors related to the decoder and instruction info. If those
		/// static constructors are initialized, the jitter generates faster code since it doesn't have
		/// to add runtime checks to see if those static constructors must be called.
		/// 
		/// This method should be called before using the decoder and instruction info classes and
		/// should *not* be called from the same method as any code that uses the decoder / instruction
		/// info classes. Eg. call this method from Main() and decode instructions / get instruction info
		/// in a method called by Main().
		/// </summary>
		public static void Initialize() {
#if DECODER
			// The decoder already initializes this stuff, but when it's called, it's a little bit too late.
			RuntimeHelpers.RunClassConstructor(typeof(Decoder).TypeHandle);
#endif
		}
	}
}
