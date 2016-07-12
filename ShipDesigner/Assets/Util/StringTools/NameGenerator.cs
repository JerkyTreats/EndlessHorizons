using System;
using System.IO;
using System.Collections.Generic;

namespace Util
{
	public static class NameGenerator
	{
		public static string GenerateMarkovName(string inputFile, string identifier)
		{
			if (File.Exists(inputFile))
			{
				var inputNames = JSONTools.GetJsonFileArray(inputFile, identifier);
				
			}

			return null;
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