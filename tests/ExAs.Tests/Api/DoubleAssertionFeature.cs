using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ExAs.Api
{
    using global::ExAs.Results;
    using global::ExAs.Utils;

    [TestFixture]
    public class DoubleAssertionFeature
    {
        private readonly Ninja padavanNaruto = new Ninja(skillValue: 38.4);
        private readonly Ninja skilledNaruto = new Ninja(skillValue: 99.7);

        [Test]
        public void IsEqualTo_Expect38_4_Get38_4_ShouldPass()
        {
            Result result = padavanNaruto.Evaluate(n => n.Member(x => x.SkillValue).IsEqualTo(38.4));
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.actual).IsEqualTo("Ninja: ( )SkillValue = 38.4")
                                  .p(x => x.expectation).IsEqualTo("(expected: 38.4)"));
        }

        [Test]
        public void IsEqualTo_Expect38_4_Get13_8_ShouldFail()
        {
            Result result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsEqualTo(13.8));
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.actual).IsEqualTo("Ninja: (X)SkillValue = 38.4")
                                  .p(x => x.expectation).IsEqualTo("(expected: 13.8)"));
        }

        [Test]
        public void IsSmallerThan_Expected43_2_Get38_4_ShouldPass()
        {
            Result result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsSmallerThan(43.2));
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.actual).IsEqualTo("Ninja: ( )SkillValue = 38.4")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 43.2)"));
        }

        [Test]
        public void IsSmallerThan_Expected99_2_Get99_7_ShouldFail()
        {
            Result result = skilledNaruto.Evaluate(n => n.p(x => x.SkillValue).IsSmallerThan(99.2));
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.actual).IsEqualTo("Ninja: (X)SkillValue = 99.7")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 99.2)"));
        }

        [Test]
        public void IsBiggerThan_Expected37_8_Get38_8_ShouldPass()
        {
            // Act
            var result = padavanNaruto.Evaluate(n => n.Member(x => x.SkillValue).IsBiggerThan(37.8));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )SkillValue = 38.4 (expected: bigger than 37.8)"));
        }

        [Test]
        public void IsBiggerThan_Expected100_1_Get99_7_ShouldFail()
        {
            // Act
            var result = skilledNaruto.Evaluate(n => n.Member(x => x.SkillValue).IsBiggerThan(100.1));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)SkillValue = 99.7 (expected: bigger than 100.1)"));
        }

        [Test]
        public void IsInRange_ExpectedIn9_1And43_7_Get38_4_ShouldPass()
        {
            // Act
            var result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsInRange(9.1, 43.7));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )SkillValue = 38.4 (expected: between 9.1 and 43.7)"));
        }

        [Test]
        public void IsInRange_ExpectedIn12_1And38_4_Get12_ShouldPass()
        {
            // Act
            var result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsInRange(12.1, 38.4));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )SkillValue = 38.4 (expected: between 12.1 and 38.4)"));
        }

        [Test]
        public void IsInRange_ExpectedIn9_1And11_8_Get38_4_ShouldFail()
        {
            // Act
            var result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsInRange(9.1, 11.8));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)SkillValue = 38.4 (expected: between 9.1 and 11.8)"));
        }

        [Test]
        public void IsInRange_ExpectedIn43_7And47_3_Get38_4_ShouldFail()
        {
            // Act
            var result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsInRange(43.7, 47.3));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)SkillValue = 38.4 (expected: between 43.7 and 47.3)"));
        }
    }
}
