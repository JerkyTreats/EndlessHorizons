using UnityEngine;
using Ships.Components;
using Ships.Blueprints;
using System.Linq;
using System.Text;
using Workshop.Grid;
using Engine.Utility;

namespace Engine
{
	/// <summary>
	/// Holds cross-game data and references in a singleton class
	/// </summary>
	public class GameData
	{
		private static GameData m_instance;
		private static readonly object m_padlock = new object();
		private float m_zAxisItemPlacement;
		private GameObject m_blueprint;

		public ComponentRepository Components;
		public Canvas Canvas { get; set; }
		public GameObject Grid { get; set; }
		public GameObject Blueprint {
			get { return m_blueprint; }
			set
			{
				if (m_blueprint == null)
				{
					m_blueprint = value;
					return;
				}
				
				Util.DestroyGameObjectFamily(m_blueprint);
				m_blueprint = value;

				Blueprint controller = value.GetComponent<Blueprint>();
				controller.SpawnChildren();
			}
		}
		public float ZAxisItemPlacement { get { return m_zAxisItemPlacement; } }

		GameData()
		{
			Components = new ComponentRepository();
		}

		/// <summary>
		/// Singleton reference to the GameData instance
		/// </summary>
		public static GameData Instance
		{
			get
			{
				lock (m_padlock)
				{
					if (m_instance == null)
						m_instance = new GameData();
					return m_instance;
				}
			}
		}

		/// <summary>
		/// Sets the global Grid object. This gameObject should definitely have a Grid component attached
		/// </summary>
		/// <param name="grid">The grid gameobject to set</param>
		public void SetGrid(GameObject grid)
		{
			Grid = grid;
			m_zAxisItemPlacement = Grid.GetComponent<Workshop.Grid.Grid>().ZAxisItemPlacement;
		}

		/// <summary>
		/// Sets the global canvas object
		/// </summary>
		/// <param name="canvas">The global canvas object</param>
		public void SetCanvas(Canvas canvas)
		{
			Canvas = canvas;
		}
	}
}
