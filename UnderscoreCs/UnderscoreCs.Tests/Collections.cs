using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnderscoreCs.Tests {
	[TestClass]
	public class Collections {

		#region each

		/// <summary>
		/// http://underscorejs.org/#each
		/// each	<code>_.each(list, iteratee, [context])</code>	Alias: forEach 
		/// Iterates over a list of elements, yielding each in turn to an iteratee function.
		/// The iteratee is bound to the context object, if one is passed. Each invocation of iteratee
		/// is called with three arguments: <code>(element, index, list)</code>.
		/// If list is a JavaScript object, iteratee's arguments will be <code>(value, key, list)</code>.
		/// Returns the list for chaining.
		/// </summary>
		public string EachDoc;

		[TestMethod]
		public void Each_GivenIEnumerable_AndIteratee_WhenCalled_ThenEachElementInListIsVisited() {
			IEnumerable<string> list = new[] {"A", "B", "C"};
			var mock = new Mock<IObserver<string>>(MockBehavior.Loose);
			Action<string> iteratee = foo => { mock.Object.OnNext(foo); };

			_.Each(list, iteratee);

			mock.Verify(m => m.OnNext("A"));
			mock.Verify(m => m.OnNext("B"));
			mock.Verify(m => m.OnNext("C"));
		}


		public class Foo {
			public string Bar { get; set; }
		}

		[TestMethod]
		public void Each_GivenArbitraryTypeForList_WhenCalled_ThenEachElementInListIsVisited() {
			IEnumerable<Foo> list = new[] {new Foo {Bar = "A"}, new Foo {Bar = "B"}, new Foo {Bar = "C"}};
			var mock = new Mock<IObserver<Foo>>(MockBehavior.Loose);
			Action<Foo> iteratee = foo => { mock.Object.OnNext(foo); };

			_.Each(list, iteratee);

			mock.Verify(m => m.OnNext(It.Is<Foo>(f => f.Bar == "A")));
			mock.Verify(m => m.OnNext(It.Is<Foo>(f => f.Bar == "B")));
			mock.Verify(m => m.OnNext(It.Is<Foo>(f => f.Bar == "C")));
		}

		[TestMethod]
		public void Each_GivenIEnumerable_AndIterateeThatTakesInt_WhenCalled_ThenEachElementInListIsVisited() {
			IEnumerable<string> list = new[] { "C", "A", "B" };
			var mock = new Mock<IObserver<Tuple<string, int>>>(MockBehavior.Loose);
			Action<string, int> iteratee = (foo, index) => {
				mock.Object.OnNext(new Tuple<string, int>(foo, index));
			};

			_.Each(list, iteratee);

			mock.Verify(m => m.OnNext(It.Is<Tuple<string, int>>(t => t.Item1 == "A" && t.Item2 == 2)));
			mock.Verify(m => m.OnNext(It.Is<Tuple<string, int>>(t => t.Item1 == "B" && t.Item2 == 3)));
			mock.Verify(m => m.OnNext(It.Is<Tuple<string, int>>(t => t.Item1 == "C" && t.Item2 == 1)));
		}

		#endregion

		#region map

		/// <summary>
		/// map		<code>_.map(list, iteratee, [context])</code>	Alias: collect  
		/// Produces a new array of values by mapping each value in list through a
		/// transformation function (iteratee). The <code>iteratee</code> is passed three arguments: the value,
		/// then the <code>index</code> (or <code>key</code>) of the iteration, and finally a reference to the entire <code>list</code>.
		/// </summary>
		public string MapDoc;

		#endregion
	}
}
