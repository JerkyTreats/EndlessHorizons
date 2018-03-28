using NUnit.Framework;
using System.Diagnostics;
using System.Collections.Generic;
using Markov;

namespace ShipDesignerUnitTests
{
    [TestFixture]
    public class MarkovInput_Test
    {
        [Test()]
        public void MarkovInput_TestCountProperty()
        {
            List<string> list = new List<string>() { "Test", "Test2", "Test3" };
            MarkovInput mi = new MarkovInput(list);

            Assert.IsTrue(mi.Count == list.Count);
        }

        [Test()]
        public void MarkovInput_TestAddProperty()
        {
            string add = "Test2";
            MarkovInput mi = new MarkovInput(new List<string>() { "Test1" });

            mi.Add(add);

            Assert.IsTrue(mi.Values[1].Equals(add.ToLower()));
        }

        [Test()]
        public void MarkovInput_CorrectLetterFrequencyReturned()
        {
            char letterToFind = 'm';
            List<string> freqInput = new List<string>() { "mad", "map", "dam" };
            MarkovInput mi = new MarkovInput(freqInput);

            Assert.AreEqual(2, mi.GetLetterFrequencyByPosition(0, letterToFind));
        }

        [Test()]
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

        [Test()]
        public void MarkovInput_CorrectWordLengthOccurencesReturned()
        {
            List<string> input = new List<string>() { "cat", "dog", "duck", "horse" };
            MarkovInput mi = new MarkovInput(input);
            Assert.AreEqual(2, mi.WordLengths[3]);
            Assert.AreEqual(1, mi.WordLengths[4]);
            Assert.AreEqual(1, mi.WordLengths[5]);
        }

        [Test()]
        public void MarkovInput_CorrectNumberOfWordsReturned()
        {
            List<string> list = new List<string>() { "man", "cat", "man cat", "man cat cat man" };
            MarkovInput mi = new MarkovInput(list);

            Assert.AreEqual(2, mi.NumberOfWords[1]);
            Assert.AreEqual(1, mi.NumberOfWords[2]);
            Assert.AreEqual(1, mi.NumberOfWords[4]);
        }

        [Test()]
        public void MarkovInput_CapitalizedInputsSanitized()
        {
            string lower = "map";
            MarkovInput mi = new MarkovInput(new List<string>() { "MaP" });
            Assert.AreEqual(lower, mi.Values[0]);
        }

        [Test()]
        public void MarkovInput_CapitalizedInputsSanitizedBeforeAdded()
        {
            string test = "TEST";
            MarkovInput mi = new MarkovInput(new List<string>() { "Test" });
            mi.Add(test);
            Assert.AreEqual(test.ToLower(), mi.Values[0]);
        }

        [Test()]
        public void MarkovInput_CorrectLetterFrequenciesReturnedByStringPattern()
        {
            List<string> input = new List<string>() { "map", "man", "tap", "woman" };
            char p = 'p';
            char n = 'n';
            MarkovInput mi = new MarkovInput(input);

            Dictionary<char, int> toCompare = mi.GetLetterFrequencyByStringPattern("ma", 0);

            Assert.IsTrue(toCompare[p] == 1);
            Assert.IsTrue(toCompare[n] == 2);
        }

        [Test()]
        public void MarkovInput_LetterFrequenciesByStringPatternObserveFrequencyThreshold()
        {
            MarkovInput mi = new MarkovInput(new List<string>() { "map" });
            Dictionary<char, int> occurances = mi.GetLetterFrequencyByStringPattern("chma", 1m);
            Assert.IsTrue(occurances['p'] == 1);
        }

        [Test()]
        public void MarkovInput_FullPatternMatchReturnsNonNullResult()
        {
            string fullPattern = "test";
            List<string> input = new List<string>() { fullPattern };
            MarkovInput mi = new MarkovInput(input);
            Dictionary<char, int> occurances = mi.GetLetterFrequencyByStringPattern("test", 1m);

            foreach (KeyValuePair<char, int> pair in occurances) { Trace.WriteLine(string.Format("Key = [{0}] | Value = [{1}]", pair.Key, pair.Value)); };
            Assert.IsNotNull(occurances);
        }

        [Test()]
        public void MarkovInput_StringPatternMatchToleranceBasedOnOccurances()
        {
            List<string> inputs = new List<string>() { "man", "mana", "ana" };
            MarkovInput mi = new MarkovInput(inputs);
            Dictionary<char, int> expected = new Dictionary<char, int>();
            expected['n'] = 2;

            Dictionary<char, int> occurances = mi.GetLetterFrequencyByStringPattern("ma", 1m);

            Assert.AreEqual(expected['n'], occurances['n']);

        }

        [Test()]
        public void MarkovInput_WordLengthsDontIncludeWhitespaces()
        {
            MarkovInput mi = new MarkovInput(new List<string>() { "bads word", "bads", "word" });
            int fourCharacterWordCount = 4;
            Dictionary<int, int> wordLengths = mi.WordLengths;

            Assert.AreEqual(fourCharacterWordCount, wordLengths[4]);
        }
    }
}
