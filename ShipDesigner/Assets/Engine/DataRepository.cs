using System;
using System.Collections.Generic;
using System.IO;

namespace Engine
{
	/// <summary>
	/// Base class for data repositories, providing functions to instantiate data objects
	/// </summary>
	public class DataRepository
	{
		/// <summary>
		/// Searches a folder for all instances of JSON files and creates objects the data therein
		/// </summary>
		/// <typeparam name="T">JSON Object?</typeparam>
		/// <param name="filePath">Path to search through. Recursive not tested.</param>
		/// <param name="itemTypes">String/Type dictionary to fill</param>
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
