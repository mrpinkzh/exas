using System;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    using System.Globalization;
    using System.Threading;

    [TestFixture]
    public class MultipleObjectsAssertionFeature
    {
        private readonly Dojo narutosDojo = new Dojo(new Ninja(), new DateTime(1515, 11, 1));

        [Test]
        public void WithNarutosDojo_AndValidAssertions_ShouldPass()
        {
            // arrange
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de");

            // act
            ObjectAssertionResult result = narutosDojo.Evaluate(
                d => d.Member(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Naruto")
                                                                 .Member(x => x.Age) .IsEqualTo(12))
                      .Member(x => x.Founded).IsEqualTo(new DateTime(1515, 11, 1)));

            // assert
            Assert.IsTrue(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("Dojo: ( )Master  = Ninja: ( )Name = 'Naruto' (expected: 'Naruto')".NewLine()
                       .Add("                          ( )Age  = 12       (expected: 12)").NewLine()
                       .Add("      ( )Founded = 01.11.1515 00:00:00       (expected: 01.11.1515 00:00:00)"),
                       result.PrintLog());
        }

        [Test]
        public void ExpectingTakahashisDojo_OnNarutosDojo_ShouldFail()
        {
            // arrange
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en");

            // act
            var result = narutosDojo.Evaluate(
                d => d.Member(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsNotNull()
                                                              .Member(x => x.Age) .IsEqualTo(26))
                      .Member(x => x.Founded).IsEqualTo(new DateTime(1515, 11, 1)));

            // assert
            Assert.IsFalse(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("Dojo: (X)Master  = Ninja: ( )Name = 'Naruto' (expected: not null)".NewLine()
                       .Add("                          (X)Age  = 12       (expected: 26)").NewLine()
                       .Add("      ( )Founded = 11/1/1515 12:00:00 AM     (expected: 11/1/1515 12:00:00 AM)"),
                       result.PrintLog());
        }
    }
}