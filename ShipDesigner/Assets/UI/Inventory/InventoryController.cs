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
		Vector2[] centerArea = new Vector2[4]; 

		public InventoryController(Vector2 min, Vector2 max)
		{
			SetCenterArea(min, max);
		}

		void SetCenterArea(Vector2 min, Vector2 max)
		{
			centerArea[0] = min;
			centerArea[1] = new Vector2(min.x, max.y);
			centerArea[2] = max;
			centerArea[3] = new Vector2(max.x, min.y);
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
			return new Vector3();
		}
	}
}
