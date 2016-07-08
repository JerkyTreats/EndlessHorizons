using System.Collections.Generic; 
using System.IO;
using Util;
using Company;

namespace Planet
{
	public static class PlanetFactory
	{
		public static Planet GenerateRandomPlanet()
		{
			string name = NameGenerator.GenerateRandomName(GetPlanetNameInputFile(),"Name");
			PlanetResourceFactory resources = new PlanetResourceFactory();
			List<Dealership> dealerships = null;

			return new Planet(name, resources.Mining, resources.Manufacturing, resources.Intellectual, dealerships);
		}

		private static string GetPlanetNameInputFile()
		{
			string currentDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
			return Path.Combine(currentDir, @"planet\planet_input.json");
		}
	}
}