using System;
using System.Collections.Generic;

namespace UnderscoreCs {
	public partial class _ {
		/// <summary>
		/// Iterates over a list of elements, yielding each in turn to an iteratee function.
		/// </summary>
		/// <param name="list">An object to enumerate over</param>
		/// <param name="iteratee">A function to apply to each item in the enumeration</param>
		public static void Each<TList>(IEnumerable<TList> list, Action<TList> iteratee) {
			foreach (var item in list) {
				iteratee(item);
			}
		}
	}
}
