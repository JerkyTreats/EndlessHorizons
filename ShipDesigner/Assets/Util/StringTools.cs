using System.Collections;
using System.Collections.Generic;
using System;

namespace Common.Util
{
	public static class StringTools
	{
		static string consonants = "bcdfghjklmnpqrstvwxyz";
		static string vowels = "aeiou";
		
		///	Takes a string and randomizes each character
		public static string RandomizeString(string inString)
		{
			string[] arr = inString.Split();
			List<string> returnArr  = new List<string>();
		
			foreach (string letter in arr)
			{
				if(vowels.IndexOf(letter)!=-1)
				{
					string l = ShiftString(vowels, letter);
					returnArr.Add(l);
				} 
				else if (consonants.IndexOf(letter)!=-1)
				{
					string l = ShiftString(consonants, letter);
					returnArr.Add(l);
				}
				else
				{
					returnArr.Add(letter);
				}
			}
			string toReturn = string.Join("",returnArr.ToArray());
			return toReturn;
		}
		
		private static string ShiftString(string strLibrary, string letter)
		{
			int indexLimit = strLibrary.Length;
			Random rnd = new Random(); 
			int shift = rnd.Next(1,(indexLimit -1));
			int startIndex = strLibrary.IndexOf(letter);
			
			if ((startIndex + shift) > indexLimit)
			{
				shift = shift - (indexLimit - startIndex);
			}
			
			return strLibrary.Substring(shift,0);
		}
	}
}