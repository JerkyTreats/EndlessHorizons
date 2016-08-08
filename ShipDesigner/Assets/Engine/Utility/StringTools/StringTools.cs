using System.Threading;
using System.Collections.Generic;
using System;
using System.Text;

namespace Engine.Utility
{
	public static class StringTools
	{
		static string consonants = "bcdfghjklmnpqrstvwxz";
		static string vowels = "aeiouy";

		/// <summary>
		/// Takes a string and randomizes each character, consonants and vowels keeping their type
		/// </summary>
		public static string RandomizeString(string inString)
		{
			char[] arr = inString.ToLower().ToCharArray();
			StringBuilder randomizedString = new StringBuilder();
			Random rnd = new Random();

			List<char> returnArr  = new List<char>();
		
			foreach (char letter in arr)
			{
				if(vowels.IndexOf(letter)!=-1)
				{
					char c = ShiftChar(rnd, vowels, letter);
					randomizedString.Append(c);
				} 
				else if (consonants.IndexOf(letter)!=-1)
				{
					char c = ShiftChar(rnd, consonants, letter);
					randomizedString.Append(c);
				}
				else
				{
					randomizedString.Append(letter);
				}
			}
			return randomizedString.ToString();
		}

		/// <summary>
		/// Takes a string and capitalizes the first letter of every word
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string CaptializeString(string str)
		{
			string toReturn = null;
			string[] words = str.Trim().Split();
			for (int i = 0; i < words.Length; i++)
			{
				string firstLetter = words[i][0].ToString().ToUpper();
				if (i == 0)
					toReturn += string.Format("{0}{1}", firstLetter, words[i].Substring(1));
				else
					toReturn += string.Format(" {0}{1}", firstLetter, words[i].Substring(1));
			}

			return toReturn;
		}

		private static char ShiftChar(Random rnd, string strLibrary, char letter)
		{
			char[] charLib = strLibrary.ToCharArray();
			int indexLimit = (charLib.Length -1);
			int startIndex = Array.IndexOf(charLib, letter);

			int shift = rnd.Next(1,indexLimit); //start at 1 to enforce at least one letter offset
			
			if ((startIndex + shift) > indexLimit)
			{
				shift = shift - (indexLimit - startIndex);
			}
			
			return charLib[shift];
		}
	}
}