using UnityEngine;
using Engine.UI;

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
		public static GameObject BuildInventoryItem(string name, Vector2 position, ItemData itemData, Transform parent)
		{
			Vector2 textPanelSize = new Vector2(itemData.ItemSize.x, itemData.ItemSize.y / itemData.TextDivisionAmount);
			GameObject inventoryItem = Common.BuildImageUIObject(string.Format("{0}_Item", name), itemData.Sprite, parent, itemData.Pivot, itemData.ItemSize, itemData.Pivot, position);
			TextLabel.BuildTextLabel(inventoryItem.transform, itemData.TextData, textPanelSize);

			return inventoryItem;
		}
	}
}
