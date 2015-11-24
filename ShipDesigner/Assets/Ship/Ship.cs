using System;
using UnityEngine;

namespace Ship
{
	class Ship
	{
		public float Weight { get; set; }
		public Cost Cost {get; set;} 
		public bool IsPrototype { get; set; }
		public float Speed {get; set; }
		public int Durability { get; set; }
		public Category Category { get; set; }
		public Blueprint Blueprint {get; set; }
	}
}