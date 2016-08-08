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
			GameDataFactory.BuildGameData();
			GridFactory.InitializeGrid();
			CameraFactory.BuildCamera();
			UIFactory.BuildUI();

			Destroy(gameObject);
		}
	}
}
