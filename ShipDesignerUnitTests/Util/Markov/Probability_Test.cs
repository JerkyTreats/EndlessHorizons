using System;
using NUnit.Framework;
using Markov;
using System.Diagnostics;
using System.Collections.Generic;

namespace ShipDesignerUnitTests
{
	[TestFixture]
	public class Probability_Test
	{
		[Test]
		public void Probability_ExpectedWeightSet()
		{
			int total = 9;
			int wholeNumberMultiplier = 1000;
			decimal probability = 2m / total;
			probability = Math.Round(probability, 3);
			probability *= wholeNumberMultiplier;
			
			Trace.WriteLine(probability);

			Probability<char> lp = new Probability<char>('l', 2);

			Assert.AreEqual(decimal.ToInt32(probability), lp.GetWeight(wholeNumberMultiplier, total));
		}

		[Test]
		public void ProbabilityManager_AddedProbabilityUpdatesTotal()
		{
			ProbabilityManager<char> pm = new ProbabilityManager<char>(1000);
			pm.Add('a', 1);
			pm.Add('b', 1);

			Assert.AreEqual(2, pm.Total);
		}

		//[Test]
		//public void Probability_CorrectTotalReturned()
		//{


		//	Assert.AreEqual(total, p.Total);
		//}

	}
}
