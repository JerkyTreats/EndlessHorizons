using System.Collections.Generic;
using System.IO;
using Engine.Utility;

namespace Ships.Components
{
	public class TileDataRepository
	{
		static string TILE_DATA_PATH = Util.CombinePath(Directory.GetCurrentDirectory(), "Assets", "Ship", "Components", "Tile", "Data");

		public Dictionary<string, TileData> TileTypes = new Dictionary<string, TileData>();

		public TileDataRepository()
		{
			string[] files = Directory.GetFiles(TILE_DATA_PATH);
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].Contains(".meta"))
					continue;

				string[] paths = files[i].Split('\\');
				string[] file = paths[paths.Length-1].Split('.');

				if (file[1].Equals("json"))
					TileTypes.Add(file[0], new TileData(files[i]));
			}
		}
	}
}
