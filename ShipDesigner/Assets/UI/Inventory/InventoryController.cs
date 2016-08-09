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
		Vector2[] centerArea = new Vector2[4]; 

		public InventoryController()
		{
		}

		public List<InventoryItem> GetInventorySprites()
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

		public Vector3 GetInventoryItemPosition(int index)
		{
			float startX = centerArea[1].x + INVENTORY_PADDING;
			float endX = centerArea[2].x + INVENTORY_PADDING;


			return new Vector3();
		}
	}
}
