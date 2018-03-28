using System.Collections.Generic; 
using System.IO;
using System;
using Engine.Utility;
using Company;

namespace Planet
{
	public static class PlanetFactory
	{
		public static Planet GenerateRandomPlanet(Random rnd)
		{
			List<string> inputs = JSONTools.GetJsonArrayAsList(GetPlanetNameInputFile(), "Name");
			string name = NameGenerator.GenerateMarkovName(inputs, rnd);
			PlanetResourceFactory resources = new PlanetResourceFactory(rnd);
			List<Dealership> dealerships = new List<Dealership>();

			return new Planet(name, resources.Mining, resources.Manufacturing, resources.Intellectual, dealerships);
		}

		private static string GetPlanetNameInputFile()
		{
			string currentDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
			return Util.CombinePath(currentDir, "Assets", "Planet","planet_input.json");
		}
	}
}