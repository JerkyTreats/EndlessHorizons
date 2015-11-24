using System;
using System.Collections.Generic; 

namespace Planet
{
	class Planet
	{
		public int MiningLevel { get; set; }
		public int ManufacturingLevel { get; set; }
		public int IntellectualLevel { get; set; }
		
		//public TODO GalacticLocation {get; set; }
		
		public List<ShipDealership> ShipDealerships { get; set; }
	}
}