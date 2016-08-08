using UnityEngine;
using System.Collections;
using Engine.Utility;

namespace Workshop.Grid
{
	public class GridComponent : MonoBehaviour
	{
		private GridController controller;
		private SpriteRenderer Renderer;

		public void SetController (GridController controller)
		{
			this.controller = controller;
			transform.position = controller.StartLocation;
			Util.RenderMesh(gameObject, controller.MaterialData);
		}


	}
}
