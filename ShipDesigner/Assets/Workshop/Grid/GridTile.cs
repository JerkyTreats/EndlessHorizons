using System.Collections.Generic;
using UnityEngine;

namespace Workshop
{
	public class GridTile
	{
		private float m_length { get; set; }
		private float m_width { get; set; }
		private Vector3 m_position;

		public GridTile(float length, float width, Vector3 position)
		{
			m_length = length;
			m_width = width;
			m_position = position;
		}

		public Vector3 Position { get { return m_position; } }
	}
}
