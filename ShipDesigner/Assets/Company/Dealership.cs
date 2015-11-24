using System;
using System.Collections.Generic;
using Ship;

namespace Company
{
	class Dealership
	{
		public List<Ship.Ship> AvailableStock { get; set; }
		public DealershipCompany Company {get; set;}
		public float DealershipMarkup { get; set; }
		//public ToDo Prosperity { get; set; }
		public Dictionary<Ship.Ship, Receipt> SellHistory {get; set; }
	}
}