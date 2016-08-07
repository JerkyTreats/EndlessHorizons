using UnityEngine;

namespace Workshop.Inventory
{
	public interface IInventoryItem
	{
		Sprite GetUISprite();
		GameObject SpawnItem();
	}
}
