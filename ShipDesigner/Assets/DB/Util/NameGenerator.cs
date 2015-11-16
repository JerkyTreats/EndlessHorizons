using Common.Util;

namespace DB
{
	public static class NameGenerator
	{
		public static string GenerateName(string inputName)
		{
			return StringTools.RandomizeString(inputName);
		}
		
		public static string[] GenerateStringArrayFromJSON(string jsonPath)
		{
			
		}
	}
}