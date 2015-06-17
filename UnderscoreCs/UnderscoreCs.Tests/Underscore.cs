using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnderscoreCs.Tests {
	[TestClass]
	public class Underscore {
		
		[TestMethod]
		public async Task Underscore_exists() {
			PrivateType type = new PrivateType("UnderscoreCs", "UnderscoreCs._");
		}
	}
}
