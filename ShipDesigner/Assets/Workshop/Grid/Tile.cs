using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Workshop.Grid
{
	public class Tile
	{
		public Vector3 Origin { get; set; }
		public bool Occupied { get; set; }

		public Tile(Vector3 origin)
		{
			Origin = origin;
			Occupied = false;
		}
	}
}
