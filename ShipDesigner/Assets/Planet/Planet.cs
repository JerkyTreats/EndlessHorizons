using System;
using System.Collections.Generic; 
using Company;

namespace Planet
{
	public class Planet
	{
		public string Name { get; set; }
		public int MiningLevel { get; set; }
		public int ManufacturingLevel { get; set; }
		public int IntellectualLevel { get; set; }
		
		//public TODO GalacticLocation {get; set; }
		
		public List<Dealership> ShipDealerships { get; set; }

		public Planet(string Name, int MiningLevel, int ManufacturingLevel, int IntellectualLevel, List<Dealership> ShipDealerships)
		{
			this.Name = Name;
			this.MiningLevel = MiningLevel;
			this.ManufacturingLevel = ManufacturingLevel;
			this.IntellectualLevel = IntellectualLevel;
			this.ShipDealerships = ShipDealerships;
		}
	}
}