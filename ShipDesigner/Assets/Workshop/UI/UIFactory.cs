using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UI.Inventory;

namespace UI
{
	public static class UIFactory
	{
		public static void BuildUI()
		{
			var canvas = BuildCanvas();
			BuildEventSystem();
			InventoryFactory.BuildInventory(canvas);
		}

		private static GameObject BuildCanvas()
		{
			GameObject canvas = new GameObject("Canvas");
			Canvas canvasComponent = canvas.AddComponent<Canvas>();
			canvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.AddComponent<CanvasScaler>();
			canvas.AddComponent<GraphicRaycaster>();

			Engine.GameData.Instance.SetCanvas(canvasComponent);

			return canvas;
		}

		private static void BuildEventSystem()
		{
			GameObject eventSystem = new GameObject("EventSystem");
			eventSystem.AddComponent<EventSystem>();
			eventSystem.AddComponent<StandaloneInputModule>();
		}
	}
}
