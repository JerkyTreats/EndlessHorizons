using System.Collections.Generic;
using UnityEngine;

namespace Workshop
{
	public class GridTile
	{
		private static string GAME_OBJECT_NAME = "GridTile";

		private float m_length;
		private float m_width;
		private Vector3 m_position;
		private string m_sprite;
		private GameObject m_tileGameObject;
		private GridTile_GameObject m_tileGameObjectScript;

		public float Length { get { return m_length; } }
		public float Width { get { return m_width; } }
		public Vector3 Position { get { return m_position; } }
		public string Sprite { get { return m_sprite; } }
		public bool Visible { get; set; }
		public GameObject TileGameObject {get {return m_tileGameObject;} }

		public GridTile(float length, float width, Vector3 position, string spritePath)
		{
			m_length = length;
			m_width = width;
			m_position = position;
			m_sprite = spritePath;
			Visible = true;

			InitializeGameObject();
		}

		private void InitializeGameObject()
		{
			m_tileGameObject = new GameObject(GAME_OBJECT_NAME);
			m_tileGameObjectScript = m_tileGameObject.AddComponent<GridTile_GameObject>();
			m_tileGameObjectScript.Initialize(this);
		}
	}
}
