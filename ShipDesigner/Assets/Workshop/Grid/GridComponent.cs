using UnityEngine;
using Workshop.Grid.Tiles;

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

		public GridTile GetTileByVector3(Vector3 inputVector)
		{
			return Controller.GetTileByVector3(inputVector);
		}
	}
}
