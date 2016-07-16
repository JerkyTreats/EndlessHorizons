using System;
using System.IO;
using Markov;
using System.Collections.Generic;

namespace Util
{
	public static class NameGenerator
	{
		public static string GenerateMarkovName(List<string> inputList, Random rnd)
		{
			MarkovGenerator mg = new MarkovGenerator(inputList, rnd);
			return StringTools.CaptializeString(mg.GenerateString());
		}

		public static string GenerateRandomName(string inputFile, string identifier)
		{
			if (File.Exists(inputFile))
			{
				string input  = GetRandomJSONNode(inputFile, identifier);
				string name = StringTools.RandomizeString(input);
				return name;
			}
			return null;
		}
		
		private static string GetRandomJSONNode(string JSONFilePath, string identifier)
		{
			var names = JSONTools.GetJsonFileArray(JSONFilePath, identifier);

			Random rnd = new Random();
			int next = rnd.Next(0, (names.Count-1));

			string text = names[next][identifier].Value;
			return text;
		}		
	}
}