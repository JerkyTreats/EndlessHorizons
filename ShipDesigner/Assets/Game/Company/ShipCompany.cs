using System;
using System.Collections.Generic;
using Ships;
using Company.Personel;

namespace Company
{
	public class ShipCompany
	{
		public List<Ship> Prototypes { get; set; }
		public Planet.Planet Headquarters { get; set; }
		public int Credits { get; set; }
		public List<Employee> Employees { get; set; }
	}
}