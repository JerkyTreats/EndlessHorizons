using System.Collections.Generic;
using UnityEngine;

namespace Workshop
{
	public class GridTile
	{
		private static string GAME_OBJECT_NAME = "GridTile";

		private Vector3 m_position;
		private Sprite m_sprite;
		private GameObject m_tileGameObject;
		private GridTile_GameObject m_tileGameObjectScript;

		public Vector3 Position { get { return m_position; } }
		public Sprite Sprite { get { return m_sprite; } }
		public bool Visible { get; set; }
		public GameObject TileGameObject {get {return m_tileGameObject;} }

		public GridTile(Vector3 position, Sprite sprite)
		{
			m_position = position;
			m_sprite = sprite;
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
