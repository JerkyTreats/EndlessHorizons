using UnityEngine;
using UnityEngine.EventSystems;

namespace Ships.Components
{
	public class TileComponent : MonoBehaviour
	{
		TileController Controller;

		public void SetController (TileController controller)
		{
			Controller = controller;
		}

		public void Render()
		{
			Controller.Sprite.RenderQuad(gameObject);
		}
	}
}


