using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class IntegerAssertionFeature
    {
        private readonly Ninja naruto = new Ninja();

        [Test]
        public void IsEqualTo_Expect12_Get12_ShouldPass()
        {
            ObjectAssertionResult result = naruto.Evaluate(n => n.Property(x => x.Age).IsEqualTo(12));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsTrue()
                                  .p(x => x.log)        .IsEqualTo("Ninja: ( )Age = 12")
                                  .p(x => x.expectation).IsEqualTo("(expected: 12)"));
        }

        [Test]
        public void IsEqualTo_Expect13_Get12_ShouldFail()
        {
            ObjectAssertionResult result = naruto.Evaluate(n => n.p(x => x.Age).IsEqualTo(13));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsFalse()
                                  .p(x => x.log)        .IsEqualTo("Ninja: (X)Age = 12")
                                  .p(x => x.expectation).IsEqualTo("(expected: 13)"));
        }

        [Test]
        public void IsSmallerThan_Expected13_Get12_ShouldPass()
        {
            ObjectAssertionResult result = naruto.Evaluate(n => n.p(x => x.Age).IsSmallerThan(13));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsTrue()
                                  .p(x => x.log)        .IsEqualTo("Ninja: ( )Age = 12")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 13)"));
        }

        [Test]
        public void IsSmallerThan_Expected13_Get13_ShouldPass()
        {
            var oldNaruto = new Ninja(age: 93);
            ObjectAssertionResult result = oldNaruto.Evaluate(n => n.p(x => x.Age).IsSmallerThan(13));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsFalse()
                                  .p(x => x.log)        .IsEqualTo("Ninja: (X)Age = 93")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 13)"));
        }
    }
}