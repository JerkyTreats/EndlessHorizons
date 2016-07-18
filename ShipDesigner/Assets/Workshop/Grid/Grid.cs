using UnityEngine;
using System.Collections.Generic;
namespace Workshop
{
	public class Grid
	{
		private Vector3 m_startLocation = new Vector3();
		private int m_gridCountX;
		private int m_gridCountY;

		private List<GridTile> m_tiles;

		public Grid(int x, int y, Vector3 startLocation, float tileLength, float tileWidth, string spritePath)
		{
			m_gridCountX = x;
			m_gridCountY = y;
			m_startLocation = startLocation;
			GenerateTileList(tileLength, tileWidth, spritePath);
		}

		public void GenerateTileList(float length, float width, string spritePath)
		{
			m_tiles = new List<GridTile>();
			for (int x = 0; x < m_gridCountX; x++)
			{
				for (int y = 0; y < m_gridCountY; y++)
				{
					float pos_x = m_startLocation.x + (x * length);
					float pos_y = m_startLocation.y + (y * width);
					Vector3 position = new Vector3(pos_x, pos_y);
					m_tiles.Add(new GridTile(length, width, position, spritePath));
				}
			}
		}

		public Vector3 StartLocation { get { return m_startLocation; } }
		public int GridCountX { get { return m_gridCountX; } }
		public int GridCountY { get { return m_gridCountY; } }
		public List<GridTile> Tiles { get { return m_tiles; } }
	}
}
