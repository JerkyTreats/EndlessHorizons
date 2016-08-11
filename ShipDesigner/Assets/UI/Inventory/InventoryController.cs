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
		static float INVENTORY_SPRITE_SIZE = 0.64f;
		static float INVENTORY_PADDING = 0.05f;
		RectTransform Parent;

		public InventoryController(GameObject parent)
		{
			Parent = parent.GetComponent<RectTransform>();
		}

		public void FillInventory()
		{
			Vector2 pivot = new Vector2(0, 1);
			Vector2 spriteSize = new Vector2(INVENTORY_SPRITE_SIZE, INVENTORY_SPRITE_SIZE);
			List<InventoryItem> inventoryItems = GetInventorySprites();
			for (int i = 0; i < inventoryItems.Count; i++)
			{
				//= inventoryItems[i].Quad.Texture;
				Vector2 position = GetInventoryItemPosition(i);

				InventoryItem itemData = inventoryItems[i];
				GameObject item = new GameObject(itemData.Name);
				var image = item.AddComponent<Image>();

				image.sprite = Sprite.Create(itemData.Quad.Texture2D, itemData.Quad.Rect, pivot, 1014f);

					//Engine.UI.BuildUIObject(itemData.Name, Parent.gameObject, pivot, spriteSize, pivot, position);
			}
		}

		List<InventoryItem> GetInventorySprites()
		{
			List<InventoryItem> inventoryItems = new List<InventoryItem>();
			TileDataRepository data = GameData.Instance.Components.TileData;

			foreach (KeyValuePair<string, TileData> kvp in data.TileTypes)
			{
				kvp.Value.InventoryItem.Quad.SetVertices(new Vector3(), new Vector3(INVENTORY_SPRITE_SIZE, INVENTORY_SPRITE_SIZE));
				inventoryItems.Add(kvp.Value.InventoryItem);
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

			return new Vector2(xPosition, yPosition);
		}
	}
}
