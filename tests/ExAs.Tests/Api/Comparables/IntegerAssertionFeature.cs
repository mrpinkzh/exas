﻿using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.Creation;
using NUnit.Framework;

namespace ExAs.Api.Comparables
{
    [TestFixture]
    public class IntegerAssertionFeature
    {
        private readonly Ninja oldNaruto = new Ninja(age:93);

        

        [Test]
        public void IsGreaterThan_Expected2_Get12_ShouldPass()
        {
            // Act
            var result = CreateNinjas.Naruto().Evaluate(n => n.Member(x => x.Age).IsGreaterThan(2));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded) .IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )Age = 12 (expected: bigger than 2)"));
        }

        [Test]
        public void IsGreaterThan_Expected100_Get93_ShouldFail()
        {
            // Act
            var result = oldNaruto.Evaluate(n => n.Member(x => x.Age).IsGreaterThan(100));

            // Assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded) .IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Age = 93 (expected: bigger than 100)"));
        }

        [Test]
        public void IsInRange_ExpectedIn9And12_Get12_ShouldPass()
        {
            // Act
            var result = CreateNinjas.Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(9, 12));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded) .IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )Age = 12 (expected: between 9 and 12)"));
        }

        [Test]
        public void IsInRange_ExpectedIn12And15_Get12_ShouldPass()
        {
            // Act
            var result = CreateNinjas.Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(12, 15));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )Age = 12 (expected: between 12 and 15)"));
        }

        [Test]
        public void IsInRange_ExpectedIn9And11_Get12_ShouldFail()
        {
            // Act
            var result = CreateNinjas.Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(9, 11));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded) .IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Age = 12 (expected: between 9 and 11)"));
        }

        [Test]
        public void IsInRange_ExpectedIn13And25_Get12_ShouldFail()
        {
            // Act
            var result = CreateNinjas.Naruto().Evaluate(n => n.p(x => x.Age).IsInRange(13, 25));

            // Arrange
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Age = 12 (expected: between 13 and 25)"));
        }
    }
}