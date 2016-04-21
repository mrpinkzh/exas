using System;
using ExAs.Utils;
using ExAs.Utils.Creation;
using NUnit.Framework;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_SameDayAs_Feature
    {
        private readonly DateTime commonFoundationDay = 15.November(1515).At(2.Hours(15));

        [Test]
        public void OnCommonDojoFoundationDay_WithCommonDojoFoundationDay_ShouldSucceed()
        {
            // arrange
            var dojo = new Dojo(CreateNinjas.Naruto(), commonFoundationDay);

            // act
            var result = dojo.Evaluate(d => d.Member(x => x.Founded).IsOnSameDayAs(15.November(1515)));

            // assert
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Dojo: ( )Founded = 15.11.1515 (expected: 15.11.1515)",
                            result.PrintLog());
        }

        [Test]
        public void OnCommonDojoFoundationDay_With200YearsLater_ShouldFail()
        {
            var dojo = new Dojo(CreateNinjas.Naruto(), commonFoundationDay);
            var result = dojo.Evaluate(d => d.Member(x => x.Founded).IsOnSameDayAs(15.November(1715)));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("Dojo: (X)Founded = 15.11.1515 (expected: 15.11.1715)",
                            result.PrintLog());
        }
    }
}