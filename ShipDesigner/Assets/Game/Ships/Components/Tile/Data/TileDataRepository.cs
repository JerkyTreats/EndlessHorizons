using System.Collections.Generic;
using System.IO;
using Engine.Utility;
using Engine;

namespace Ships.Components
{
	public class TileDataRepository : DataRepository
	{
		static string TILE_DATA_PATH = Util.CombinePath(Directory.GetCurrentDirectory(), "Assets", "Game", "Ships", "Components", "Tile", "Data", "Raw");

		public Dictionary<string, TileData> TileTypes = new Dictionary<string, TileData>();

		public TileDataRepository()
		{
			BuildRepository(TILE_DATA_PATH, TileTypes);
		}
	}
}
