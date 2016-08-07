using UnityEngine;
using Workshop.Inventory;

namespace Ships.Components
{
	public class TileComponent : MonoBehaviour, IInventoryItem
	{
		TileController controller;

		public Sprite GetUISprite()
		{
			return controller.InventorySprite;
		}

		public GameObject SpawnItem()
		{
			return Instantiate(gameObject);
		}
	}
}


