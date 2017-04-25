using UnityEngine;

namespace UI.Inventory.Item
{
	public interface iInventoryObjectSpawner
	{
		void SpawnObject(Vector3 startPosition);
	}

	public interface iBlueprintOccupier
	{
		bool IsOccupied(Vector3 gridPosition);
	}
}
