using UnityEngine;
using System.Collections.Generic;
using Engine; 

namespace Workshop.Grid
{
	public class GridController
	{
		private Vector3 m_startLocation = new Vector3();
		private int m_tileCountX;
		private int m_tileCountY;
		private Quad quad;

		private List<Vector3> m_tiles;

		public GridController(int x, int y, Vector3 startLocation, Quad quad)
		{
			m_tileCountX = x;
			m_tileCountY = y;
			m_startLocation = startLocation;
			this.quad = quad;

			GenerateTileList();
		}

		public void GenerateTileList()
		{
			m_tiles = new List<Vector3>();
			float width = quad.Vertices[2].x / quad.UVs[2].x;
			float height = quad.Vertices[2].y / quad.UVs[2].y;

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

		public Vector3 StartLocation { get { return m_startLocation; } }
		public List<Vector3> TilePositions { get { return m_tiles; } }
		public Quad Quad { get { return quad; } }
	}
}
