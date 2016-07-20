using UnityEngine;
using View;

namespace Workshop
{
	class GridFactory_GameObject : MonoBehaviour
	{
		void Start()
		{
			GridFactory.BuildGrid();
			CameraFactory.BuildCamera();
		}
	}
}
