using UnityEngine;
using System.Collections;
using System;

namespace Workshop.Grid
{
	public class GridComponent : MonoBehaviour
	{
		private GridController Controller;
		private SpriteRenderer Renderer;
		public float ZAxisItemPlacement;

		public void SetController (GridController controller)
		{
			Controller = controller;
			transform.position = controller.StartLocation;
			controller.Quad.RenderQuad(gameObject);
			ZAxisItemPlacement = controller.StartLocation.z - 0.01f;
		}

		public Vector3 GetClosestGridTile(Vector3 inputVector)
		{
			return Controller.GetClosestGridTile(inputVector);
		}
	}
}
