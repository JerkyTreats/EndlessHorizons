using SimpleJSON;
using System.IO;
using Engine.Utility;
using UnityEngine;
using Engine;
using System.Collections.Generic;
using System;

namespace Workshop.Grid
{
	public class Grids
	{
		static string FILE_NAME = "Grid.json";

		JSONNode JsonValues;

		Vector3 m_tileStartLocation;
		int m_gridCountX;
		int m_gridCountY;
		int m_gridCountZ;
		Vector3 m_tileSize;
		Vector3 m_occupiedTileSnappingDistance;

		public Vector3 TileStartLocation { get { return m_tileStartLocation; } }
		public int TileCountX { get { return m_gridCountX; } }
		public int TileCountY { get { return m_gridCountY; } }
		public int TileCountZ { get { return m_gridCountZ; } }
		public Vector3 TileSize { get { return m_tileSize; } }
		public Vector3 OccupiedTileSnappingSize { get { return m_occupiedTileSnappingDistance; } }

		public Grids()
		{
			JsonValues = JSONTools.GetJSONNode(Util.CombinePath(Directory.GetCurrentDirectory(), "Assets", "Workshop", "Grid", FILE_NAME));
			SetStartLocation();
			SetTileCount();
			SetTileSize();
			SetOccupiedTiles();
		}

		private void SetStartLocation()
		{
			m_tileStartLocation = new Vector3
				(
					JsonValues["TileStartLocation"]["x"].AsFloat,
					JsonValues["TileStartLocation"]["y"].AsFloat,
					JsonValues["TileStartLocation"]["z"].AsFloat
				);
		}

		private void SetTileCount()
		{
			m_gridCountX = JsonValues["TileCount"]["x"].AsInt;
			m_gridCountY = JsonValues["TileCount"]["y"].AsInt;
			m_gridCountZ = JsonValues["TileCount"]["z"].AsInt;
		}

		private void SetTileSize()
		{
			m_tileSize = new Vector3
				(
					JsonValues["TileSize"]["x"].AsFloat, 
					JsonValues["TileSize"]["y"].AsFloat,
					JsonValues["TileSize"]["z"].AsFloat
				);
		}

		private void SetOccupiedTiles()
		{
			string occupied_node = "OccupiedTiles";
			m_occupiedTileSnappingDistance = new Vector3
				(
					JsonValues[occupied_node]["x"].AsFloat,
					JsonValues[occupied_node]["y"].AsFloat,
					JsonValues[occupied_node]["z"].AsFloat
				);
		}
	}
}
