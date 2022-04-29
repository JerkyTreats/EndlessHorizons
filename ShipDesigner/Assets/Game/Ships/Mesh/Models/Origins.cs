using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
	public enum Length { Short, Long }
	public enum Height { Top, Bottom }
	public enum Depth { Shallow, Deep }

	/// <summary>
	/// Sets the origin points for a piece of Geo. 
	/// Has custom min/max x,y,z positions, so complex geo will always be in a 'box'
	/// </summary>
	public class Origins
	{
		Vector3 m_center = Vector3.zero;

		float m_short = 0;
		float m_long = 0;

		float m_bottom = 0;
		float m_top = 0;

		float m_shallow = 0;
		float m_deep = 0;

		public Origins(List<Vertex> vertices)
		{
			for (int i = 0; i < vertices.Count; i++)
			{
				float x = vertices[i].Position.x;
				float y = vertices[i].Position.y;
				float z = vertices[i].Position.z;

				if (x < m_short)
					m_short = x;
				if (x > m_long)
					m_long = x;

				if (y < m_bottom)
					m_short = y;
				if (y > m_top)
					m_long = y;

				if (z < m_shallow)
					m_short = z;
				if (z > m_deep)
					m_long = z;
			}

			m_center = new Vector3(m_long - m_short, m_top - m_bottom, m_deep - m_shallow);
		}

		float GetLength(Length length)
		{
			if (length == Length.Short)
				return m_short;
			return m_long;
		}

		float GetHeight(Height height)
		{
			if (height == Height.Bottom)
				return m_bottom;
			return m_top;
		}

		float GetDepth(Depth depth)
		{
			if (depth == Depth.Shallow)
				return m_shallow;
			return m_deep;
		}

		public void SetOrigin(Length length, Height height, Depth depth)
		{
			Origin = new Vector3(GetLength(length), GetHeight(height), GetDepth(depth));
		}

		public Vector3 Center { get { return m_center; } }
		public Vector3 Default { get { return new Vector3(m_short, m_bottom, m_shallow); } }
		public Vector3 Origin { get; set; }
	}
}
