using System;
using System.Collections.Generic;

namespace Company
{
	class ShipCompany
	{
		public List<Ship> Prototypes { get; set; }
		public List<Blueprint> Blueprints { get; set; }
		public Planet Headquarters { get; set; }
		public int Credits { get; set; }
		public List<Employee> Employees { get; set; }
	}
}