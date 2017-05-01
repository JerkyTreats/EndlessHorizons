using UnityEngine;
using View;
using Workshop.Grid;
using UI;
using Ships.Blueprints;

namespace Engine
{
	class GameInitializer : MonoBehaviour
	{
		void Start()
		{
			Blueprints.OnGameStart();
			GridFactory.InitializeGrid();
			CameraFactory.BuildCamera();
			UIFactory.BuildUI();

			Destroy(gameObject);
		}
	}
}
