using UnityEngine;
using System.Collections;

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
			controller.Quad.RenderQuad(gameObject);
		}


	}
}
