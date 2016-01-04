using System;
using UnityEngine;

namespace Ship.Blueprint
{
	class Grid
	{
		public Vector3 TileSize { get; set; }
		public Vector3	GridStartLocation { get; set; }
		public int GridCountX { get; set; }
		public int GridCountY { get; set; }
		public ArrayList<int[]> GridList {get; set;}
		
		public Grid (int xUnitCount, int yUnitCount, int zUnitCount)
		{
			GridList = new ArrayList<int>;
			var xRange = Enumerable.Range(0,xUnitCount).ToList();
			var yRange = Enumerable.Range(0,yUnitCount).ToList();
			var zRange = Enumerable.Range(0,zUnitCount).ToList();

			foreach (int x  in xRange)
			{
				foreach (int y in yRange )
				{
						foreach (int z in zRange)
						{
							GridList.Add(new int[3] {x,y,z});
						}
				}
			}
		}
	}
}