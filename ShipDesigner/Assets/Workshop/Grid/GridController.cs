using UnityEngine;
using System.Collections.Generic;
using Engine; 

namespace Workshop
{
	public class GridController
	{
		private Vector3 m_startLocation = new Vector3();
		private int m_tileCountX;
		private int m_tileCountY;

		private List<TileController> m_tiles;

		public GridController(int x, int y, Vector3 startLocation, SpriteData spriteData)
		{
			m_tileCountX = x;
			m_tileCountY = y;
			m_startLocation = startLocation;

			GenerateTileList(spriteData);
		}

		public void GenerateTileList(SpriteData spriteData)
		{
			m_tiles = new List<TileController>();
			for (int x = 0; x < m_tileCountX; x++)
			{
				for (int y = 0; y < m_tileCountY; y++)
				{
					float pos_x = m_startLocation.x + (x * (spriteData.Rect.width / spriteData.PixelsPerUnit));
					float pos_y = m_startLocation.y + (y * (spriteData.Rect.height / spriteData.PixelsPerUnit));
					Vector3 position = new Vector3(pos_x, pos_y);

					TileController grid = new TileController(position, spriteData);
					m_tiles.Add(grid);
				}
			}
		}

		public List<TileController> Tiles { get { return m_tiles; } }
	}
}
