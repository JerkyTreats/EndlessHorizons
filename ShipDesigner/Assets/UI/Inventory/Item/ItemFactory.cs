using UnityEngine;
using UI.Common;
using Ships.Components;

namespace UI.Inventory.Item
{
	public static class ItemFactory
	{
		/// <summary>
		/// Build an Inventory Item UI image. Attaches to a parent RectTransform
		/// </summary>
		/// <param name="position"> Vector2 postiion of the image based on the pivot point </param>
		/// <param name="itemData"> ItemData object to populate image values </param>
		/// <param name="parent"> Parent RectTransform of the image. Pivot is placed in relation to this objects size </param>
		/// <returns></returns>
		public static GameObject BuildInventoryItem(TileData data, Vector2 position, Transform parent)
		{
			GameObject inventoryItem = BuildUIObject.BuildImageUIObject(string.Format("{0}_Item", data.Name), data.ItemData.Sprite, parent, data.ItemData.Pivot, data.ItemData.ItemSize, data.ItemData.Pivot, position);
			SetItemController(data, inventoryItem);
			SetTextLabel(data.ItemData, inventoryItem);
			SetPlacementHandler(data.ItemData, inventoryItem);

			return inventoryItem;
		}

		private static void SetItemController(TileData data, GameObject inventoryItem)
		{
			var component = inventoryItem.AddComponent<ItemComponent>();
			component.SetController(new ItemController(data));
		}

		private static void SetTextLabel(ItemData itemData, GameObject inventoryItem)
		{
			Vector2 textPanelSize = new Vector2(itemData.ItemSize.x, itemData.ItemSize.y / itemData.TextDivisionAmount);
			TextLabel.BuildTextLabel(inventoryItem.transform, itemData.TextData, textPanelSize);
		}

		private static void SetPlacementHandler(ItemData itemData, GameObject inventoryItem)
		{
			PlacementHandler placementHandler = inventoryItem.AddComponent<PlacementHandler>();
			placementHandler.Quad = itemData.ItemPreview;
		}
	}
}
