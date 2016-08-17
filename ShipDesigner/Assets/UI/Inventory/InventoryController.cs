using UnityEngine;
using System.Collections.Generic;
using UI.Inventory.Item;
using Engine;
using Ships.Components;
using System;

namespace UI.Inventory
{
	public class InventoryController
	{
		static float INVENTORY_SPRITE_SIZE = 32f;
		static float INVENTORY_PADDING = 2.5f;
		static float TEXT_AREA_DIVISION_AMOUNT = 4f;
		RectTransform Parent;

		public InventoryController(GameObject parent)
		{
			Parent = parent.GetComponent<RectTransform>();
		}

		public void FillInventory()
		{
			List<TileData> inventoryItems = GetInventorySprites();
			for (int i = 0; i < inventoryItems.Count; i++)
			{
				Vector2 position = GetInventoryItemPosition(i);
				InventoryFactory.BuildInventoryItem(position, inventoryItems[i], Parent);
			}
		}

		List<TileData> GetInventorySprites()
		{
			List<TileData> inventoryItems = new List<TileData>();
			TileDataRepository data = GameData.Instance.Components.TileData;

			foreach (KeyValuePair<string, TileData> kvp in data.TileTypes)
			{
				inventoryItems.Add(kvp.Value);
			}

			return inventoryItems;
		}

		Vector2 GetInventoryItemPosition(int index)
		{
			int  spritesPerRow = Convert.ToInt32(Math.Floor((Parent.sizeDelta.x - INVENTORY_PADDING) / (INVENTORY_SPRITE_SIZE + INVENTORY_PADDING)));
			int tableRow = index / spritesPerRow;
			int tableColumn = index % spritesPerRow;

			float xPosition = INVENTORY_PADDING + (tableColumn * (INVENTORY_SPRITE_SIZE + INVENTORY_PADDING));
			float yPosition = INVENTORY_PADDING + (tableRow * (INVENTORY_SPRITE_SIZE + INVENTORY_PADDING));

			return new Vector2(xPosition, yPosition * -1);
		}
	}
}
