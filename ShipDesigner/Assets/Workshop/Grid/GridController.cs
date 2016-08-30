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
		private Quad m_quad;
		private Vector2 m_tileSize;

		private List<Vector3> m_tiles;

		public GridController(int x, int y, Vector3 startLocation, Quad quad, Vector2 tileSize)
		{
			m_tileCountX = x;
			m_tileCountY = y;
			m_startLocation = startLocation;
			m_quad = quad;
			m_tileSize = tileSize;

			GenerateTileList();
		}

		public void GenerateTileList()
		{
			m_tiles = new List<Vector3>();
			float width = m_quad.Vertices[2].x / m_quad.UVs[2].x;
			float height = m_quad.Vertices[2].y / m_quad.UVs[2].y;

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

		public Vector3 GetClosestGridTile(Vector3 inputVector)
		{
			Vector3 roundedVector = Round(inputVector);
			Vector3 closestGridTile = new Vector3(roundedVector.x / m_tileSize.x, roundedVector.y / m_tileSize.y, inputVector.z);
			Debug.Log(string.Format("In: [{0}]\n Out: [{1}]",inputVector, closestGridTile));
			return closestGridTile;
		}

		private Vector3 Round(Vector3 inputVector)
		{
			Vector3 roundedVector = new Vector3(RoundUp(inputVector.x), RoundUp(inputVector.y), inputVector.z);
			return roundedVector;
		}

		private float RoundUp(float inputVectorAxis)
		{
			float flooredAmount = (float)System.Math.Floor(inputVectorAxis);
			float decimalAmount = inputVectorAxis - flooredAmount;

			if (decimalAmount >= (m_tileSize.x / 2))
				flooredAmount += 1;

			return flooredAmount;
		}

		public Vector3 StartLocation { get { return m_startLocation; } }
		public List<Vector3> TilePositions { get { return m_tiles; } }
		public Quad Quad { get { return m_quad; } }
	}
}
