using System;
using System.IO;
using Markov;
using System.Collections.Generic;

namespace Util
{
	public static class NameGenerator
	{
		public static string GenerateMarkovName(string inputFile, string identifier, Random rnd)
		{
			string name = null;
			if (File.Exists(inputFile))
			{
				var inputNames = JSONTools.GetJsonFileArray(inputFile, identifier);
				List<string> inputList = new List<string>();
				for (int i =0; i< inputNames.Count; i++)
				{
					inputList.Add(inputNames[i][identifier]);
				}
				MarkovGenerator mg = new MarkovGenerator(inputList, rnd);
				string lowerName = mg.GenerateName();
				string[] words = lowerName.Trim().Split();
				for (int i = 0; i < words.Length; i++)
				{
					string firstLetter = words[i][0].ToString().ToUpper();
					if (i == 0)
						name += string.Format("{0}{1}", firstLetter, words[i].Substring(1));
					else 
						name += string.Format(" {0}{1}",firstLetter,words[i].Substring(1));
				}
			}
			return name;
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