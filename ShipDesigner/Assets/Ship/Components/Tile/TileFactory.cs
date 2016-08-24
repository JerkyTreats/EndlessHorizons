using UnityEngine;
using UnityEngine.EventSystems;

namespace Ships.Components
{
	public static class TileFactory
	{
		public static GameObject BuildTile(TileData data)
		{
			TileController controller = new TileController(data.Name,data.Weight,data.Durability,data.Cost,data.MainSpriteData);
			GameObject tile = new GameObject(controller.Name);
			var component = tile.AddComponent<TileComponent>();
			//var moveHandler = tile.AddComponent<PlacementHandler>();
			component.SetController(controller);
			component.Render();

			return tile;
		}
	}
}
