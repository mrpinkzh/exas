﻿using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.ComposeLog;
using static ExAs.Utils.Creation.CreateDojos;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_Before_Feature
    {
        [Test]
        public void ExpectingBeforeStandardDay_OnMedievalFoundation_ShouldSucceed()
        {
            var dojo = new Dojo(new Ninja(), founded: 12.March(878));

            // act
            Result result = dojo.Evaluate(d => d.Member(x => x.Founded).IsBefore(StandardDay()));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: ( )Founded = 12.03.0878 00:00:00")
                                  .Member(x => x.expectation).IsEqualTo(Expected("before 16.11.1984 00:00:00")));
        }

        [Test]
        public void ExpectingBeforeChristBirth_OnStandardDay_ShouldFail()
        {
            // act
            Result result = NarutosStandardDayDojo().Evaluate(d => d.Member(x => x.Founded).IsBefore(1.January(0001)));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual).IsEqualTo("Dojo: (X)Founded = 16.11.1984 00:00:00")
                                  .Member(x => x.expectation).IsEqualTo(Expected("before 01.01.0001 00:00:00")));
        }
    }
}