using UnityEngine;
using System.Collections;

namespace Ships.Components
{
	public class EquipmentComponent : MonoBehaviour
	{
		EquipmentController Controller;

		public void SetController (EquipmentController controller)
		{
			Controller = controller;
		}
	}
}

