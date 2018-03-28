using NUnit.Framework;
using System;
using Planet;

namespace ShipDesignerUnitTests
{
    [TestFixture()]
    public class Planet_Test
    {
        [Test()]
        public void PlanetFactory_FactoryReturnsPlanetObject()
        {
            Planet.Planet p = PlanetFactory.GenerateRandomPlanet(new Random());
            Assert.IsNotNull(p);
        }

        [Test()]
        public void PlanetFactory_ReturnedPlanetNameIsNotNull()
        {
            Planet.Planet p = PlanetFactory.GenerateRandomPlanet(new Random());
            Assert.IsNotNull(p.Name);
        }

        [Test()]
        public void PlanetFactory_ReturnedPlanetResourceLevelsNotAboveBounds()
        {
            Planet.Planet p = PlanetFactory.GenerateRandomPlanet(new Random());
            bool withinBounds = true;

            if (p.MiningLevel > 100 || p.ManufacturingLevel > 100 || p.IntellectualLevel > 100 || (p.MiningLevel + p.ManufacturingLevel + p.IntellectualLevel) > 100)
                withinBounds = false;

            Assert.IsTrue(withinBounds);
        }

        [Test()]
        public void PlanetFactory_ReturnedPlanetShipDealershipNotNull()
        {
            Planet.Planet p = PlanetFactory.GenerateRandomPlanet(new Random());
            Assert.IsNotNull(p.ShipDealerships);
        }
    }
}
