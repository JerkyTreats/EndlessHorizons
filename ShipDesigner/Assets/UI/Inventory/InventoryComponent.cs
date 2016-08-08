using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Engine;
using UnityEngine.UI;

namespace UI
{
	public class InventoryComponent : MonoBehaviour
	{
		InventoryController Controller;

		void Start()
		{

		}

		public void SetController(InventoryController controller)
		{
			Controller = controller;
			FillInventory();
		}

		void FillInventory()
		{
			List<InventoryItem> inventoryItems = Controller.GetInventorySprites();
			for (int i = 0; i < inventoryItems.Count; i++)
			{
				InventoryItem item = inventoryItems[i];
				GameObject inventoryItem = new GameObject(item.Name);
				item.Quad.RenderQuad(inventoryItem);
				inventoryItem.transform.position = Controller.GetInventoryItemPosition(i);
			}
		}
	}
}

