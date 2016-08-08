using UnityEngine;
using System.IO;

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
	}
}
