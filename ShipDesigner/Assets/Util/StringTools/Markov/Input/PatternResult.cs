using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Markov
{
	class PatternResult
	{
		private int m_totalOccurances;
		private Dictionary<char, int> m_occurances;

		public Dictionary<char, int> Occurances { get { return m_occurances; } }
		public int TotalOccurances { get { return m_totalOccurances;  } }

		public PatternResult()
		{
			m_occurances = new Dictionary<char, int>();
		}

		public void AddOrUpdate(char letter)
		{
			if (!m_occurances.ContainsKey(letter))
				m_occurances[letter] = 0;
			m_occurances[letter]++;

			m_totalOccurances++;
		}
	}
}
