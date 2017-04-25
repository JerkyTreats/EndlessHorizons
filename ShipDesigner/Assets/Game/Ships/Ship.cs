using System;
using UnityEngine;

namespace Ships
{
	public class Ship
	{
		public float Weight { get; set; }
		public int Cost {get; set;} 
		public bool IsPrototype { get; set; }
		public float Speed {get; set; }
		public int Durability { get; set; }
		public ShipCategory Category { get; set; }
	}
}