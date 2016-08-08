using UnityEngine;
using Ships.Components;
using System.Linq;
using System.Text;

namespace Engine
{
	public class GameData : MonoBehaviour
	{
		ComponentRepository Components;

		void Start()
		{
			Components = new ComponentRepository();
		}
	}
}
