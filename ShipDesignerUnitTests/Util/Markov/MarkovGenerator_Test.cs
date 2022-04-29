using System;
using Markov;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace ShipDesignerUnitTests
{
	[TestFixture]
	public class MarkovGenerator_Test
	{
		[OneTimeSetUp]
		public void Init()
		{
			Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
		}

		[Test]
		public void MarkovGenerator_GeneratedNameIsNotNull()
		{
			List<string> inputList = new List<string>() { "Man" };
			MarkovGenerator mg = new MarkovGenerator(inputList, new Random());

			string generatedName = mg.GenerateString();

			Assert.IsNotNull(generatedName);
		}

		[Test]
		public void MarkovGenerator_GeneratedNameLengthNotLessMinimumInputLength()
		{
			List<string> inputList = new List<string>() { "Man", "Taps", "Pants"};
			MarkovGenerator mg = new MarkovGenerator(inputList, new Random());

			string generatedName = mg.GenerateString();

			Assert.IsTrue(generatedName.ToCharArray().Length >= 3);
		}
	
	}
}
