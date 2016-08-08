using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Engine;
using Ships.Components;

namespace UI
{
	public class InventoryController
	{
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

		public List<Sprite> GetInventorySprites()
		{
			List<Sprite> inventorySprites = new List<Sprite>();
			TileDataRepository data = GameData.Instance.Components.TileData;

			foreach (KeyValuePair<string, TileData> kvp in data.TileTypes)
			{
				//MaterialData 
				string texturePath = kvp.Value.InventorySpritePath;
			}

			return null;
		}
	}
}
