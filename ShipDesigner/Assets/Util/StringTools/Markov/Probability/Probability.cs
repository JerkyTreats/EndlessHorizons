using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Markov
{
	public class Probability<T>
	{
		public T Value { get; set; }
		public int Occurances { get; set; }

		public Probability(T value, int occurances)
		{
			Value = value;
			Occurances = occurances;
		}

		public int GetWeight(int wholeNumberMultiplier, int total)
		{
			return ((Occurances * wholeNumberMultiplier) / total);
		}

	}
}
