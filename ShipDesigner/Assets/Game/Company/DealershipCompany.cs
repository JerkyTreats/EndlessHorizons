using System;
using System.Collections.Generic;
using Ships;

namespace Company
{
	public class DealershipCompany
	{
		public float GlobalMarkup { get; set; }
		
		public ShipCategory PreferredShipCategory { get; set; }
		public float PreferredShipCategoryWeight { get; set; }
		
		public ShipCompany PreferredShipCompany { get; set; }
		public float PrefferedShipComanyWeight { get; set; }
	}
}