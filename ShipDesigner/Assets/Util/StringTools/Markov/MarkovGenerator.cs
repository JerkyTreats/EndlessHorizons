using System;
using System.Collections.Generic;
using System.Text;
using SimpleJSON;
using System.Linq;

namespace Markov
{
	public class MarkovGenerator
	{
		private static char[] LETTERS = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
		private static int WHOLE_NUMBER_MULTIPLIER = 1000;
		private static int DECIMAL_ROUND_AMOUNT = 3;

		private string CurrentWord;
		private string CurrentStringPattern;
		private Random Random;
		private MarkovInput Inputs;

		public MarkovGenerator(List<string> inputArr, Random rnd)
		{
			Inputs = new MarkovInput(inputArr);
			Random = rnd;
		}

		public string GenerateName()
		{
			StringBuilder builder = new StringBuilder();

			builder.Append(ChooseFirstLetter()); //get first letter by frequency

			return builder.ToString();
		}

		private char ChooseFirstLetter()
		{
			LetterProbabilities lps = new LetterProbabilities(Inputs.Count, WHOLE_NUMBER_MULTIPLIER, DECIMAL_ROUND_AMOUNT);
			for (int i = 0; i < LETTERS.Length; i++)
			{
				char letter = LETTERS[i];
				int occurances = Inputs.LetterFrequency(0, letter);
				lps.Add(letter, occurances);
			}

			return lps.GetLetterByWeightedRandom(Random);
		}

		///// <summary>
		///// Determine if whitespace should be added to the name based on the number of whitespaces 
		///// </summary>
		///// <returns></returns>
		//private bool AddWhitespace()
		//{
			
		//	Dictionary<int, int> whitespaceCount = new Dictionary<int, int>();
		//	List<int> numberofWords = new List<int>();
		//	for (int i = 0; i < InputList.Count; i++)
		//	{
		//		int whitespaces = (InputList[i].Trim()).Count(Char.IsWhiteSpace);

		//		if (!whitespaceCount.ContainsKey(whitespaces))
		//			whitespaceCount[whitespaces] = 0;
		//		whitespaceCount[whitespaces]++;

		//	}

		//	return false;
		//}

		///// <summary>
		/////	Counts the frequency of a letter from a list of string inputs to generate a weighted probability for each allowable letter
		///// </summary>
		///// <returns> Random weighted char selection </returns>
		//private char GetLetterByFrequency(int position)
		//{
		//	LetterProbabilities Probabilities = new LetterProbabilities(InputList.Count, WHOLE_NUMBER_MULTIPLIER, DECIMAL_ROUND_AMOUNT);
		//	List<char> firstLettersFromInput = new List<char>();

		//	//generate array of first letter of each input list.
		//	for (int i = 0; i < InputList.Count; i++)
		//	{
		//		var chars = (InputList[i].ToLower()).ToCharArray();
		//		firstLettersFromInput.Add(chars[position]);
		//	}
			
		//	for (int l = 0; l < LETTERS.Length; l++)
		//	{
		//		int firstLetterCount = 0;

		//		//count the instances the selected letter matches the first letter of the input list
		//		for (int c = 0; c < firstLettersFromInput.Count; c++)
		//		{
		//			if (firstLettersFromInput[c] == LETTERS[l])
		//				firstLetterCount++; 
		//		}

		//		Probabilities.Add(LETTERS[l], firstLetterCount);
		//	}

		//	return Probabilities.GetLetterByWeightedRandom(Random);
		//}
	}
}
