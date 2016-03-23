using System;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_IsEqualTo_Feature
    {
        [Test]
        public void ExpectingNaruto_OnNaruto_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsEqualTo("Naruto"));

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = 'Naruto'", "(expected: 'Naruto')"));
        }

        [Test]
        public void ExpectingTakashi_OnNaruto_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsEqualTo("Takashi"));

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = 'Naruto'", "(expected: 'Takashi')"));
        }

        [Test]
        public void ExpectingMultilinedNarutoUzumaki_OnMultilinedNarutoUzumaki_ShouldSucceed()
        {
            // act
            var result = MultilinedNarutoUzumaki().Evaluate(n => n.Member(x => x.Name).IsEqualTo("Naruto".NewLine()
                                                                                              .Add("Uzumaki")));

            // assert
            result.ExAssert(r => r.p(x => x.succeeded) .IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: ( )Name = 'Naruto   (expected: 'Naruto".NewLine()
                                                             .Add("                  Uzumaki'             Uzumaki')")));
        }

        [Test]
        public void ExpectingNaruto_OnMultilinedNarutoUzumaki_ShouldFail()
        {
            // act
            var result = MultilinedNarutoUzumaki().Evaluate(n => n.Member(x => x.Name).IsEqualTo("Naruto"));

            // assert
            result.ExAssert(r => r.p(x => x.succeeded) .IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Name = 'Naruto   (expected: 'Naruto')".NewLine()
                                                             .Add("                  Uzumaki' ")));
        }

        [Test]
        public void ExpectingMultilinedNarutoUzumaki_OnNaruto_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsEqualTo("Naruto".NewLine()
                                                                             .Add("Uzumaki")));

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("Ninja: (X)Name = 'Naruto' (expected: 'Naruto".NewLine()
                                                             .Add("                                      Uzumaki')")));
        }
    }
}