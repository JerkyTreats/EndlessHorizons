using Workshop.Inventory;
using UnityEngine;

namespace Ships.Components
{
	public class TileController 
	{
		IInventoryItem m_iInventoryItem;

		Sprite m_inventorySprite;
		Sprite m_sprite;

		public float Weight { get; set; }
		public int Durability { get; set; }
		public int Cost { get; set; }

		public Sprite InventorySprite { get { return m_inventorySprite; } }
		public Sprite Sprite { get { return m_sprite; } }
	}
}