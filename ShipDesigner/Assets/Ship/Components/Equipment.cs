using System;
using UnityEngine;

namespace Ship.Components
{
	class Equipment
	{
		public string Purpose { get; set; }
		public Cost Cost {get; set;}
		public int Crew { get; set; }
		public float Weight { get; set; }
		public int Power { get; set; }
	}
}