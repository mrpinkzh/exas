using System;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class MultiplePropertyAssertionFeature
    {
        private readonly Ninja naruto = new Ninja("Naruto", 12);

        [Test]
        public void Assert_WithNaruto_AndValidAssertionForBothProperties_ShouldPass()
        {
            AssertionResult result = naruto.Evaluate(
                n => n.HasProperty(x => x.Name).EqualTo("Naruto")
                      .HasProperty(x => x.Age) .EqualTo(12));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Ninja: Name = 'Naruto' (expected: 'Naruto')".Add(Environment.NewLine)
                       .Add("       Age  = '12' (expected: '12')"),
                       result.log);
        }
         
    }
}