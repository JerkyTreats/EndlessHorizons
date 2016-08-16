using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Engine;
using Ships.Components;
using System;

namespace UI
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
			Vector2 pivot = new Vector2(0, 1);
			Vector2 spriteSize = new Vector2(INVENTORY_SPRITE_SIZE, INVENTORY_SPRITE_SIZE);
			List<TileData> inventoryItems = GetInventorySprites();
			for (int i = 0; i < inventoryItems.Count; i++)
			{
				Vector2 position = GetInventoryItemPosition(i);
				TileData itemData = inventoryItems[i];
				Sprite sprite = Sprite.Create(itemData.InventoryItem.Quad.Texture2D, itemData.InventoryItem.Quad.Rect, pivot);
				Vector2 textSize = new Vector2(spriteSize.x, spriteSize.y / TEXT_AREA_DIVISION_AMOUNT);
				InventoryFactory.BuildInventoryItemPanel(itemData.Name, sprite, Parent.transform, pivot, spriteSize, pivot, position, textSize);
			}
		}

		List<TileData> GetInventorySprites()
		{
			List<TileData> inventoryItems = new List<TileData>();
			TileDataRepository data = GameData.Instance.Components.TileData;

			foreach (KeyValuePair<string, TileData> kvp in data.TileTypes)
			{
				//kvp.Value.InventoryItem.Quad.SetVertices(new Vector3(), new Vector3(INVENTORY_SPRITE_SIZE, INVENTORY_SPRITE_SIZE));
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
