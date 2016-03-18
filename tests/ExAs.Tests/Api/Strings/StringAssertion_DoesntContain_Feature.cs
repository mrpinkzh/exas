﻿using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    public class StringAssertion_DoesntContain_Feature
    {
        [Test]
        public void ExpectingNotAkashi_OnNaruto_ShouldPass()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).DoesntContain("akashi"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.log)      .IsEqualTo("Ninja: ( )Name = 'Naruto'")
                                  .Member(x => x.expectation).IsEqualTo(ComposeLog.Expected("doesn't contain 'akashi'")));
        }

        [Test]
        public void ExpectingNotKash_OnKakashi_ShouldFail()
        {
            // act
            var result = Kakashi().Evaluate(n => n.Member(x => x.Name).DoesntContain("kash"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.log)      .IsEqualTo("Ninja: (X)Name = 'Kakashi'")
                                  .Member(x => x.expectation).IsEqualTo(ComposeLog.Expected("doesn't contain 'kash'")));
        }

        [Test]
        public void ExpectingNull_OnNaruto_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).DoesntContain(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.expectation).IsEqualTo(ComposeLog.Expected("doesn't contain null")));
        }
    }
}