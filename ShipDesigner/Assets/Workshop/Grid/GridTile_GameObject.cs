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
			Texture2D tex = Resources.Load<Texture2D>(controller.Sprite) as Texture2D;
			Rect rect = new Rect(0, 0, (tex.width-1), (tex.height-1));
			Renderer.sprite = Sprite.Create(tex, rect, new Vector2(),128f);
		}
	}
}
