using System;
using Markov;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ShipDesignerUnitTests
{
	[TestClass]
	public class MarkovGenerator_Test
	{
		[TestMethod]
		public void MarkovGenerator_GeneratedNameIsNotNull()
		{
			List<string> inputList = new List<string>() { "Man" };
			MarkovGenerator mg = new MarkovGenerator(inputList, new Random());

			string generatedName = mg.GenerateString();

			Assert.IsNotNull(generatedName);
		}

		[TestMethod]
		public void MarkovGenerator_GeneratedNameLengthNotLessMinimumInputLength()
		{
			List<string> inputList = new List<string>() { "Man", "Taps", "Pants"};
			MarkovGenerator mg = new MarkovGenerator(inputList, new Random());

			string generatedName = mg.GenerateString();

			Assert.IsTrue(generatedName.ToCharArray().Length >= 3);
		}
	
	}
}
