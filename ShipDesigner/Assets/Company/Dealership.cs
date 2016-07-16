using System;
using System.Collections.Generic;
using Ships;

namespace Company
{
	public class Dealership
	{
		public List<Ship> AvailableStock { get; set; }
		public DealershipCompany Company {get; set;}
		public float DealershipMarkup { get; set; }
		//public ToDo Prosperity { get; set; }
		public Dictionary<Ship, Receipt> SellHistory {get; set; }
	}
}