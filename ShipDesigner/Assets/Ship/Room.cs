using System;
using System.Collection.Generic;
using UnityEngine;

namespace Ship.Room
{
	class Room
	{
		public List<Part> Parts { get; set; }
		public List<Tile> Tiles { get; set;}
		public List<Door> Doors { get; set; }
		public Material Material { get; set; }
		public float Weight { get; set; }
		public int Power { get; set; }
		public int Crew { get; set; }
		public int ConstructionCost { get; set; }
	}
}