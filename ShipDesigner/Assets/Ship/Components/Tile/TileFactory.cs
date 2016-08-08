using UnityEngine;

namespace Ships.Components
{
	public static class TileFactory
	{
		public static GameObject BuildTile(TileData data)
		{
			TileController controller = new TileController(data.Name,data.Weight,data.Durability,data.Cost,data.MainSpriteData);
			GameObject tile = new GameObject(controller.Name);
			tile.AddComponent<TileComponent>();

			return tile;
		}
	}
}
