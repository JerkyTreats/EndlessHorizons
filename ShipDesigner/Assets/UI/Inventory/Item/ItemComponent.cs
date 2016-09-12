using UnityEngine;
using Ships.Components;

namespace UI.Inventory.Item
{
	/// <summary>
	/// Monobehaviour storing controller class reference
	/// </summary>
	public class ItemComponent : MonoBehaviour
	{
		private ItemController Controller;

		public void SetController(ItemController controller)
		{
			Controller = controller;
		}

		public TileData GetTileData()
		{
			return Controller.TileData;
		}
	}
}
