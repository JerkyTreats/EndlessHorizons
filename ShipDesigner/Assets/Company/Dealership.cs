using System;
using System.Collections.Generic;

namespace Company
{
	class Dealership
	{
		public List<Ship> AvailableStock { get; set; }
		public DealershipCompany Company {get; set;}
		public float DealershipMarkup { get; set; }
		//public ToDo Prosperity { get; set; }
		public Dict<Ship, Receipt> SellHistory {get; set; }
	}
}