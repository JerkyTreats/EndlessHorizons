using UnityEngine;
using System.Collections.Generic;
using Engine; 

namespace Workshop.Grid
{
	public class GridController
	{
		#region Private Variables

		private Vector3 m_startLocation = new Vector3();
		private int m_tileCountX;
		private int m_tileCountY;
		private Quad m_quad;
		private Vector2 m_tileSize;
		private List<Tile> m_tiles;
		private List<Vector3> m_occupiedTiles;
		private Vector2 m_occupiedTilesSnappingSize;

		#endregion
		#region Public Variables

		public Vector3 StartLocation { get { return m_startLocation; } }
		public List<Tile> Tiles { get { return m_tiles; } }
		public Quad Quad { get { return m_quad; } }
		public List<Vector3> OccupiedTiles { get { return m_occupiedTiles; } }
		
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

			InitializeGridController(data.OccupiedTileSnappingSize);
		}

		/// <summary>
		/// Find the lowest left point of the nearest grid tile. 
		/// </summary>
		/// <param name="inputVector">Vector3 to compare to the tile locations</param>
		/// <returns></returns>
		public Vector3 GetClosestGridTileCoordinate(Vector3 inputVector)
		{
			float x = RoundUp(inputVector.x, m_tileSize.x);
			x /= m_tileSize.x;

			float y = RoundUp(inputVector.y, m_tileSize.y);
			y /= m_tileSize.y;

			return new Vector3(x, y, inputVector.z);
		}

		/// <summary>
		/// Adds a Tile to a List of Occupied Tiles
		/// </summary>
		/// <param name="inputVector">Grid Coordinate to Occupy</param>
		public void OccupyTile(Vector3 inputVector)
		{
			m_occupiedTiles.Add(inputVector);
		}

		#endregion
		#region Private Methods
		private void InitializeGridController(Vector2 occupiedTilesSnappingSize)
		{
			InitializeOccupiedTiles(occupiedTilesSnappingSize);
			GenerateTileList();
		}

		private void InitializeOccupiedTiles(Vector2 occupiedTilesSnappingSize)
		{
			m_occupiedTiles = new List<Vector3>();
			m_occupiedTilesSnappingSize = occupiedTilesSnappingSize;
		}

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
					Tile tile = new Tile(new Vector3(pos_x, pos_y));
					m_tiles.Add(tile);
				}
			}
		}
			
		private float RoundUp(float inputVectorAxis, float tileSizeAxis)
		{
			float flooredAmount = (float)System.Math.Floor(inputVectorAxis);
			float decimalAmount = inputVectorAxis - flooredAmount;

			if (decimalAmount >= (tileSizeAxis / 2))
				flooredAmount += 1;

			return flooredAmount;
		}

		#endregion
	}
}