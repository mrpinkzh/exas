using System;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class MultipleObjectsAssertionFeature
    {
        private readonly Dojo narutosDojo = new Dojo(new Ninja(), new DateTime(1515, 11, 1));

        [Test]
        public void WithNarutosDojo_AndValidAssertions_ShouldPass()
        {
            ObjectAssertionResult result = narutosDojo.Evaluate(
                d => d.Member(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Naruto")
                                                                 .Member(x => x.Age) .IsEqualTo(12))
                      .Member(x => x.Founded).IsEqualTo(new DateTime(1515, 11, 1)));

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
            // act
            var result = narutosDojo.Evaluate(
                d => d.Member(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsNotNull()
                                                              .Member(x => x.Age) .IsEqualTo(26))
                      .Member(x => x.Founded).IsEqualTo(new DateTime(1515, 11, 1)));

            Assert.IsFalse(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("Dojo: (X)Master  = Ninja: ( )Name = 'Naruto' (expected: not null)".NewLine()
                       .Add("                          (X)Age  = 12       (expected: 26)").NewLine()
                       .Add("      ( )Founded = 01.11.1515 00:00:00       (expected: 01.11.1515 00:00:00)"),
                       result.PrintLog());
        }
    }
}