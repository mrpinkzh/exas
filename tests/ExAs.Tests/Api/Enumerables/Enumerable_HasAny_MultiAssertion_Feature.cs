using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;
using static System.Environment;
using static ExAs.Utils.Creation.CreateCities;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Enumerables
{
	[TestFixture]
	public class Enumerable_HasAny_MultiAssertion_Feature
	{
		[Test]
		public void ExpectingNarutosDojo_OnThreeDojoCity_ShouldSucceed()
		{
			// act
			var result = ThreeDojoCity().Evaluate(
				c => c.Member(x => x.Dojos).HasAny(
					d => d.p(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Naruto"))));

			// assert
			result.ExAssert(r =>
				r.p(x => x.succeeded).IsTrue()
					.p(x => x.PrintLog())
					.IsEqualTo($"City: ( )Dojos = <1 match>                                   (expected: at least 1 match){NewLine}" +
						       $"                 Dojo: ( )Master = Ninja: ( )Name = 'Naruto' (expected: 'Naruto')"));
		}
		
		[Test]
		public void ExpectingKakashisAndNarutosDojos_OnThreeDojoCity_ShouldSucceed()
		{
			// act
			var result = ThreeDojoCity().Evaluate(
				c => c.Member(x => x.Dojos).HasAny(
					d => d.p(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Naruto")),
					d => d.p(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Kakashi"))));

			// assert
			result.ExAssert(r => 
				r.p(x => x.succeeded)  .IsTrue()
				 .p(x => x.PrintLog())
					.IsEqualTo($"City: ( )Dojos = <1 match>                                    (expected: at least 1 match){NewLine}" +
							   $"                 Dojo: ( )Master = Ninja: ( )Name = 'Naruto'  (expected: 'Naruto'){NewLine}" +
							   $"                 <1 match>                                    (expected: at least 1 match){NewLine}" +
							   $"                 Dojo: ( )Master = Ninja: ( )Name = 'Kakashi' (expected: 'Kakashi')"));
		}

		[Test]
		public void ExpectingGokusAndKakashisDojos_OnThreeDojoCity_ShouldFail()
		{
			// act
			var result = ThreeDojoCity().Evaluate(
				c => c.Member(x => x.Dojos).HasAny(
					d => d.p(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Son Goku")),
					d => d.p(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Kakashi"))));

			// assert
			result.ExAssert(r =>
				r.p(x => x.succeeded).IsFalse()
				 .p(x => x.PrintLog())
					.IsEqualTo($"City: (X)Dojos = <0 matches>                                  (expected: at least 1 match){NewLine}" +
					           $"                 Dojo: (X)Master = Ninja: (X)Name = 'Naruto'  (expected: 'Son Goku'){NewLine}" +
					           $"                 Dojo: (X)Master = Ninja: (X)Name = 'Kakashi' (expected: 'Son Goku'){NewLine}" +
					           $"                 Dojo: (X)Master = Ninja: (X)Name = 'Tsubasa' (expected: 'Son Goku'){NewLine}" +
					           $"                 <1 match>                                    (expected: at least 1 match){NewLine}" +
					           $"                 Dojo: ( )Master = Ninja: ( )Name = 'Kakashi' (expected: 'Kakashi')"));
		}

		[Test]
		public void ExpectingKakashisAndNarutosDojos_OnNull_ShouldFail()
		{
			// act
			var result = CityWithNullDojoList().Evaluate(
				c => c.Member(x => x.Dojos).HasAny(
					d => d.p(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Naruto")),
					d => d.p(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Kakashi"))));

			// assert
			result.ExAssert(r =>
				r.p(x => x.succeeded).IsFalse()
				 .p(x => x.PrintLog())
					.IsEqualTo($"City: (X)Dojos = null (expected: at least 1 match){NewLine}" +
					           $"                 null (expected: at least 1 match)"));
		}

		[Test]
		public void ExpectingKakashisAndNarutosDojos_OnEmptyCity_ShouldFail()
		{
			// act
			var result = CityWithoutDojo().Evaluate(
				c => c.Member(x => x.Dojos).HasAny(
					d => d.p(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Naruto")),
					d => d.p(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Kakashi"))));

			// assert
			result.ExAssert(r =>
				r.p(x => x.succeeded).IsFalse()
				 .p(x => x.PrintLog())
					.IsEqualTo($"City: (X)Dojos = <empty> (expected: at least 1 match){NewLine}" +
					           $"                 <empty> (expected: at least 1 match)"));
		}
	}
}