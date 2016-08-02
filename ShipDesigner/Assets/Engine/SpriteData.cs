using UnityEngine;

namespace Engine
{
	public class SpriteData
	{
		private Texture m_texture;
		private float m_pixelsPerUnit;

		public Texture Texture { get { return m_texture; } }
		public float PixelsPerUnit { get { return m_pixelsPerUnit; } }

		public SpriteData(string resourcePath, float pixelsPerUnit)
		{
			m_texture = Resources.Load<Texture>(resourcePath) as Texture;
			m_texture.wrapMode = TextureWrapMode.Repeat;
			m_pixelsPerUnit = pixelsPerUnit;
		}

		public float Width { get { return (m_texture.width / m_pixelsPerUnit); } }
		public float Height { get { return (m_texture.height / m_pixelsPerUnit); } }
	}
}
