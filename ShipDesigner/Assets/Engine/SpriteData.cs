using UnityEngine;

namespace Engine
{
	public class SpriteData
	{
		private Texture2D m_texture;
		private float m_pixelsPerUnit;

		public Texture2D Texture { get { return m_texture; } }
		public float PixelsPerUnit { get { return m_pixelsPerUnit; } }

		public SpriteData(string resourcePath, float pixelsPerUnit)
		{
			m_texture = Resources.Load<Texture2D>(resourcePath) as Texture2D;
			m_texture.wrapMode = TextureWrapMode.Repeat;
			m_pixelsPerUnit = pixelsPerUnit;
		}

		public float Width { get { return (m_texture.width / PixelsPerUnit); } }
		public float Height { get { return (m_texture.height / PixelsPerUnit); } }
	}
}
