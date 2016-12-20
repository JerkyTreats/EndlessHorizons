using UnityEngine;

namespace Workshop.Grid.Tiles
{
	/// <summary>
	/// The tile board is not a collection of unique tile objects, but a single quad with multiple Vector3's denoting Tile locations.
	/// </summary>
	public class Tile
	{
		public bool Occupied { get; set; }

		public float MinX { get; set; }
		public float MinY { get; set; }
		public float MaxX { get; set; }
		public float MaxY { get; set; }

		/// <summary>
		/// Construct a Tile Object. Origin assumed to be on lowest left point.
		/// </summary>
		/// <param name="x">x axis origin of the tile</param>
		/// <param name="y">y axis origin of the tile</param>
		/// <param name="tileSize">X,Y axis of worldspace size of each tile</param>
		public Tile(float x, float y, Vector2 tileSize)
		{
			MinX = x;
			MinY = y;
			MaxX = x + tileSize.x;
			MaxY = y + tileSize.y;
			Occupied = false;
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
