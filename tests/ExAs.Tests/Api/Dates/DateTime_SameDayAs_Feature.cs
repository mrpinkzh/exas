using System;
using ExAs.Utils;
using ExAs.Utils.Creation;
using NUnit.Framework;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_SameDayAs_Feature
    {
        [Test]
        public void OnCommonDojoFoundationDay_WithCommonDojoFoundationDay_ShouldSucceed()
        {
            // arrange
            var dojo = new Dojo(CreateNinjas.Naruto(), CommonFoundationDay());

            // act
            var result = dojo.Evaluate(d => d.Member(x => x.Founded).IsOnSameDayAs(15.November(1515)));

            // assert
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Dojo: ( )Founded = 15.11.1515 (expected: on same day as 15.11.1515)",
                            result.PrintLog());
        }

        [Test]
        public void OnCommonDojoFoundationDay_With200YearsLater_ShouldFail()
        {
            var dojo = new Dojo(CreateNinjas.Naruto(), CommonFoundationDay());
            var result = dojo.Evaluate(d => d.Member(x => x.Founded).IsOnSameDayAs(15.November(1715)));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("Dojo: (X)Founded = 15.11.1515 (expected: on same day as 15.11.1715)",
                            result.PrintLog());
        }
    }
}