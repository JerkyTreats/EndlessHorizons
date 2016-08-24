using UnityEngine;

namespace Engine
{
	public static class Common
	{
		public static Texture LoadTexture(string resourcePath)
		{
			Texture tex = Resources.Load<Texture>(resourcePath) as Texture;
			if (tex != null)
				tex.wrapMode = TextureWrapMode.Repeat;
			return tex;
		}

		public static Texture2D LoadTexture2D(string resourcePath)
		{
			Texture2D tex = Resources.Load<Texture2D>(resourcePath) as Texture2D;
			if (tex != null)
				tex.wrapMode = TextureWrapMode.Repeat;
			return tex;
		}

		public static Sprite BuildSprite(string spritePath, Vector2 pivot)
		{
			Texture2D tex = LoadTexture2D(spritePath);
			Rect rect =  new Rect(0, 0, tex.width, tex.height); 
			Sprite sprite = Sprite.Create(tex, rect, pivot);
			return sprite;
		}
	}
}
