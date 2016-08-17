using UnityEngine;

namespace UI.Inventory
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

