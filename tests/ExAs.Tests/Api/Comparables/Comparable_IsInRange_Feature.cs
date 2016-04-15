using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Comparables
{
    [TestFixture]
    public class Comparable_IsInRange_Feature
    {
        [Test]
        public void ExpectedIn9_1And43_7_Get38_4_ShouldPass()
        {
            // Act
            var result = PadavanNaruto().Evaluate(n => n.p(x => x.SkillValue).IsInRange(9.1, 43.7));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )SkillValue = 38.4 (expected: between 9.1 and 43.7)"));
        }

        [Test]
        public void ExpectedIn12_1And38_4_Get12_ShouldPass()
        {
            // Act
            var result = PadavanNaruto().Evaluate(n => n.p(x => x.SkillValue).IsInRange(12.1, 38.4));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )SkillValue = 38.4 (expected: between 12.1 and 38.4)"));
        }

        [Test]
        public void ExpectedIn9_1And11_8_Get38_4_ShouldFail()
        {
            // Act
            var result = PadavanNaruto().Evaluate(n => n.p(x => x.SkillValue).IsInRange(9.1, 11.8));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)SkillValue = 38.4 (expected: between 9.1 and 11.8)"));
        }

        [Test]
        public void ExpectedIn43_7And47_3_Get38_4_ShouldFail()
        {
            // Act
            var result = PadavanNaruto().Evaluate(n => n.p(x => x.SkillValue).IsInRange(43.7, 47.3));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)SkillValue = 38.4 (expected: between 43.7 and 47.3)"));
        }

        [Test]
        public void ExpectedIn9And12_Get12_ShouldPass()
        {
            // Act
            var result = Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(9, 12));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )Age = 12 (expected: between 9 and 12)"));
        }

        [Test]
        public void ExpectedIn12And15_Get12_ShouldPass()
        {
            // Act
            var result = Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(12, 15));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )Age = 12 (expected: between 12 and 15)"));
        }

        [Test]
        public void ExpectedIn9And11_Get12_ShouldFail()
        {
            // Act
            var result = Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(9, 11));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Age = 12 (expected: between 9 and 11)"));
        }

        [Test]
        public void ExpectedIn13And25_Get12_ShouldFail()
        {
            // Act
            var result = Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(13, 25));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Age = 12 (expected: between 13 and 25)"));
        }

        [Test]
        public void ExpectingBetween11And13_OnNinjaWith12_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.ShortAge()).IsInRange(11, 13));

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )ShortAge() = 12", "(expected: between 11 and 13)"));
        }
    }
}