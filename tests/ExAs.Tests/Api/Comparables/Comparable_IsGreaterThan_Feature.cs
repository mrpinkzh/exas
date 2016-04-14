using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Comparables
{
    [TestFixture]
    public class Comparable_IsGreaterThan_Feature
    {
        [Test]
        public void Expected37_8_Get38_8_ShouldPass()
        {
            // Act
            var result = PadavanNaruto().Evaluate(n => n.Member(x => x.SkillValue).IsGreaterThan(37.8));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )SkillValue = 38.4 (expected: bigger than 37.8)"));
        }

        [Test]
        public void Expected100_1_Get99_7_ShouldFail()
        {
            // Act
            var result = SkilledNaruto().Evaluate(n => n.Member(x => x.SkillValue).IsGreaterThan(100.1));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)SkillValue = 99.7 (expected: bigger than 100.1)"));
        }

        [Test]
        public void Expected2_Get12_ShouldPass()
        {
            // Act
            var result = Naruto().Evaluate(n => n.Member(x => x.Age).IsGreaterThan(2));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )Age = 12 (expected: bigger than 2)"));
        }

        [Test]
        public void Expected100_Get26_ShouldFail()
        {
            // Act
            var result = Kakashi().Evaluate(n => n.Member(x => x.Age).IsGreaterThan(100));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Age = 26 (expected: bigger than 100)"));
        }

        [Test]
        public void ExpectedGreaterThan10_OnNinjaWith12_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.ShortAge()).IsGreaterThan(10));

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )ShortAge() = 12", "(expected: bigger than 10)"));
        }
    }
}