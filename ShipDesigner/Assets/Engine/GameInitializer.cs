using UnityEngine;
using View;
using Workshop.Grid;
using UI;

namespace Engine
{
	class GameInitializer : MonoBehaviour
	{
		void Start()
		{
			GridFactory.InitializeGrid();
			CameraFactory.BuildCamera();
			UIFactory.BuildUI();

			Destroy(gameObject);
		}
	}
}
