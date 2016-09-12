using Ships.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Inventory.Item
{
	/// <summary>
	/// Controller backing class for a UI Item 
	/// </summary>
	public class ItemController
	{
		TileData m_data;

		public ItemController(TileData data)
		{
			m_data = data;
		}

		public TileData TileData { get { return m_data; } }
	}
}
