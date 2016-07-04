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
			string name = NameGenerator.GenerateName(GetPlanetNameInputFile());
			PlanetResourceFactory resources = new PlanetResourceFactory();
			List<Dealership> dealerships = null;

			return new Planet(name, resources.Mining, resources.Manufacturing, resources.Intellectual, dealerships);
		}

		private static string GetPlanetNameInputFile()
		{
			return Path.Combine(Directory.GetCurrentDirectory(), ("planet_input.json"));
		}
	}
}