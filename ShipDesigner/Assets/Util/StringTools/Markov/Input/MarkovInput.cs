using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Markov
{
	/// <summary>
	/// Describes a list of string inputs and properties about those inputs
	/// </summary>
	public class MarkovInput
	{
		private List<string> m_input;

		/// <summary>
		/// A list of strings to act as the inputs for a Markov string generator
		/// </summary>
		public List<string> Values
		{
			get { return m_input; }
		}

		public MarkovInput(List<string> input)
		{
			m_input = new List<string>();
			for (int i = 0; i < input.Count; i++)
			{
				m_input.Add(input[i].ToLower());
			}
		}

		/// <summary>
		/// Returns the frequency that a letter occurs out of it's total
		/// </summary>
		/// <param name="letterPosition">Letter position to get frequency (0 = first letter)</param>
		/// <param name="letterToMatch"> Character to find the frequency of</param>
		/// <returns>Number of times the letterToMatch occurs </returns>
		public int GetLetterFrequencyByPosition(int letterPosition, char letterToMatch)
		{
			int occurances = 0;
			for (int i = 0; i < Count; i++)
			{
				char[] word = m_input[i].ToCharArray();
				if (word[0].Equals(letterToMatch))
					occurances++;
			}

			return occurances;
		}

		/// <summary>
		/// Given a string, generate a Dictionary of letters that appear after the string, and the times they occur. Has additional specification for how many results to be returned.  
		/// <para>Ie. if string "aus" doesn't generate enough results, keep dropping the first letter and try again until the number of results are found. Will return the results of a single character string even if below the minimum</para>
		/// </summary>
		/// <param name="pattern">string to look for in the input list</param>
		/// <param name="minimumResultsAsPercentageOfTotal"></param>
		/// <returns>Dictionary of the characters that appear after the string pattern, and the number of times that letter occurred</returns>
		public Dictionary<char, int> GetLetterFrequencyByStringPattern(string pattern, decimal minimumResultsAsPercentageOfTotal)
		{
			Dictionary<char, int> chosen = new Dictionary<char, int>();
			int count = 0;
			while (count < pattern.Length)
			{
				string patternToTest = pattern.Substring(count);
				PatternResult result = GetLetterFrequencyByStringPattern(patternToTest);
				bool enoughResults = MinimumResultsFound(result.TotalOccurances, minimumResultsAsPercentageOfTotal);

				if (enoughResults | patternToTest.Length == 1)
					return result.Occurances;
				count++;
			}
			return chosen;
		}

		private PatternResult GetLetterFrequencyByStringPattern(string pattern)
		{
			PatternResult result = new PatternResult();
			for(int i = 0; i < Count; i++)
			{
				string input = m_input[i];
				if (input.Contains(pattern))
				{
					int index = (input.IndexOf(pattern) + pattern.Length);
					if (index < input.Length)
					{
						result.AddOrUpdate(input[index]);
					}
				}
			}

			return result;
		}

		private bool MinimumResultsFound(decimal totalResults, decimal minimumPercentage)
		{
			decimal percentageOccurancesFound = totalResults / Count;
			decimal minimumNeeded = minimumPercentage / 100m;

			if (percentageOccurancesFound >= minimumNeeded)
				return true;
			return false;
		}

		/// <summary>
		/// Add a string to the list of inputs 
		/// </summary>
		/// <param name="toAdd"></param>
		public void Add(string toAdd)
		{
			m_input.Add(toAdd.ToLower());
		}

		/// <summary>
		/// Total number of Values;
		/// </summary>
		public int Count
		{
			get { return m_input.Count; }
		}

		/// <summary>
		/// Dictionary of the length of words (int, Key) and the frequency they appear (decimal, Value - should be less than 1)
		/// </summary>
		public Dictionary<int, decimal> WordLengthDistribution
		{
			get
			{
				Dictionary<int, decimal> toReturn = new Dictionary<int, decimal>();
				foreach (KeyValuePair<int, int> pair in WordLengths)
					toReturn[pair.Key] = (decimal)(pair.Value) / Count;
				return toReturn;
			}
		}

		/// <summary>
		/// Dictionary of the length of words (int, Key) and the number of occurances (int, Value);
		/// </summary>
		public Dictionary<int, int> WordLengths
		{
			get
			{
				Dictionary<int, int> occurances = new Dictionary<int, int>();
				
				for (int i = 0; i < Count; i++)
				{
					string[] words = m_input[i].Split();
					foreach (string word in words)
					{
						int wordLength = word.Length;
						if (!occurances.ContainsKey(wordLength))
							occurances[wordLength] = 0;
						occurances[wordLength]++;
					}
				}

				return occurances;
			}
		}

		/// <summary>
		/// Dictionary of the number of words (int, Key) and the number of occurances (int, Value)
		/// </summary>
		public Dictionary<int,int> NumberOfWords
		{
			get
			{
				Dictionary<int, int> occurances = new Dictionary<int, int>();
				for(int i = 0; i< Count; i++)
				{
					int wordCount = (m_input[i].Split()).Length;
					if (!occurances.ContainsKey(wordCount))
						occurances[wordCount] = 0;
					occurances[wordCount]++;
				}

				return occurances;
			}
		}
	}
}
