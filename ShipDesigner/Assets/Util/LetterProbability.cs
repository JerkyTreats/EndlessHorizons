using SimpleJSON;

namespace Markov
{
	internal class LetterProbability
	{
		public char Letter { get; set; }
		public int Weight { get; set; }

		public LetterProbability(char letter, int weight)
		{
			Letter = letter;
			Weight = weight;
		}

		public LetterProbability() { }


	}
}