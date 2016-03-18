using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api
{
    [TestFixture]
    public class IntegerAssertionFeature
    {
        private readonly Ninja oldNaruto = new Ninja(age:93);

        [Test]
        public void IsEqualTo_Expect12_Get12_ShouldPass()
        {
            Result result = Naruto().Evaluate(n => n.Member(x => x.Age).IsEqualTo(12));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsTrue()
                                  .p(x => x.actual)        .IsEqualTo("Ninja: ( )Age = 12")
                                  .p(x => x.expectation).IsEqualTo("(expected: 12)"));
        }

        [Test]
        public void IsEqualTo_Expect13_Get12_ShouldFail()
        {
            Result result = Naruto().Evaluate(n => n.p(x => x.Age).IsEqualTo(13));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsFalse()
                                  .p(x => x.actual)        .IsEqualTo("Ninja: (X)Age = 12")
                                  .p(x => x.expectation).IsEqualTo("(expected: 13)"));
        }

        [Test]
        public void IsSmallerThan_Expected13_Get12_ShouldPass()
        {
            Result result = Naruto().Evaluate(n => n.p(x => x.Age).IsSmallerThan(13));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsTrue()
                                  .p(x => x.actual)        .IsEqualTo("Ninja: ( )Age = 12")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 13)"));
        }

        [Test]
        public void IsSmallerThan_Expected13_Get13_ShouldFail()
        {
            Result result = oldNaruto.Evaluate(n => n.p(x => x.Age).IsSmallerThan(13));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsFalse()
                                  .p(x => x.actual)        .IsEqualTo("Ninja: (X)Age = 93")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 13)"));
        }

        [Test]
        public void IsBiggerThan_Expected2_Get12_ShouldPass()
        {
            // Act
            var result = Naruto().Evaluate(n => n.Member(x => x.Age).IsBiggerThan(2));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded) .IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )Age = 12 (expected: bigger than 2)"));
        }

        [Test]
        public void IsBiggerThan_Expected100_Get93_ShouldFail()
        {
            // Act
            var result = oldNaruto.Evaluate(n => n.Member(x => x.Age).IsBiggerThan(100));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded) .IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Age = 93 (expected: bigger than 100)"));
        }

        [Test]
        public void IsInRange_ExpectedIn9And12_Get12_ShouldPass()
        {
            // Act
            var result = Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(9, 12));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded) .IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )Age = 12 (expected: between 9 and 12)"));
        }

        [Test]
        public void IsInRange_ExpectedIn12And15_Get12_ShouldPass()
        {
            // Act
            var result = Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(12, 15));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )Age = 12 (expected: between 12 and 15)"));
        }

        [Test]
        public void IsInRange_ExpectedIn9And11_Get12_ShouldFail()
        {
            // Act
            var result = Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(9, 11));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded) .IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Age = 12 (expected: between 9 and 11)"));
        }

        [Test]
        public void IsInRange_ExpectedIn13And25_Get12_ShouldFail()
        {
            // Act
            var result = Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(13, 25));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Age = 12 (expected: between 13 and 25)"));
        }
    }
}