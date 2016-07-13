using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Markov
{
	public class MarkovGenerator
	{
		private static char[] LETTERS = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
		private static int WHOLE_NUMBER_MULTIPLIER = 1000;
		private static decimal LETTER_TOLERANCE_AMOUNT = 6m / 100m;
		private static int REAL_OCCURANCE_MULTIPLIER = 1000;
		private Random Random;
		private MarkovInput Inputs;

		public MarkovGenerator(List<string> inputArr, Random rnd)
		{
			Inputs = new MarkovInput(inputArr);
			Random = rnd;
		}

		public string GenerateName()
		{
			int numberOfWordsInName = GetNumberOfWords();
			Trace.WriteLine(string.Format("Number of words in name = [{0}]", numberOfWordsInName+1));
			StringBuilder builder = new StringBuilder();

			builder.Append(ChooseFirstLetter()); //get first letter by frequency
			
			for (int i = 0; i < numberOfWordsInName; i++)
			{
				int wordLength = GetWordLength();
				Trace.WriteLine(string.Format("Word [{0}] Length = [{1}]", i, wordLength));
				for (int l = 1; l <= wordLength; l++)
				{
					string currentName = builder.ToString();
					ProbabilityManager<char> pm = new ProbabilityManager<char>(WHOLE_NUMBER_MULTIPLIER);

					Dictionary<char, int> pattern = Inputs.GetLetterFrequencyByStringPattern(currentName, LETTER_TOLERANCE_AMOUNT);

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
					Trace.WriteLine(builder.ToString());
				}
				builder.Append(" ");
			}

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
