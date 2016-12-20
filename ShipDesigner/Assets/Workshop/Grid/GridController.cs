using UnityEngine;
using System.Collections.Generic;
using Engine;
using Workshop.Grid.Tiles;

namespace Workshop.Grid
{
	public class GridController
	{
		#region Private Variables

		private Vector3 m_startLocation = new Vector3(); //where in world space grid origin should be
		private int m_tileCountX; //number of tiles x
		private int m_tileCountY; //number of tiles y
		private Quad m_quad; // quad to render the grid
		private Vector2 m_tileSize; // size of each time
		private List<Tile> m_tiles; // collection of tiles in the grid

		#endregion
		#region Public Variables

		public Vector3 StartLocation { get { return m_startLocation; } }
		//public List<Tile> Tiles { get { return m_tiles; } }
		public Quad Quad { get { return m_quad; } }
		
		#endregion
		
		#region Public Methods

		/// <summary>
		/// Creates a GridController Object. A GridData object is created on the fly to map JSON values to object properties. 
		/// </summary>
		public GridController()
		{
			GridData data = new GridData();

			m_tileCountX = data.TileCountX;
			m_tileCountY = data.TileCountY;
			m_startLocation = data.TileStartLocation;
			m_quad = data.Quad;
			m_tileSize = data.TileSize;

			GenerateTileList();
		}

		/// <summary>
		/// Find the lowest left point of the nearest grid tile. 
		/// </summary>
		/// <param name="inputVector">Vector3 to compare to the tile locations</param>
		/// <returns></returns>
		public Tile GetTileByVector3(Vector3 input)
		{
			for (int i = 0; i <= m_tiles.Count; i++)
			{
				if(m_tiles[i].Within(input))
				{
					return m_tiles[i];
				}
			}
			return null;
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
					Tile tile = new Tile(pos_x, pos_y, m_tileSize);
					m_tiles.Add(tile);
				}
			}
		}

		#endregion
	}
}