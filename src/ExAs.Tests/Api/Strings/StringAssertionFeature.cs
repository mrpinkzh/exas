using System;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertionFeature
    {
        private readonly Ninja naruto = new Ninja();
        private readonly Ninja narutoUzumaki = new Ninja("Naruto".NewLine()
                                                    .Add("Uzumaki"));

        [Test]
        public void IsNull_WithNullNinja_ShouldPass()
        {
            var nullNinja = new Ninja(name: null);
            ObjectAssertionResult result = nullNinja.Evaluate(n => n.Property(x => x.Name).IsNull());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual(
                "Ninja: ( )Name = null (expected: null)",
                result.PrintLog());
        }

        [Test]
        public void IsNull_WithNaruto_ShouldFail()
        {
            ObjectAssertionResult result = naruto.Evaluate(n => n.Property(x => x.Name).IsNull());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual(
                "Ninja: (X)Name = 'Naruto' (expected: null)",
                result.PrintLog());
        }

        [Test]
        public void IsEmpty_WithEmptyNinja_ShouldPass()
        {
            var ninja = new Ninja("");
            ObjectAssertionResult result = ninja.Evaluate(n => n.Property(x => x.Name).IsEmpty());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual(
                "Ninja: ( )Name = '' (expected: empty string)",
                result.PrintLog());
        }

        [Test]
        public void IsEmpty_WithNaruto_ShouldFail()
        {
            ObjectAssertionResult result = naruto.Evaluate(n => n.Property(x => x.Name).IsEmpty());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual(
                "Ninja: (X)Name = 'Naruto' (expected: empty string)",
                result.PrintLog());
        }

        [Test]
        public void EqualTo_OnNaruto_WithNaruto_ShouldPass()
        {
            var result = naruto.Evaluate(n => n.Property(x => x.Name).IsEqualTo("Naruto"));
            Assert.AreEqual("Ninja: ( )Name = 'Naruto' (expected: 'Naruto')", result.PrintLog());
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void EqualTo_OnNaruto_WithTakashi_ShouldFail()
        {
            var result = naruto.Evaluate(n => n.Property(x => x.Name).IsEqualTo("Takashi"));
            Assert.AreEqual("Ninja: (X)Name = 'Naruto' (expected: 'Takashi')", result.PrintLog());
            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void EqualTo_OnMultilinedNarutoUzumaki_WithMultilinedNarutoUzumaki_ShouldPass()
        {
            var result = narutoUzumaki.Evaluate(n => n.Property(x => x.Name).IsEqualTo("Naruto".NewLine()
                                                                                .Add("Uzumaki")));

            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("Ninja: ( )Name = 'Naruto   (expected: 'Naruto"   .NewLine()
                       .Add("                  Uzumaki'             Uzumaki')"),
                            result.PrintLog());
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void OnMultilinedNarutoUzumaki_WithSinglelinedNaruto_ShouldFail()
        {
            var result = narutoUzumaki.Evaluate(n => n.Property(x => x.Name).IsEqualTo("Naruto"));

            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("Ninja: (X)Name = 'Naruto   (expected: 'Naruto')".NewLine()
                       .Add("                  Uzumaki' "),
                            result.PrintLog());
            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void OnSinglelinedNaruto_WithMultilinedNaruto_ShouldFail()
        {
            var result = naruto.Evaluate(n => n.Property(x => x.Name).IsEqualTo("Naruto".NewLine()
                                                                         .Add("Uzumaki")));

            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("Ninja: (X)Name = 'Naruto' (expected: 'Naruto".NewLine()
                       .Add("                                      Uzumaki')"),
                            result.PrintLog());
            Assert.IsFalse(result.succeeded);
        }
    }
}