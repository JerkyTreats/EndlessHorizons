using SimpleJSON;
using System.IO;
using Util;

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

		public GridInformation()
		{
			JsonValues = JSONTools.GetJSONNode(GetGridInformationPath());
			GridTileLength = GetFloat("GridTileLength");
			GridTileWidth = GetFloat("GridTileWidth");
		}

		private float GetFloat(string value)
		{
			return JsonValues[JSON_ROOT_NODE][value].AsFloat;
		}

		private string GetGridInformationPath()
		{
			return Common.CombinePath(Directory.GetCurrentDirectory(), "Workshop", "Grid", FILE_NAME);
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

	}
}
