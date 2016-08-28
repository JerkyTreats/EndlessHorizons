using UnityEngine;
using Ships.Components;
using System.Linq;
using System.Text;

namespace Engine
{
	public class GameData
	{
		private static GameData m_instance;
		private static readonly object m_padlock = new object();

		public ComponentRepository Components;
		public Canvas Canvas { get; set; }
		public GameObject Grid { get; set; }

		GameData()
		{
			Components = new ComponentRepository();
		}

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

		public void SetGrid(GameObject Grid)
		{
			this.Grid = Grid;
		}

		public void SetCanvas(Canvas Canvas)
		{
			this.Canvas = Canvas;
		}
	}
}
