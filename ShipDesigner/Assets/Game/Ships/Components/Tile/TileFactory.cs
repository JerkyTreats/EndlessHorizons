using System;
using UI.Common;
using UI.Inventory.Item;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ships.Components
{
	/// <summary>
	/// Provides static methods to create Tile objects
	/// </summary>
	public static class TileFactory
	{
		/// <summary>
		/// Static function to create a Tile object, complete with Component and Controller
		/// </summary>
		/// <param name="data">TileData object containing Tiles variable values</param>
		/// <returns></returns>
		public static GameObject BuildTile(TileData data)
		{
			GameObject tile = new GameObject(data.Name);
			//tile.SetActive(false);

			var tileComponent = tile.AddComponent<Tile>();
			tileComponent.Initialize(data.Name,
				data.Weight,
				data.Durability,
				data.Cost,
				data.MainSpriteData);

			return tile;
		}

		/// <summary>
		/// Static function to create the object appearing in the Inventory Panel
		/// </summary>
		/// <param name="data">TileData object containing the InventoryItems variable values</param>
		/// <param name="parent">Parent component to become a child of. Must be descendant of Canvas</param>
		/// <param name="position">Vector2 relative(?) position of the InventoryItem</param>
		/// <returns></returns>
		public static GameObject BuildInventoryItem(TileData data, Transform parent, Vector2 position)
		{
			GameObject inventoryItem = BuildUIObject.BuildImageUIObject(string.Format("{0}_Item", data.Name), 
				data.ItemData.Sprite, 
				parent, 
				data.ItemData.Pivot, 
				data.ItemData.ItemSize, 
				data.ItemData.Pivot, 
				position);
			BuildUIObject.AddTextLabel(GetTextPanelSize(data), data.ItemData.TextData, inventoryItem.transform);
			BuildUIObject.AddPlacementHandler(inventoryItem, data.ItemData.ItemPreview, data);
			return inventoryItem;
		}

		private static Vector2 GetTextPanelSize(TileData data)
		{
			return new Vector2(data.ItemData.ItemSize.x, data.ItemData.ItemSize.y / data.ItemData.TextDivisionAmount);
		}


	}
}
