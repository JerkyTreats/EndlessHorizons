using SimpleJSON;
using System.IO;
using Util;
using UnityEngine;
using Engine;

namespace Workshop
{
	public class GridData
	{
		private static string FILE_NAME = "GridInformation.json";
		private static string JSON_ROOT_NODE = "GridInformation";

		private JSONNode JsonValues;

		private Vector3 m_tileStartLocation;
		private int m_gridCountX;
		private int m_gridCountY;
		private SpriteData m_spriteData;

		public GridData()
		{
			JsonValues = JSONTools.GetJSONNode(GetGridInformationPath());
			SetStartLocation();
			SetTileCount();
			m_spriteData = new SpriteData(GetStringFromJson("SpritePath"), GetFloatFromJson("PixelsPerUnit"));
		}

		private string GetGridInformationPath()
		{
			return Common.CombinePath(Directory.GetCurrentDirectory(), "Assets", "Workshop", "Grid", FILE_NAME);
		}

		private float GetFloatFromJson(string value)
		{
			return JsonValues[JSON_ROOT_NODE][value].AsFloat;
		}

		private string GetStringFromJson(string value)
		{
			return JsonValues[JSON_ROOT_NODE][value].Value;
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

		public Vector3 TileStartLocation { get { return m_tileStartLocation; } }
		public int TileCountX { get { return m_gridCountX; } }
		public int TileCountY { get { return m_gridCountY; } }
		public SpriteData SpriteData { get { return m_spriteData; } }
	}
}
