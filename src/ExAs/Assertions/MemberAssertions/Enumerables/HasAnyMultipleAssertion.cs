using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
	public class HasAnyMultipleAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
	{
		private readonly IReadOnlyCollection<IAssert<TElement>> childAssertions;

		public HasAnyMultipleAssertion(IReadOnlyCollection<IAssert<TElement>> childAssertions)
		{
			this.childAssertions = childAssertions;
		}

		public ValueAssertionResult AssertValue(IEnumerable<TElement> actual)
		{
			var anyAssertions = childAssertions.Map(a => new HasAnyAssertion<TElement>(a));
			var valueAssertionResults = anyAssertions.Map(a => a.AssertValue(actual));
			return new ValueAssertionResult(
				valueAssertionResults.All(x => x.succeeded),
				valueAssertionResults.Map(r => r.actualValueString).JoinToString(Environment.NewLine),
				valueAssertionResults.Map(r => r.expectationString).JoinToString(Environment.NewLine));
		}
	}
}