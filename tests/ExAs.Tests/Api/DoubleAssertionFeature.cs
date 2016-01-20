using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ExAs.Api
{
    using ExAs.Results;
    using ExAs.Utils;

    [TestFixture]
    public class DoubleAssertionFeature
    {
        private readonly Ninja padavanNaruto = new Ninja(skillValue: 12.4);
        private readonly Ninja skilledNaruto = new Ninja(skillValue: 93.7);

        [Test]
        public void IsEqualTo_Expect12_Get12_ShouldPass()
        {
            ObjectAssertionResult result = padavanNaruto.Evaluate(n => n.Property(x => x.SkillValue).IsEqualTo(12.4));
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.log).IsEqualTo("Ninja: ( )SkillValue = 12.4")
                                  .p(x => x.expectation).IsEqualTo("(expected: 12.4)"));
        }

        [Test]
        public void IsEqualTo_Expect13_Get12_ShouldFail()
        {
            ObjectAssertionResult result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsEqualTo(13.8));
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.log).IsEqualTo("Ninja: (X)SkillValue = 12.4")
                                  .p(x => x.expectation).IsEqualTo("(expected: 13.8)"));
        }

        [Test]
        public void IsSmallerThan_Expected13_Get12_ShouldPass()
        {
            ObjectAssertionResult result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsSmallerThan(13.2));
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.log).IsEqualTo("Ninja: ( )SkillValue = 12.4")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 13.2)"));
        }

        [Test]
        public void IsSmallerThan_Expected13_Get13_ShouldPass()
        {
            ObjectAssertionResult result = skilledNaruto.Evaluate(n => n.p(x => x.SkillValue).IsSmallerThan(13.2));
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.log).IsEqualTo("Ninja: (X)SkillValue = 93.7")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 13.2)"));
        }

        [Test]
        public void IsBiggerThan_Expected2_Get12_ShouldPass()
        {
            // Act
            var result = padavanNaruto.Evaluate(n => n.Property(x => x.SkillValue).IsBiggerThan(2.8));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )SkillValue = 12.4 (expected: bigger than 2)"));
        }

        [Test]
        public void IsBiggerThan_Expected100_Get93_ShouldFail()
        {
            // Act
            var result = skilledNaruto.Evaluate(n => n.Property(x => x.SkillValue).IsBiggerThan(100.1));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)SkillValue = 93.7 (expected: bigger than 100.1)"));
        }

        [Test]
        public void IsInRange_ExpectedIn9And12_Get12_ShouldPass()
        {
            // Act
            var result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsInRange(9.1, 13.7));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )SkillValue = 12.4 (expected: between 9.1 and 13.7)"));
        }

        [Test]
        public void IsInRange_ExpectedIn12And15_Get12_ShouldPass()
        {
            // Act
            var result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsInRange(12.1, 15.3));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )SkillValue = 12.4 (expected: between 12.1 and 15.3)"));
        }

        [Test]
        public void IsInRange_ExpectedIn9And11_Get12_ShouldFail()
        {
            // Act
            var result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsInRange(9.1, 11.8));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)SkillValue = 12.4 (expected: between 9.1 and 11.8)"));
        }

        [Test]
        public void IsInRange_ExpectedIn13And25_Get12_ShouldFail()
        {
            // Act
            var result = padavanNaruto.Evaluate(n => n.p(x => x.SkillValue).IsInRange(13.7, 25.1));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)SkillValue = 12.4 (expected: between 13.7 and 25.1)"));
        }
    }
}
