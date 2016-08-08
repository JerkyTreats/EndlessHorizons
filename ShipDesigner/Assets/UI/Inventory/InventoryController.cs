using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UI
{
	public class InventoryController
	{
		Vector2[] centerArea = new Vector2[4]; 

		public InventoryController(Vector2 min, Vector2 max)
		{
			SetCenterArea(min, max);
		}

		void SetCenterArea(Vector2 min, Vector2 max)
		{
			centerArea[0] = min;
			centerArea[1] = new Vector2(min.x, max.y);
			centerArea[2] = max;
			centerArea[3] = new Vector2(max.x, min.y);
		}
	}
}
