using UnityEngine;
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
			StreamReader file = File.OpenText(path);
			string jsonString = file.ReadToEnd();
			Debug.Log(jsonString);
			return JSON.Parse(jsonString);
		}			
		
	}
}