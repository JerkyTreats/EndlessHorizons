using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Markov;
using System;

namespace ShipDesignerUnitTests
{
	[TestClass]
	public class MarkovInput_Test
	{
		[TestMethod]
		public void MarkovInput_TestCountProperty()
		{
			List<string> list = new List<string>() { "Test", "Test2", "Test3" };
			MarkovInput mi = new MarkovInput(list);

			Assert.IsTrue(mi.Count == list.Count);
		}

		[TestMethod]
		public void MarkovInput_TestAddProperty()
		{
			string add = "Test2";
			MarkovInput mi = new MarkovInput(new List<string>() { "Test1" });

			mi.Add(add);

			Assert.IsTrue(mi.Values[1].Equals(add.ToLower()));
		}

		[TestMethod]
		public void MarkovInput_CorrectLetterFrequencyReturned()
		{
			char letterToFind = 'm';
			List<string> freqInput = new List<string>() { "mad", "map", "dam" };
			MarkovInput mi = new MarkovInput(freqInput);

			Assert.AreEqual(2, mi.LetterFrequency(0, letterToFind));
		}

		[TestMethod]
		public void MarkovInput_CorrectWordLengthDistributionReturned()
		{
			List<string> input = new List<string>() { "cat", "dog", "duck", "horse" };
			decimal word3chars = 2m / input.Count;
			decimal word4chars = 1m / input.Count;
			decimal word5chars = 1m / input.Count;
			MarkovInput mi = new MarkovInput(input);

			Assert.AreEqual(word3chars, mi.WordLengthDistribution[3]);
			Assert.AreEqual(word4chars, mi.WordLengthDistribution[4]);
			Assert.AreEqual(word5chars, mi.WordLengthDistribution[5]);
		}

		[TestMethod]
		public void MarkovInput_CorrectWordLengthOccurencesReturned()
		{
			List<string> input = new List<string>() { "cat", "dog", "duck", "horse" };
			MarkovInput mi = new MarkovInput(input);
			Assert.AreEqual(2, mi.WordLengths[3]);
			Assert.AreEqual(1, mi.WordLengths[4]);
			Assert.AreEqual(1, mi.WordLengths[5]);
		}

		[TestMethod]
		public void MarkovInput_CorrectNumberOfWordsReturned()
		{
			List<string> list = new List<string>() { "man", "cat", "man cat", "man cat cat man" };
			MarkovInput mi = new MarkovInput(list);

			Assert.AreEqual(2, mi.NumberOfWords[1]);
			Assert.AreEqual(1, mi.NumberOfWords[2]);
			Assert.AreEqual(1, mi.NumberOfWords[4]);
		}

		[TestMethod]
		public void MarkovInput_CapitalizedInputsSanitized()
		{
			string lower = "map";
			MarkovInput mi = new MarkovInput(new List<string>() { "MaP" });
			Assert.AreEqual(lower, mi.Values[0]);
		}
	}
}
