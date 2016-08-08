using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
	public static class GameDataFactory
	{
		public static GameObject BuildGameData()
		{
			GameObject data = new GameObject("GameData");
			data.AddComponent<GameData>();
			return data;
		}
	}
}
