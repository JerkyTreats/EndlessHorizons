using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planet;
using System.Diagnostics;

namespace ShipDesignerUnitTests
{
	[TestClass]
	public class Planet_Test
	{
		[TestMethod]
		public void PlanetFactory_FactoryReturnsPlanetObject()
		{
			Planet.Planet p = PlanetFactory.GenerateRandomPlanet(new Random());
			Assert.IsNotNull(p);
		}

		[TestMethod]
		public void PlanetFactory_ReturnedPlanetNameIsNotNull()
		{
			Planet.Planet p = PlanetFactory.GenerateRandomPlanet(new Random());
			Assert.IsNotNull(p.Name);
		}

		[TestMethod]
		public void PlanetFactory_ReturnedPlanetResourceLevelsNotAboveBounds()
		{
			Planet.Planet p = PlanetFactory.GenerateRandomPlanet(new Random());
			bool withinBounds = true;

			if (p.MiningLevel > 100 || p.ManufacturingLevel > 100 || p.IntellectualLevel > 100 || (p.MiningLevel + p.ManufacturingLevel + p.IntellectualLevel) > 100)
				withinBounds = false;

			Assert.IsTrue(withinBounds);
		}

		[TestMethod]
		public void PlanetFactory_ReturnedPlanetShipDealershipNotNull()
		{
			Planet.Planet p = PlanetFactory.GenerateRandomPlanet(new Random());
			Assert.IsNotNull(p.ShipDealerships);
		}
	}
}
