using System.Collections.Generic;
using System.IO;
using SimpleJSON;

namespace Engine.Utility
{
	public static class JSONTools
	{		
		public static JSONNode GetJSONNode(string jsonPath)
		{
			string path = @""+jsonPath;

			if(File.Exists(path))
			{
				StreamReader file = File.OpenText(path);
				string jsonString = file.ReadToEnd();
				return JSON.Parse(jsonString);
			}
			else
				return null;
		}	
		
		public static JSONArray GetJsonFileArray(string jsonPath, string identifier)
		{

			JSONNode input = GetJSONNode(jsonPath);
			var inputArr = input[identifier + "s"].AsArray;
			return inputArr;
		}		
		
		public static List<string> GetJsonArrayAsList(string jsonPath, string identifier)
		{
			List<string> list = new List<string>();
			JSONArray arr = GetJsonFileArray(jsonPath, identifier);
			for (int i = 0; i < arr.Count; i++)
			{
				string test = arr[i][identifier];
				list.Add(test);
			}
			return list;
		}
	}
}