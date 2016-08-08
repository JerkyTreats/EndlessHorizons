using Engine;
using UnityEngine;

namespace UI
{
	public class InventoryItem
	{
		public string Name { get; set; }
		public Quad Quad { get; set; }

		public InventoryItem(string name, Quad quad)
		{
			Name = name;
			Quad = quad;
		}
	}
}
