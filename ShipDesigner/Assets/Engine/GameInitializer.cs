using UnityEngine;
using View;
using Workshop;
using UI;

namespace ShipDesigner
{
	class GameInitializer : MonoBehaviour
	{
		void Start()
		{
			GridFactory.InitializeGrid();
			CameraFactory.BuildCamera();
			UIFactory.BuildUI();
		}
	}
}
