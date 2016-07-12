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
		/// <returns>less than zero decimal</returns>
		public int LetterFrequency(int letterPosition, char letterToMatch)
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
					int wordLength = m_input[i].ToCharArray().Length;
					if (!occurances.ContainsKey(wordLength))
						occurances[wordLength] = 0;
					occurances[wordLength]++;
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
