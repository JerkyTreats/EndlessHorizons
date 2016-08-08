using System.Collections.Generic;
using System.IO;
using Util;

namespace Ships.Components
{
	public class TileDataRepository
	{
		static string TILE_DATA_PATH = Common.CombinePath(Directory.GetCurrentDirectory(), "Assets", "Ship", "Components", "Tile", "Data");

		public Dictionary<string, TileData> TileTypes;

		public TileDataRepository()
		{
			string[] files = Directory.GetFiles(TILE_DATA_PATH);
			for (int i = 0; i < files.Length; i++)
			{
				string[] file = files[i].Split('.');
				if (file[1].Equals("json"))
					TileTypes.Add(file[0], new TileData(Common.CombinePath(TILE_DATA_PATH, files[i])));
			}
		}
	}
}
