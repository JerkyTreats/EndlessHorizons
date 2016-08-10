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

		public void SetController(InventoryController controller)
		{
			Controller = controller;
			Controller.FillInventory();
		}
	}
}

