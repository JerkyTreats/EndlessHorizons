using Workshop.Inventory;
using UnityEngine;
using Engine;

namespace Ships.Components
{
	public class TileController 
	{
		IInventoryItem m_iInventoryItem;

		Quad m_inventorySpriteData;
		Quad m_spriteData;

		public string Name { get; set; }
		public float Weight { get; set; }
		public float Durability { get; set; }
		public float Cost { get; set; }

		public Quad Sprite { get { return m_spriteData; } }

		public TileController(string name, float weight, float durability, float cost, Quad mainSprite)
		{
			Name = name;
			Weight = weight;
			Durability = durability;
			Cost = cost;
			m_spriteData = mainSprite;
		}
	}
}