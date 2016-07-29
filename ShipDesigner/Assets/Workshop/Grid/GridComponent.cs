using UnityEngine;
using System.Collections;

namespace Workshop
{
	public class GridComponent : MonoBehaviour
	{
		private GridController controller;

		public void SetController (GridController controller)
		{
			this.controller = controller;
		}
	}
}
