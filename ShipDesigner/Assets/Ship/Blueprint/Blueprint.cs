using System;
using System.Collections.Generic;
using Ship.Components;

namespace Ship
{
	class Blueprint
	{
		public List<Room> Rooms { get; set; }
		public bool IsComplete { get; set; }
		public float Weight { get; set; }
		public int Speed {get; set; }
		public int Durability {get; set; }
		public ShipCategory Category {get; set;}
		public int Crew {get; set;}
		public int Cost { get; set; }
		
	}
}