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

			GameObject go = new GameObject("Quad");
			ComponentManager manager = new ComponentManager(go);
			manager.Start();
			manager.Extend();


			//Vector3 vertex = go.GetComponent<MeshFilter>().mesh.vertices[2];
			//Debug.Log(string.Format("Vertex coordinate = [{0}]", (position + vertex)));
			
			Destroy(gameObject);
		}
	}
}
