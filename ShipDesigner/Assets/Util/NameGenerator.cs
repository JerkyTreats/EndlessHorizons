using SimpleJSON;
using System;
using System.IO;
using System.Collections.Generic;

namespace Util
{
	public static class NameGenerator
	{
		public static string GenerateName(string inputFileName)
		{
			string inputFilePath = Path.Combine( Directory.GetCurrentDirectory(), (inputFileName + ".json"));
			string input  = GetRandomJSONNode(inputFilePath);
			string name = StringTools.RandomizeString(input);
			return name;
		}
		
		private static string GetRandomJSONNode(string JSONFilePath)
		{
			JSONNode json = JSONTools.GetJSONNode(JSONFilePath);
			Random rnd = new Random();
			var names = json["Names"][0]["name"];
			int next = rnd.Next(0, names.Count);
			return names[next];
		}		
	}
}