using System;
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
            AssertionResult result = narutosDojo.Evaluate(
                d => d.HasProperty(x => x.Master).Fulfills(n => n.HasProperty(x => x.Name).EqualTo("Naruto")
                                                                 .HasProperty(x => x.Age) .EqualTo(12))
                      .HasProperty(x => x.Founded).EqualTo(new DateTime(1515, 11, 1)));

            Assert.IsTrue(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("Dojo: Master  = Ninja: Name = 'Naruto' (expected: 'Naruto')".NewLine()
                       .Add("                       Age  = '12'     (expected: '12')").NewLine()
                       .Add("      Founded = '01.11.1515 00:00:00'  (expected: '01.11.1515 00:00:00')"),
                       result.PrintLog());
        }
    }
}