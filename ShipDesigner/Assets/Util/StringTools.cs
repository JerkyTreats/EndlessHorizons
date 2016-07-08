using System.Threading;
using System.Collections.Generic;
using System;
using System.Text;

namespace Util
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