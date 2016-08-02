using UnityEngine;
using System.Collections;

namespace Workshop
{
	public class GridComponent : MonoBehaviour
	{
		private GridController controller;
		private SpriteRenderer Renderer;

		public void SetController (GridController controller)
		{
			this.controller = controller;
			//gameObject.transform.localScale = new Vector3(controller.Rect.width, controller.Rect.height);
			//LoadSprite();
		}

		void LoadSprite()
		{
			//var renderer = gameObject.AddComponent<MeshRenderer>();
			//renderer.material.mainTexture = controller.SpriteData.Texture;
			//controller.SpriteData.Texture.wrapMode = TextureWrapMode.Repeat;

			//Renderer = gameObject.AddComponent<SpriteRenderer>();
			//Debug.Log(string.Format("Rect Width: [{0}] \n Rect Height: [{1}]",controller.Rect.width, controller.Rect.height));
			//Renderer.sprite = Sprite.Create(controller.SpriteData.Texture, new Rect(0,0,900,900), new Vector2(), controller.SpriteData.PixelsPerUnit);
		}
	}
}
