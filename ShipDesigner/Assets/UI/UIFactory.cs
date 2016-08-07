using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UI
{
	public static class UIFactory
	{
		public static void BuildUI()
		{
			var canvas = BuildCanvas();
			BuildEventSystem();
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

		private static void BuildEventSystem()
		{
			GameObject eventSystem = new GameObject("EventSystem");
			eventSystem.AddComponent<EventSystem>();
			eventSystem.AddComponent<StandaloneInputModule>();
		}

		static void BuildInventory(GameObject canvas)
		{
			GameObject panel = BuildPanel(canvas);
			FillInventory(panel);
		}

		private static GameObject BuildPanel(GameObject canvas)
		{
			GameObject panel = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/InventoryPanel"));
			panel.name = "InventoryPanel";
			panel.transform.parent = canvas.transform;

			RectTransform rect = panel.GetComponent<RectTransform>();
			rect.anchorMax = new Vector2();
			rect.anchorMin = new Vector2();
			rect.pivot = new Vector2();
			rect.anchoredPosition = new Vector2(10f, 10f);
			BuildPanelSelectionArea(panel);
			return panel;
		}

		private static void BuildPanelSelectionArea(GameObject panel)
		{
			var selectionArea = panel.transform.GetChild(panel.transform.childCount - 1);
			selectionArea.gameObject.AddComponent<Drag>();
		}

		private static void FillInventory(GameObject panel)
		{
			//var imageComponent = panel.GetComponent<Image>();
			//var border = imageComponent.sprite.border;

			GameObject inventoryArea = panel.transform.GetChild(1).gameObject;
			int max = 0;
			for (int i = 0; i < max; i++)
			{

			}
		}

	}
}
