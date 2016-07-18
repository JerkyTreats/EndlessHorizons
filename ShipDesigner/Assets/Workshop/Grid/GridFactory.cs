using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop
{
	public static class GridFactory
	{
		public static Grid BuildGrid()
		{
			GridInformation gi = new GridInformation();
			return new Grid(gi.TileCountX, gi.TileCountY, gi.TileStartLocation, gi.TileLength,gi.TileWidth);
		}
	}
}
