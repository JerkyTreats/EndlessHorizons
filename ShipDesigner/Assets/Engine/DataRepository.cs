using System;
using System.Collections.Generic;
using System.IO;

namespace Engine
{
	public class DataRepository
	{
		protected void BuildRepository <T> (string filePath, Dictionary<string, T> itemTypes)
		{
			string[] files = Directory.GetFiles(filePath);
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].Contains(".meta"))
					continue;

				string[] paths = files[i].Split('\\');
				string[] file = paths[paths.Length - 1].Split('.');

				if (file[1].Equals("json"))
				{
					var instance = (T) Activator.CreateInstance(typeof(T), new object[] { files[i]});
					itemTypes.Add(file[0], instance);
				}
			}
		}
	}
}
