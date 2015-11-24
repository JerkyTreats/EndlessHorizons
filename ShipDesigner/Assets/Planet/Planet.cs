using System;
using System.Collections.Generic; 
using Company;

namespace Planet
{
	class Planet
	{
		public int MiningLevel { get; set; }
		public int ManufacturingLevel { get; set; }
		public int IntellectualLevel { get; set; }
		
		//public TODO GalacticLocation {get; set; }
		
		public List<Company.Dealership> ShipDealerships { get; set; }
	}
}