using UnityEngine;
using Ships.Components;
using Ships.Blueprints;
using System.Linq;
using System.Text;

namespace Engine
{
	/// <summary>
	/// Holds cross-game data and references in a singleton class
	/// </summary>
	public class GameData
	{
		private static GameData m_instance;
		private static readonly object m_padlock = new object();

		public ComponentRepository Components;
		public Canvas Canvas { get; set; }
		public GameObject Grid { get; set; }
		public GameObject Blueprint { get; set; }

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

		public void SetGrid(GameObject grid)
		{
			Grid = grid;
		}

		public void SetCanvas(Canvas canvas)
		{
			Canvas = canvas;
		}
	}
}
