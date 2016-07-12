using System.Collections.Generic;
using System;

namespace Markov
{
	public class LetterProbabilities
	{
		private List<LetterProbability> m_lps;
		private int m_total;
		private int m_wholeNumberMultiplier;
		private int m_decimalRoundAmount;

		#region Constructors

		//public LetterProbabilities()
		//{
		//	m_lps = new List<LetterProbability>();
		//}

		//public LetterProbabilities(int total)
		//{
		//	m_lps = new List<LetterProbability>();
		//	m_total = total;
		//}

		public LetterProbabilities(int total, int wholeNumberMultiplier, int decimalRoundAmount)
		{
			m_lps = new List<LetterProbability>();
			m_total = total;
			m_wholeNumberMultiplier = wholeNumberMultiplier;
			m_decimalRoundAmount = decimalRoundAmount;
		}

		#endregion

		#region PublicFunctions       

		public int GetTotalWeight()
		{
			int total = 0;
			for (int i = 0; i < Count; i++)
			{
				total += m_lps[i].Weight;
			}

			return total;
		}

		public char GetLetterByWeightedRandom(Random rnd)
		{
			int totalWeight = GetTotalWeight();
			int randomNumber = rnd.Next(1, totalWeight);
			LetterProbability selected = null;

			for (int i = 0; i < Count; i++)
			{
				if (randomNumber < LetterProbabilityList[i].Weight)
				{
					selected = LetterProbabilityList[i];
					break;
				}

				randomNumber -= LetterProbabilityList[i].Weight;
			}

			return selected.Letter;
		}

		#endregion

		#region ExtendedProperties

		public void Add(LetterProbability lp)
		{
			m_lps.Add(lp);
		}

		public void Add(char letter, int occurances)
		{
			m_lps.Add(new LetterProbability(letter, occurances, m_total, m_wholeNumberMultiplier, m_decimalRoundAmount));
		}

		public int Count
		{
			get { return m_lps.Count; }
		}

		public int Total
		{
			get { return m_total; }
			set { m_total = value; }
		}

		public List<LetterProbability> LetterProbabilityList
		{
			get { return m_lps; }
			set { m_lps = value; }
		}

		public int WholeNumberRoundAmount
		{
			set { m_wholeNumberMultiplier = value; }
		}

		public int Decimal
		{
			set { m_decimalRoundAmount = value; }
		}


		#endregion
	}
}