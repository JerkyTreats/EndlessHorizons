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
			List<InventoryItem> inventoryItems = GetInventorySprites();
			for (int i = 0; i < inventoryItems.Count; i++)
			{
				InventoryItem item = inventoryItems[i];

				//item.Quad.RenderQuad(inventoryItem);
				//inventoryItem.transform.position = GetInventoryItemPosition(i);
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

		Vector3 GetInventoryItemPosition(int index)
		{
			return new Vector3();
		}
	}
}
