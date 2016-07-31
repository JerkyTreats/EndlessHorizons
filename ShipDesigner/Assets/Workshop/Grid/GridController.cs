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
		private SpriteData m_spriteData;

		private List<Vector3> m_tiles;

		public GridController(int x, int y, Vector3 startLocation, SpriteData spriteData)
		{
			m_tileCountX = x;
			m_tileCountY = y;
			m_startLocation = startLocation;
			m_spriteData = spriteData;

			GenerateTileList(m_spriteData.Width,m_spriteData.Height);
		}

		public void GenerateTileList(float width, float height)
		{
			m_tiles = new List<Vector3>();
			for (int x = 0; x < m_tileCountX; x++)
			{
				for (int y = 0; y < m_tileCountY; y++)
				{
					float pos_x = m_startLocation.x + (x * width);
					float pos_y = m_startLocation.y + (y * height);
					Vector3 position = new Vector3(pos_x, pos_y);
					m_tiles.Add(position);
				}
			}
		}

		public Rect Rect
		{
			get
			{
				float width = m_tileCountX * m_spriteData.Width;
				float height = m_tileCountY * m_spriteData.Height;
				return new Rect(0,0, width, height);
			}
		}

		public List<Vector3> TilePositions { get { return m_tiles; } }
		public SpriteData SpriteData { get { return m_spriteData; } }
	}
}
