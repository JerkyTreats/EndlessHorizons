using System.Collections.Generic;
using System;

namespace Markov
{
	public class ProbabilityManager<T>
	{
		private List<Probability<T>> m_probability;
		private int m_wholeNumberMultiplier;

		#region Constructors

		public ProbabilityManager(int wholeNumberMultiplier)
		{
			m_probability = new List<Probability<T>>();
			m_wholeNumberMultiplier = wholeNumberMultiplier;
		}

		#endregion

		#region PublicFunctions       

		public int GetTotalWeight()
		{
			int total = 0;
			for (int i = 0; i < Count; i++)
			{
				total += m_probability[i].GetWeight(m_wholeNumberMultiplier, Total);
			}

			return total;
		}

		public T GetWeightedRandomValue(Random rnd)
		{
			int totalWeight = GetTotalWeight();
			int randomNumber = rnd.Next(0, totalWeight);
			Probability<T> selected = null;

			for (int i = 0; i < Count; i++)
			{
				Probability<T> p = Values[i];
				int valueTotal = p.GetWeight(m_wholeNumberMultiplier, Total);
				if (randomNumber < valueTotal)
				{
					selected = p;
					break;
				}

				randomNumber -= valueTotal;
			}

			return selected.Value;

		}

		#endregion
		#region ExtendedProperties

		public void Add(T value, int occurances)
		{
			m_probability.Add(new Probability<T>(value, occurances));
		}

		public int Count
		{
			get { return m_probability.Count; }
		}

		public int Total
		{
			get
			{
				int total = 0;
				for (int i = 0; i < m_probability.Count; i++)
				{
					total += m_probability[i].Occurances;
				}
				return total;
			}
		}

		public List<Probability<T>> Values
		{
			get{ return m_probability; }
		}

		public int WholeNumberMultiplier
		{
			set { m_wholeNumberMultiplier = value; }
		}


		#endregion
	}
}