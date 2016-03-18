using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.ExAs;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.ShortSyntax
{
    public class ShortSyntaxFeature
    {
        [Test]
        public void ExpectingNotNull_OnNaruto_ShouldPass()
        {
            // act
            var result = Evaluate(Naruto(), IsNotNull<Ninja>());

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("Ninja: Name = 'Naruto' (expected: not null)"));
        }

        [Test]
        public void ExpectingNull_OnNaruto_ShouldFail()
        {
            // act
            var result = Evaluate(Naruto(), IsNull<Ninja>());

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("Ninja: Name = 'Naruto' (expected: null)"));
        }

        [Test]
        public void ExpectingNaruto_OnKakashi_ShouldFail()
        {
            // act
            var result = Evaluate(Kakashi(), Has<Ninja>().Member(x => x.Name).IsEqualTo("Naruto")
                                                         .Member(x => x.Age) .IsEqualTo(12));

            // assert
            ExAssert(result, Has<Result>().Member(x => x.succeeded).IsFalse()
                                          .Member(x => x.actual)      .Printout());
        }
    }
}