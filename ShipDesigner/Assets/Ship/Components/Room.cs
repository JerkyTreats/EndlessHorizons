using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ship.Components
{
	class Room
	{
		public List<Equipment> Equipment { get; set; }
		public List<Tile> Tiles { get; set;}
		public List<Door> Doors { get; set; }
		public Material Material { get; set; }
		public float Weight { get; set; }
		public int Power { get; set; }
		public int Crew { get; set; }
		public int Cost { get; set; }
	}
}