using UnityEngine;

namespace Workshop.Grid
{
	/// <summary>
	/// The tile board is not a collection of unique tile objects, but a single quad with multiple Vector3's denoting Tile locations.
	/// </summary>
	public class GridTile
	{
		public float MinX { get; set; }
		public float MinY { get; set; }
		public float MaxX { get; set; }
		public float MaxY { get; set; }
		public float MinZ { get; set; }
		public float MaxZ { get; set; }
		public Vector3 Origin { get { return new Vector3(MinX, MinY, MinZ); } }

		/// <summary>
		/// Construct a Tile Object. Origin assumed to be on lowest left point.
		/// </summary>
		/// <param name="x">x axis origin of the tile</param>
		/// <param name="y">y axis origin of the tile</param>
		/// <param name="z">y axis origin of the tile</param>
		/// <param name="tileSize">Vector3 worldspace size of each tile</param>
		public GridTile(Vector3 origin, Vector3 tileSize)
		{
			MinX = origin.x;
			MinY = origin.y;
			MinZ = origin.z;
			MaxX = origin.x + tileSize.x;
			MaxY = origin.y + tileSize.y;
			MaxZ = origin.z + tileSize.z;
		}

		/// <summary>
		/// Return true if the input vector is within the range of the tile world position
		/// </summary>
		/// <param name="input">Input vector3 to check against</param>
		/// <returns>True if within bounds, otherwise false</returns>
		public bool Within(Vector3 input)
		{
			if (input.x >= MinX &&
				input.x <= MaxX &&
				input.y >= MinY &&
				input.y <= MaxY)
			{
				return true;
			}
			return false;
		}
	}
}
