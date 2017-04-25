using UnityEngine;

namespace UI.Inventory.Item
{
	public interface iInventoryObjectSpawner
	{
		void SpawnObject(Vector3 gridPosition);
		bool IsOccupied(Vector3 gridPosition);
	}
}
