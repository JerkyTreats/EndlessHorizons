using System.Collections.Generic;
using UnityEngine;
using Engine;

namespace Workshop
{
	public class TileController
	{
		private static string GAME_OBJECT_NAME = "GridTile";

		private Vector3 m_position;
		private SpriteData m_spriteData;

		public Vector3 Position { get { return m_position; } }
		public SpriteData SpriteData { get { return m_spriteData; } }
		public bool Visible { get; set; }

		public TileController(Vector3 position, SpriteData spriteData)
		{
			m_position = position;
			m_spriteData = spriteData;
			Visible = true;
		}
	}
}
