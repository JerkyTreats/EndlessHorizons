using UnityEngine;

namespace Ships.Components
{
	public interface iComponentSpawner
	{
		GameObject SpawnObject(Vector3 gridPosition);
		void AddToBlueprint(GameObject gameObject);
		bool IsOccupied(Vector3 gridPosition);
	}
}
