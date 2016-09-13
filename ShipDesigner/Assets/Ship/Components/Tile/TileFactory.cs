using UI.Common;
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
			tile.SetActive(false);
			var component = tile.AddComponent<TileComponent>();
			component.SetController(controller);
			component.Render();

			return tile;
		}

		public static GameObject BuildInventoryItem(TileData data, Transform parent, Vector2 position)
		{
			GameObject tile = BuildTile(data);
			GameObject inventoryItem = BuildUIObject.BuildImageUIObject(string.Format("{0}_Item", data.Name), data.ItemData.Sprite, parent, data.ItemData.Pivot, data.ItemData.ItemSize, data.ItemData.Pivot, position);
			BuildUIObject.AddTextLabel(GetTextPanelSize(data), data.ItemData.TextData, inventoryItem.transform);
			BuildUIObject.AddPlacementHandler(inventoryItem, data.ItemData.ItemPreview, tile);

			return inventoryItem;
		}

		private static Vector2 GetTextPanelSize(TileData data)
		{
			return new Vector2(data.ItemData.ItemSize.x, data.ItemData.ItemSize.y / data.ItemData.TextDivisionAmount);
		}
	}
}
