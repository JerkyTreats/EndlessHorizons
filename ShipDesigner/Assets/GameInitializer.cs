using UnityEngine;
using View;
using Workshop;

namespace ShipDesigner
{
	class GameInitializer : MonoBehaviour
	{
		void Start()
		{
			GridFactory.InitializeGrid();
			CameraFactory.BuildCamera();
		}
	}
}
