using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ships.Blueprints
{
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
