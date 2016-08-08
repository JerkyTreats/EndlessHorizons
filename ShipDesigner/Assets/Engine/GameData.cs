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

	}


	//public class GameData : MonoBehaviour
	//{
	//	ComponentRepository Components;

	//	void Start()
	//	{
	//		Components = new ComponentRepository();
	//	}
	//}
}
