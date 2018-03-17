using Engine;
using System.Collections.Generic;
using UnityEngine;

namespace Workshop.Grid
{
	public class Grid : MonoBehaviour
	{
		private Grids m_model; 

		private List<GridTile> m_tiles; 
		private SpriteRenderer Renderer;

		public float ZAxisItemPlacement;

		/// <summary>
		/// Attach GridData Model to GameObject and run StartUp methods
		/// </summary>
		/// <param name="data"></param>
		public void Initialize(Grids data)
		{
			m_model = data;
			GenerateTileList();

			transform.position = m_model.TileStartLocation;
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

			for (int x = 0; x < m_model.TileCountX; x++)
			{
				for (int y = 0; y < m_model.TileCountY; y++)
				{
					for (int z = 0; z < m_model.TileCountZ; z++)
					{
						float pos_x = m_model.TileStartLocation.x + (x * m_model.TileSize.x);
						float pos_y = m_model.TileStartLocation.y + (y * m_model.TileSize.y);
						float pos_z = m_model.TileStartLocation.z + (z * m_model.TileSize.z);
						GridTile tile = new GridTile(new Vector3(pos_x, pos_y, pos_z), m_model.TileSize);
						m_tiles.Add(tile);
					}
				}
			}
		}
	}
}
