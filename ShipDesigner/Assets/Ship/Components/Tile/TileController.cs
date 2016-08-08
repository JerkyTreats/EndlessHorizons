using Workshop.Inventory;
using UnityEngine;
using Engine;

namespace Ships.Components
{
	public class TileController 
	{
		IInventoryItem m_iInventoryItem;

		MaterialData m_inventorySpriteData;
		MaterialData m_spriteData;

		public string Name { get; set; }
		public float Weight { get; set; }
		public float Durability { get; set; }
		public float Cost { get; set; }

		public MaterialData Sprite { get { return m_spriteData; } }

		public TileController(string name, float weight, float durability, float cost, MaterialData mainSprite)
		{
			Name = name;
			Weight = weight;
			Durability = durability;
			Cost = cost;
			m_spriteData = mainSprite;
		}
	}
}