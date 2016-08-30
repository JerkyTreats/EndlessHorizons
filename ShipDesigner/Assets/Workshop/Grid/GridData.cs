using SimpleJSON;
using System.IO;
using Engine.Utility;
using UnityEngine;
using Engine;
using System.Collections.Generic;
using System;

namespace Workshop.Grid
{
	public class GridData
	{
		static string FILE_NAME = "GridInformation.json";
		static string JSON_ROOT_NODE = "GridInformation";

		JSONNode JsonValues;

		Vector3 m_tileStartLocation;
		int m_gridCountX;
		int m_gridCountY;
		Quad m_quad;
		Vector2 m_tileSize;

		public GridData()
		{
			JsonValues = JSONTools.GetJSONNode(Util.CombinePath(Directory.GetCurrentDirectory(), "Assets", "Workshop", "Grid", FILE_NAME));
			SetStartLocation();
			SetTileCount();
			SetTileSize();
			SetQuad();
		}

		private void SetStartLocation()
		{
			m_tileStartLocation = new Vector3
				(
					JsonValues[JSON_ROOT_NODE]["TileStartLocation"]["x"].AsFloat,
					JsonValues[JSON_ROOT_NODE]["TileStartLocation"]["y"].AsFloat,
					JsonValues[JSON_ROOT_NODE]["TileStartLocation"]["z"].AsFloat
				);
		}

		private void SetTileCount()
		{
			m_gridCountX = JsonValues[JSON_ROOT_NODE]["TileCount"]["x"].AsInt;
			m_gridCountY = JsonValues[JSON_ROOT_NODE]["TileCount"]["y"].AsInt;
		}

		private void SetTileSize()
		{
			m_tileSize = new Vector2(JsonValues[JSON_ROOT_NODE]["TileSize"]["x"].AsFloat, JsonValues[JSON_ROOT_NODE]["TileSize"]["y"].AsFloat);
		}

		private void SetQuad()
		{
			string texturePath = JsonValues[JSON_ROOT_NODE]["BackgroundPlane"]["SpritePath"].Value;
			m_quad = new Quad(texturePath);
			m_quad.SetVertices(new Vector3(), new Vector3((m_gridCountX * m_tileSize.x), (m_gridCountY * m_tileSize.y)));
			m_quad.SetUVs(new Vector2(), new Vector2((TileCountX * m_tileSize.x), (TileCountY * m_tileSize.y)));
		}

		public Vector3 TileStartLocation { get { return m_tileStartLocation; } }
		public int TileCountX { get { return m_gridCountX; } }
		public int TileCountY { get { return m_gridCountY; } }
		public Quad Quad { get { return m_quad; } }
		public Vector2 TileSize { get { return m_tileSize; } }
	}
}
