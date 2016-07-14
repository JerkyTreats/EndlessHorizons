using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Markov
{
	/// <summary>
	/// Builds strings via a Markov Chain
	/// </summary>
	public class MarkovGenerator
	{
		private static char[] LETTERS = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
		private static int WHOLE_NUMBER_MULTIPLIER = 1000;
		private static decimal LETTER_TOLERANCE_AMOUNT = 20m / 100m;
		private static int REAL_OCCURANCE_MULTIPLIER = 950;

		private Random Random;
		private MarkovInput Inputs;

		/// <summary>
		/// Construct a MarkovGenerator object, using a list of strings to generate new strings
		/// </summary>
		/// <param name="inputs">list of strings to convert into a MarkovInput </param>
		/// <param name="rnd">Random object to use</param>
		public MarkovGenerator(List<string> inputs, Random rnd)
		{
			Inputs = new MarkovInput(inputs);
			Random = rnd;
		}

		/// <summary>
		/// Build a string using the frequency of letters from the Input object
		/// </summary>
		/// <returns></returns>
		public string GenerateString()
		{
			StringBuilder builder = new StringBuilder();
			int numberOfWordsInName = GetNumberOfWords();

			for (int i = 0; i < numberOfWordsInName; i++)
			{
				string word = BuildWord(GetWordLength());
				builder.Append(word);
			}

			return builder.ToString().Trim();
		}

		private string BuildWord(int wordLength)
		{
			StringBuilder builder = new StringBuilder();

			for (int l = 1; l <= wordLength; l++)
			{
				ProbabilityManager<char> pm = new ProbabilityManager<char>(WHOLE_NUMBER_MULTIPLIER);

				Dictionary<char, int> pattern = Inputs.GetLetterFrequencyByStringPattern(builder.ToString(), LETTER_TOLERANCE_AMOUNT);

				int baseProbabiltity = WHOLE_NUMBER_MULTIPLIER / LETTERS.Length;
				for (int c = 0; c < LETTERS.Length; c++)
				{
					char letter = LETTERS[c];
					int occurances = baseProbabiltity;
					if (pattern.ContainsKey(letter))
						occurances += (pattern[letter] * REAL_OCCURANCE_MULTIPLIER);
					pm.Add(letter, occurances);
				}

				builder.Append(pm.GetWeightedRandomValue(Random));
			}
			builder.Append(" ");
			return builder.ToString();
		}

		private int GetNumberOfWords()
		{
			ProbabilityManager<int> pm = new ProbabilityManager<int>(WHOLE_NUMBER_MULTIPLIER);
			foreach (KeyValuePair<int,int> pair in Inputs.NumberOfWords)
			{
				pm.Add(pair.Key, pair.Value);
			}

			return pm.GetWeightedRandomValue(Random);
		}

		private char ChooseFirstLetter()
		{
			ProbabilityManager<char> lps = new ProbabilityManager<char>(WHOLE_NUMBER_MULTIPLIER);
			for (int i = 0; i < LETTERS.Length; i++)
			{
				char letter = LETTERS[i];
				int occurances = Inputs.GetLetterFrequencyByPosition(0, letter);
				lps.Add(letter, occurances);
			}

			return lps.GetWeightedRandomValue(Random);
		}

		private int GetWordLength()
		{
			ProbabilityManager<int> manager = new ProbabilityManager<int>(WHOLE_NUMBER_MULTIPLIER);
			foreach(KeyValuePair<int,int> pair in Inputs.WordLengths)
			{
				manager.Add(pair.Key, pair.Value);
			}

			return manager.GetWeightedRandomValue(Random);
		}
	}
}
