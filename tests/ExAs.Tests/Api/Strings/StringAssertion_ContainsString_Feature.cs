using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    using ExAs.Utils;

    [TestFixture]
    public class StringAssertion_ContainsString_Feature
    {
        [Test]
        public void ContainsArut_OnNaruto_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).Contains("arut"));

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = 'Naruto'", "(expected: contains 'arut')"));
        }

        [Test]
        public void Expecting7_OnNaruto_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).Contains("Ninja"));

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = 'Naruto'", "(expected: contains 'Ninja')"));
        }

        [Test]
        public void Expecting6_OnNullNinja_ShouldFail()
        {
            // act
            var result = NullNinja().Evaluate(n => n.Member(x => x.Name).Contains("arut"));

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = null", "(expected: contains 'arut')"));
        }
    }
}
