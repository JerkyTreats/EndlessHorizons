using UnityEngine;

namespace Engine
{
	public class SpriteData
	{
		private Texture2D m_texture;
		private Rect m_rect = new Rect();
		private float m_pixelsPerUnit;

		public Texture2D Texture { get { return m_texture; } }
		public Rect Rect { get { return m_rect; } }
		public float PixelsPerUnit { get { return m_pixelsPerUnit; } }

		public SpriteData(string resourcePath, float pixelsPerUnit)
		{
			m_texture = Resources.Load<Texture2D>(resourcePath) as Texture2D;
			m_rect = new Rect(0, 0, m_texture.width, m_texture.height);
			m_pixelsPerUnit = pixelsPerUnit;
		}
	}
}
