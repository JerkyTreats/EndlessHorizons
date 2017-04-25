using System.Collections.Generic;
using System.IO;
using Engine.Utility;
using Engine;

namespace Ships.Components
{
	public class TileDataRepository : DataRepository
	{
		public Dictionary<string, TileData> TileTypes = new Dictionary<string, TileData>();

		public TileDataRepository()
		{
			BuildRepository(TileData.TILE_DATA_PATH, TileTypes);
		}
	}
}
