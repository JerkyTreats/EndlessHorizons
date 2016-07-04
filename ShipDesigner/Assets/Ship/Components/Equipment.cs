using System;
using UnityEngine;

namespace Ship.Components
{
	public class Equipment
	{
		public string Purpose { get; set; }
		public int Cost {get; set;}
		public int Crew { get; set; }
		public float Weight { get; set; }
		public int Power { get; set; }
	}
}