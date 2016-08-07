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
		private MaterialData m_materialData;

		private List<Vector3> m_tiles;

		public GridController(int x, int y, Vector3 startLocation, MaterialData materialData)
		{
			m_tileCountX = x;
			m_tileCountY = y;
			m_startLocation = startLocation;
			m_materialData = materialData;

			GenerateTileList();
		}

		public void GenerateTileList()
		{
			m_tiles = new List<Vector3>();
			float width = m_materialData.Vertices[2].x / m_materialData.UVs[2].x;
			float height = m_materialData.Vertices[2].y / m_materialData.UVs[2].y;

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
		public MaterialData MaterialData { get { return m_materialData; } }
	}
}
