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

			//THIS IS TEST PLZ DELETE
			Logger.Instance.LoggingEnabled.Add(GameAreas.Camera);
			GameObject go = new GameObject("Quad");
			go.transform.position = new Vector3(13, 9);
			Quad quad = new Quad(verts: 16);
			quad.RenderQuad(go);

			Destroy(gameObject);
		}
	}
}
