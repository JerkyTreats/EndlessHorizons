using UnityEngine;

namespace Workshop
{
	public class GridTile_GameObject : MonoBehaviour {

		private GridTile controller;
		public SpriteRenderer Renderer;

		public void Initialize (GridTile gridtile) {
			this.controller = gridtile;
			LoadSprite();
			gameObject.transform.position = controller.Position;
		}
	
		void Update () {
	
		}

		void LoadSprite()
		{
			Renderer = gameObject.AddComponent<SpriteRenderer>();
			Renderer.sprite = controller.Sprite;
		}
	}
}
