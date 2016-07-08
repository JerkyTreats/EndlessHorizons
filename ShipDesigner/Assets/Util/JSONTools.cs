using System.Collections.Generic;
using System;
using System.IO;
using SimpleJSON;

namespace Util
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
			{
				return null;
			}

		}	
		
		public static JSONArray GetJsonFileArray(string jsonPath, string identifier)
		{

			JSONNode input = GetJSONNode(jsonPath);
			var inputArr = input[identifier + "s"].AsArray;
			return inputArr;
		}		
		
	}
}