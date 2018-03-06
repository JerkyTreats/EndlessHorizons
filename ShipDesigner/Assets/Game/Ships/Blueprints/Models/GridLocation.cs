using System;
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
		public float z;

		public GridLocation(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public GridLocation(double x, double y, double z)
		{
			this.x = (float)x;
			this.y = (float)y;
			this.z = (float)z;
		}
	}
}
