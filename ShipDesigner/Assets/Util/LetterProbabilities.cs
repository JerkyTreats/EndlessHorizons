using System.Collections.Generic;

namespace Markov
{
	internal class LetterProbabilities
	{
		private List<LetterProbability> m_lps;

		public List<LetterProbability> LetterProbabilityList
		{
			get { return m_lps; }
		}
		
		public LetterProbabilities()
		{
			m_lps = new List<LetterProbability>();
		}

		public LetterProbabilities(List<LetterProbability> lps)
		{
			m_lps = lps;
		}

		public int GetTotalWeight()
		{
			int total = 0;
			for (int i = 0; i < Count; i++)
			{
				total += m_lps[i].Weight;
			}

			return total;
		}

		public void Add(LetterProbability lp)
		{
			m_lps.Add(lp);
		}

		public int Count
		{
			get { return m_lps.Count; }
		}

	}
}