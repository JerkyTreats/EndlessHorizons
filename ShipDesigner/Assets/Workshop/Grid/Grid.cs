using Engine;
using System.Collections.Generic;
using UnityEngine;

namespace Workshop.Grid
{
	public class Grid : MonoBehaviour
	{
		#region Private Variables

		private Vector3 m_startLocation = new Vector3(); //where in world space grid origin should be
		private int m_tileCountX; //number of tiles x
		private int m_tileCountY; //number of tiles y
		private Quad m_quad; // quad to render the grid
		private Vector2 m_tileSize; // size of each time
		private List<GridTile> m_tiles; // collection of tiles in the grid
		private SpriteRenderer Renderer;

		#endregion
		#region Public Variables

		public Vector3 StartLocation { get { return m_startLocation; } }
		public Quad Quad { get { return m_quad; } }
		public float ZAxisItemPlacement;

		#endregion

		public void Initialize()
		{
			GridData data = new GridData();

			m_tileCountX = data.TileCountX;
			m_tileCountY = data.TileCountY;
			m_startLocation = data.TileStartLocation;
			m_quad = data.Quad;
			m_tileSize = data.TileSize;

			GenerateTileList();

			transform.position = StartLocation;
			Quad.RenderQuad(gameObject);
			ZAxisItemPlacement = StartLocation.z - 0.01f;
		}

		/// <summary>
		/// Find the lowest left point of the nearest grid tile. 
		/// </summary>
		/// <param name="input">Vector3 to compare to the tile locations</param>
		/// <returns></returns>
		public GridTile GetTileByVector3(Vector3 input)
		{
			for (int i = 0; i <= m_tiles.Count; i++)
			{
				if (m_tiles[i].Within(input))
				{
					return m_tiles[i];
				}
			}
			return null;
		}

		private void GenerateTileList()
		{
			m_tiles = new List<GridTile>();

			float width = m_quad.Vertices[2].x / m_quad.UVs[2].x;
			float height = m_quad.Vertices[2].y / m_quad.UVs[2].y;

			for (int x = 0; x < m_tileCountX; x++)
			{
				for (int y = 0; y < m_tileCountY; y++)
				{
					float pos_x = m_startLocation.x + (x * width);
					float pos_y = m_startLocation.y + (y * height);
					GridTile tile = new GridTile(pos_x, pos_y, m_tileSize);
					m_tiles.Add(tile);
				}
			}
		}
	}
}
