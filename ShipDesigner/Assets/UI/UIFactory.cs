using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public static class UIFactory
	{
		public static void BuildUI()
		{
			var canvas = BuildCanvas();
			BuildInventory(canvas);
		}

		private static GameObject BuildCanvas()
		{
			GameObject canvas = new GameObject("Canvas");
			Canvas canvasComponent = canvas.AddComponent<Canvas>();
			canvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.AddComponent<CanvasScaler>();
			canvas.AddComponent<GraphicRaycaster>();
			return canvas;
		}

		static void BuildInventory(GameObject canvas)
		{
			GameObject panel = new GameObject("Panel");
			panel.transform.parent = canvas.transform;

			var rect = panel.AddComponent<RectTransform>();
			var renderer = panel.AddComponent<CanvasRenderer>();
			var image = panel.AddComponent<Image>();

			rect.anchorMax = new Vector2();
			rect.anchorMin = new Vector2();
			rect.pivot = new Vector2();
			rect.anchoredPosition = new Vector2 (10f, 10f);
		}
	}
}
