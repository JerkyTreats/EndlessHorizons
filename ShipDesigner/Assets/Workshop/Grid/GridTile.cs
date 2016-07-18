using System.Collections.Generic;
using UnityEngine;

namespace Workshop
{
	public class GridTile
	{
		private float m_length;
		private float m_width;
		private Vector3 m_position;
		private string m_sprite;

		public float Length { get { return m_length; } }
		public float Width { get { return m_width; } }
		public Vector3 Position { get { return m_position; } }
		public string Sprite { get { return m_sprite; } }
		public bool Visible { get; set; }

		public GridTile(float length, float width, Vector3 position, string spritePath)
		{
			m_length = length;
			m_width = width;
			m_position = position;
			m_sprite = spritePath;
			Visible = true;
		}
	}
}
