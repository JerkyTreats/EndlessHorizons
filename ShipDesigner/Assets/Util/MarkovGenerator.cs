using System;
using System.Collections.Generic;
using System.Text;
using SimpleJSON;

namespace Markov
{
	public class MarkovGenerator
	{
		private static char[] LETTERS = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

		private string CurrentWord;
		private string CurrentStringPattern;
		private Random Random;

		private List<string> InputList;
		private LetterProbabilities Probabilities; 

		public MarkovGenerator(JSONArray inputArr, string identifier)
		{	
			for(int i = 0; i < inputArr.Count; i++)
			{
				InputList.Add(inputArr[i][identifier].Value);
			}

			Random = new Random();
		}

		public string GenerateName()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(GetFirstLetter());

			return builder.ToString();
		}

		private char GetFirstLetter()
		{
			List<char> firstLettersFromInput = new List<char>();

			for (int i = 0; i < InputList.Count; i++)
			{
				var chars = InputList[i].ToCharArray();
				firstLettersFromInput.Add(chars[0]);
			}
			
			for (int l = 0; l < LETTERS.Length; l++)
			{
				LetterProbability lp = new LetterProbability();
				lp.Letter = LETTERS[l];
				int firstLetterCount = 0;

				for (int c = 0; c < firstLettersFromInput.Count; c++)
				{
					if (firstLettersFromInput[c] == LETTERS[l])
						firstLetterCount++; 
				}

				if (firstLetterCount == 0)
					lp.Weight = 0;
				else
				{
					decimal p = firstLetterCount / InputList.Count;
					p = Math.Round(p, 3) * 1000;
					int probability = (int)p;
					lp.Weight = probability;
				}

				Probabilities.Add(lp);
			}

			return ChooseLetter();
		}

		private char ChooseLetter()
		{
			int totalWeight = Probabilities.GetTotalWeight();
			int randomNumber = Random.Next(0, totalWeight);

			LetterProbability selected = null;

			for (int i = 0; i < Probabilities.Count; i++)
			{
				if (randomNumber < Probabilities.LetterProbabilityList[i].Weight)
				{
					selected = Probabilities.LetterProbabilityList[i];
					break;
				}

				randomNumber -= Probabilities.LetterProbabilityList[i].Weight;
			}

			return selected.Letter;
		}
	}
}
