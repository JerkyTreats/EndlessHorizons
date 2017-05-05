using System.IO;
using System;
using UnityEngine;

namespace Engine.Utility
{
	public static class Util
	{
		/// <summary>
		/// Custom path combiner because .NET 3.5 doesn't have it- Unity only works on 3.5 ¯\_(ツ)_/¯
		/// </summary>
		/// <param name="first"></param>
		/// <param name="others"></param>
		public static string CombinePath(string first, params string[] others)
		{
			string path = first;
			foreach (string section in others)
			{
				path = Path.Combine(path, section);
			}
			return path;
		}

		/// <summary>
		/// Convenience method to concat the project root dir with an array of folders to walk down.
		/// </summary>
		/// <param name="folders">string array of folders in order. 'Assets' will likely be first.</param>
		/// <returns></returns>
		public static string GetRelativePath(params string[] folders)
		{
			return CombinePath(Application.streamingAssetsPath, folders);
		}

		/// <summary>
		/// Converts string into Enum
		/// </summary>
		/// <typeparam name="T">Enum to look for value</typeparam>
		/// <param name="value">string Value to convert to Enum value</param>
		/// <returns></returns>
		public static T ParseEnum<T>(string value)
		{
			return (T)Enum.Parse(typeof(T), value, true);
		}

	}
}
