using System;
using System.Collections.Generic;
using Ships;
using Planet;
using Company.Personel;

namespace Company
{
	public class ShipCompany
	{
		public List<Ships.Ship> Prototypes { get; set; }
		public List<Ships.Blueprint> Blueprints { get; set; }
		public Planet.Planet Headquarters { get; set; }
		public int Credits { get; set; }
		public List<Employee> Employees { get; set; }
	}
}