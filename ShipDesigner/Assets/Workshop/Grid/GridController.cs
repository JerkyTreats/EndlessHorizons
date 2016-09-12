using UnityEngine;
using System.Collections.Generic;
using Engine; 

namespace Workshop.Grid
{
	public class GridController
	{
		#region Private Variables

		private Vector3 m_startLocation = new Vector3();
		private int m_tileCountX;
		private int m_tileCountY;
		private Quad m_quad;
		private Vector2 m_tileSize;
		private List<Tile> m_tiles;

		#endregion
		#region Public Variables

		public Vector3 StartLocation { get { return m_startLocation; } }
		public List<Tile> Tiles { get { return m_tiles; } }
		public Quad Quad { get { return m_quad; } }
		
		#endregion
		#region Public Methods

		/// <summary>
		/// Creates a GridController object
		/// </summary>
		/// <param name="x">Number of tiles on the X axis</param>
		/// <param name="y">Number of tiles on the Y axis</param>
		/// <param name="startLocation">Starting position of the grid in world space</param>
		/// <param name="quad">Quad object to render the Grid</param>
		/// <param name="tileSize">Max Size of each tile, min size assumed to be zero </param>
		public GridController(int x, int y, Vector3 startLocation, Quad quad, Vector2 tileSize)
		{
			m_tileCountX = x;
			m_tileCountY = y;
			m_startLocation = startLocation;
			m_quad = quad;
			m_tileSize = tileSize;

			GenerateTileList();
		}

		/// <summary>
		/// Find the lowest left point of the nearest grid tile. 
		/// </summary>
		/// <param name="inputVector">Vector3 to compare to the tile locations</param>
		/// <returns></returns>
		public Vector3 GetClosestGridTile(Vector3 inputVector)
		{
			float x = RoundUp(inputVector.x, m_tileSize.x);
			x /= m_tileSize.x;

			float y = RoundUp(inputVector.y, m_tileSize.y);
			y /= m_tileSize.y;

			return new Vector3(x, y, inputVector.z);
		}

		public void OccupyTile(Vector3 inputVector)
		{

		}

		#endregion
		#region Private Methods

		private void GenerateTileList()
		{
			m_tiles = new List<Tile>();

			float width = m_quad.Vertices[2].x / m_quad.UVs[2].x;
			float height = m_quad.Vertices[2].y / m_quad.UVs[2].y;

			for (int x = 0; x < m_tileCountX; x++)
			{
				for (int y = 0; y < m_tileCountY; y++)
				{
					float pos_x = m_startLocation.x + (x * width);
					float pos_y = m_startLocation.y + (y * height);
					Tile tile = new Tile(new Vector3(pos_x, pos_y));
					m_tiles.Add(tile);
				}
			}
		}

		private float RoundUp(float inputVectorAxis, float tileSizeAxis)
		{
			float flooredAmount = (float)System.Math.Floor(inputVectorAxis);
			float decimalAmount = inputVectorAxis - flooredAmount;

			if (decimalAmount >= (tileSizeAxis / 2))
				flooredAmount += 1;

			return flooredAmount;
		}
		#endregion
	}
}