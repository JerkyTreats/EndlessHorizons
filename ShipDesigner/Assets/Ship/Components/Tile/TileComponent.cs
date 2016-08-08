using UnityEngine;
using Workshop.Inventory;

namespace Ships.Components
{
	public class TileComponent : MonoBehaviour, IInventoryItem
	{
		TileController Controller;

		public void SetController (TileController controller)
		{
			Controller = controller;
		}

		public Sprite GetUISprite()
		{
			return null;
			//return Controller.InventorySprite;
		}

		public GameObject SpawnItem()
		{
			return Instantiate(gameObject);
		}
	}
}


