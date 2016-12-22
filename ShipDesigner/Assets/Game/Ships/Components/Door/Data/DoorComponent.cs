using UnityEngine;
using System.Collections;

namespace Ships.Components
{
	public class DoorComponent : MonoBehaviour
	{
		DoorController Controller;

		public void SetController(DoorController controller)
		{
			Controller = controller;
		}
	}
}

