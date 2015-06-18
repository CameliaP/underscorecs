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

		public static void Each<TList>(IEnumerable<TList> list, Action<TList, int> iteratee) {
			int index = 0;
			foreach (var item in list) {
				iteratee(item, index);
				index += 1;
			}
		}

		public static void Each<TValue, TKey>(IEnumerable<KeyValuePair<TKey, TValue>> list, Action<TValue, TKey> iteratee) {
			foreach (var item in list) {
				iteratee(item.Value, item.Key);
			}
		}

		public static void Each<TValue, TKey>(IEnumerable<KeyValuePair<TKey, TValue>> list, Action<TValue> iteratee) {
			Each(list, (v, k) => iteratee(v));
		}
	}
}
