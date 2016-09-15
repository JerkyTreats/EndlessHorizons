using System;
using UnityEngine;

namespace Ships.Components
{
	public class EquipmentController
	{
		public string Purpose { get; set; }
		public int Cost {get; set;}
		public int Crew { get; set; }
		public float Weight { get; set; }
		public int Power { get; set; }
	}
}