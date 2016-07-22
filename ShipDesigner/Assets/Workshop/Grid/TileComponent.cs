using UnityEngine;

namespace Workshop
{
	public class TileComponent : MonoBehaviour {

		private TileController controller;
		public SpriteRenderer Renderer;

		public void SetController(TileController controller)
		{
			this.controller = controller;
			transform.position = controller.Position;
			LoadSprite();
		}

		void LoadSprite()
		{
			Renderer = gameObject.AddComponent<SpriteRenderer>();
			Renderer.sprite = Sprite.Create(controller.SpriteData.Texture, controller.SpriteData.Rect, new Vector2(),controller.SpriteData.PixelsPerUnit);
		}
	}
}
