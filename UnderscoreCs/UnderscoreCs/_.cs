using System;
using System.Collections.Generic;

namespace UnderscoreCs {
	public static class _ {
		public static void Each(IEnumerable<string> list, Action<string> iteratee) {
			foreach (string item in list) {
				iteratee(item);
			}
		}
	}
}
