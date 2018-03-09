using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Utility
{
	/// <summary>
	/// Vector3 stripped to only include x/y/z settings. 
	/// Primarily used for JSON serialization
	/// Normal Vector2/3 will serialize unncessary data, such as normals(?)
	/// </summary>
	public struct SimpleVector3
	{
		public float x;
		public float y;
		public float z;

		public SimpleVector3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public SimpleVector3(double x, double y, double z)
		{
			this.x = (float)x;
			this.y = (float)y;
			this.z = (float)z;
		}
	}
}
