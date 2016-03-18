using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Types
{
    [TestFixture]
    public class TypeAssertionFeature
    {
        [Test]
        public void IsOfType_OnName_WithString_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsOfType(typeof(string)));

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = 'Naruto'", "(expected: of type String)"));
        }

        [Test]
        public void IsOfType_OnName_WithObject_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsOfType(typeof(object)));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.expectation).IsEqualTo("(expected: of type Object)"));
        }

        [Test]
        public void IsOfType_OnName_WithInt_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsOfType(typeof(int)));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.expectation).IsEqualTo("(expected: of type Int32)"));
        }

        [Test]
        public void IsOfType_ExpectingString_OnNullNinjasName_ShouldFail()
        {
            // act
            var result = NullNinja().Evaluate(n => n.Member(x => x.Name).IsOfType(typeof(string)));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.expectation).IsEqualTo("(expected: of type String)"));
        }
    }
}