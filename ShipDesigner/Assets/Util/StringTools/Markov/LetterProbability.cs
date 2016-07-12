using SimpleJSON;
using System;

namespace Markov
{
	public class LetterProbability
	{
		private int m_weight;

		public char Letter { get; set; }
		public int Occurances { get; set; }
		public int Total { get; set; }
		public int Weight { get { return m_weight; } }

		public LetterProbability() { }

		public LetterProbability(char letter, int occurances, int total, int wholeNumberMultiplier, int decimalRoundAmount)
		{
			Letter = letter;
			Occurances = occurances;
			Total = total;

			SetWeight(wholeNumberMultiplier, decimalRoundAmount);
		}

		private void SetWeight(int wholeNumberMultiplier, int decimalRoundAmount)
		{
			if (Occurances == 0)
			{ 
				m_weight = 0;
				return;
			}

			decimal probability = (Occurances / Total);
			probability = Math.Round(probability, decimalRoundAmount);
			probability *= wholeNumberMultiplier;

			m_weight = decimal.ToInt32(probability);
		}

	}
}