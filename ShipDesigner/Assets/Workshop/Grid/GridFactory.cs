using SimpleJSON;
using System.IO;
using Util;
using UnityEngine;

namespace Workshop
{
	public class GridFactory
	{
		private static string FILE_NAME = "GridInformation.json";
		private static string JSON_ROOT_NODE = "GridInformation";

		private JSONNode JsonValues;

		private Vector3 m_tileStartLocation;
		private int m_gridCountX;
		private int m_gridCountY;
		private Sprite m_sprite;

		public static Grid BuildGrid()
		{
			GridFactory gi = new GridFactory();
			return new Grid(gi.TileCountX, gi.TileCountY, gi.TileStartLocation, gi.Sprite);
		}

		public GridFactory()
		{
			JsonValues = JSONTools.GetJSONNode(GetGridInformationPath());
			SetStartLocation();
			SetTileCount();
			CreateSprite();
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

		private void CreateSprite()
		{
			string resourcePath = GetStringFromJson("SpritePath");
			Texture2D tex = Resources.Load<Texture2D>(resourcePath) as Texture2D;
			Rect rect = new Rect(0, 0, tex.width, tex.height);
			float pixelsPerUnit = GetFloatFromJson("PixelsPerUnit");
			m_sprite = Sprite.Create(tex, rect, new Vector2(),pixelsPerUnit);
		}

		public Vector3 TileStartLocation { get { return m_tileStartLocation; } }
		public int TileCountX { get { return m_gridCountX; } }
		public int TileCountY { get { return m_gridCountY; } }
		public Sprite Sprite { get { return m_sprite; } }
	}
}
