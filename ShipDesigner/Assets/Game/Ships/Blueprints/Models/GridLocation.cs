﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ships.Blueprints
{
	/// <summary>
	/// Vector2 stripped to only include x/y settings. 
	/// Primarily used for JSON serialization
	/// Normal Vector2/3 will serialize unncessary data, such as normals(?)
	/// </summary>
	public struct GridLocation
	{
		public float x;
		public float y;

		public GridLocation(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public GridLocation(double x, double y)
		{
			this.x = (float)x;
			this.y = (float)y;
		}
	}
}
