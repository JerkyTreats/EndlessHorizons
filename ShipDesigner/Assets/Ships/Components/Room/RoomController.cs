using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Components
{
	public class Room
	{
		public List<EquipmentComponent> Equipment { get; set; }
		public List<TileComponent> Tiles { get; set;}
		public List<DoorComponent> Doors { get; set; }
		public Material Material { get; set; }
		public float Weight { get; set; }
		public int Power { get; set; }
		public int Crew { get; set; }
		public int Cost { get; set; }
	}
}