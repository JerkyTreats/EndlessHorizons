using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
			List<Sprite> inventorySprites = Controller.GetInventorySprites();

		}
	}
}

