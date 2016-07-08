using System;
using System.Collections.Generic;
using Ship;
using Planet;
using Company.Personel;

namespace Company
{
	public class ShipCompany
	{
		public List<Ship.Ship> Prototypes { get; set; }
		public List<Ship.Blueprint> Blueprints { get; set; }
		public Planet.Planet Headquarters { get; set; }
		public int Credits { get; set; }
		public List<Employee> Employees { get; set; }
	}
}