using SimpleJSON;
using System.IO;
using Util;
using UnityEngine;

namespace Workshop
{
	public class GridInformation
	{
		private static string FILE_NAME = "GridInformation.json";
		private static string JSON_ROOT_NODE = "GridInformation";
		private static float GRID_TILE_LENGTH_DEFAULT = 1.0f;
		private static float GRID_TILE_WIDTH_DEFAULT = 1.0f;

		private JSONNode JsonValues;

		private float m_gridTileLength;
		private float m_gridTileWidth;
		private int m_gridCountX;
		private int m_gridCountY;
		private string m_sprite;

		public GridInformation()
		{
			JsonValues = JSONTools.GetJSONNode(GetGridInformationPath());
			GridTileLength = GetFloatFromJson("GridTileLength");
			GridTileWidth = GetFloatFromJson("GridTileWidth");
			SetStartLocation();
			SetTileCount();
			SetSpritePath();
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
			TileStartLocation = new Vector3
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

		private void SetSpritePath()
		{
			string[] relativeDirs = GetStringFromJson("SpritePath").Split('\\');
			m_sprite = Util.Common.CombinePath(Directory.GetCurrentDirectory(), relativeDirs);
		}

		public float GridTileLength
		{
			get { return m_gridTileLength; }
			set
			{
				if (value != 0)
					m_gridTileLength = value;
				else if ((m_gridTileLength == 0) && (value == 0))
					m_gridTileLength = GRID_TILE_LENGTH_DEFAULT;
			}
		}
		public float GridTileWidth
		{
			get { return m_gridTileWidth; }
			set
			{
				if (value != 0)
					m_gridTileWidth = value;
				else if ((m_gridTileWidth == 0) && (value == 0))
					m_gridTileWidth = GRID_TILE_WIDTH_DEFAULT;
			}
		}
		public Vector3 TileStartLocation { get; set; }
		public int TileCountX { get { return m_gridCountX; } }
		public int TileCountY { get { return m_gridCountY; } }
		public string Sprite { get { return m_sprite; } }
	}
}
