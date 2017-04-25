using Engine;
using System.Collections.Generic;
using UnityEngine;

namespace Workshop.Grid
{
	public class Grid : MonoBehaviour
	{
		private GridData m_model; 

		private List<GridTile> m_tiles; // collection of tiles in the grid
		private SpriteRenderer Renderer;

		public float ZAxisItemPlacement;

		/// <summary>
		/// Attach GridData Model to GameObject and run StartUp methods
		/// </summary>
		/// <param name="data"></param>
		public void Initialize(GridData data)
		{
			m_model = data;
			GenerateTileList();

			transform.position = m_model.TileStartLocation;
			m_model.Quad.RenderQuad(gameObject);
			ZAxisItemPlacement = m_model.TileStartLocation.z - 0.01f;
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

			float width = m_model.Quad.Vertices[2].x / m_model.Quad.UVs[2].x;
			float height = m_model.Quad.Vertices[2].y / m_model.Quad.UVs[2].y;

			for (int x = 0; x < m_model.TileCountX; x++)
			{
				for (int y = 0; y < m_model.TileCountY; y++)
				{
					float pos_x = m_model.TileStartLocation.x + (x * width);
					float pos_y = m_model.TileStartLocation.y + (y * height);
					GridTile tile = new GridTile(pos_x, pos_y, m_model.TileSize);
					m_tiles.Add(tile);
				}
			}
		}
	}
}
