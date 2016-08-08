using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI
{
	public static class InventoryFactory
	{
		public static void BuildInventory(GameObject canvas)
		{
			GameObject panel = BuildPanel(canvas);
		}

		private static GameObject BuildPanel(GameObject canvas)
		{
			GameObject panel = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/InventoryPanel"));
			panel.name = "InventoryPanel";
			panel.transform.parent = canvas.transform;
			SetStartPosition(panel);
			BuildPanelSelectionArea(panel);

			InventoryComponent component = panel.AddComponent<InventoryComponent>();
			InventoryController controller = BuildInventoryController(panel);
			component.SetController(controller);

			return panel;
		}

		private static void SetStartPosition(GameObject panel)
		{
			RectTransform rect = panel.GetComponent<RectTransform>();
			rect.anchorMax = new Vector2();
			rect.anchorMin = new Vector2();
			rect.pivot = new Vector2();
			rect.anchoredPosition = new Vector2(10f, 10f);
		}

		private static void BuildPanelSelectionArea(GameObject panel)
		{
			var selectionArea = panel.transform.GetChild(panel.transform.childCount - 1);
			selectionArea.gameObject.AddComponent<Drag>();
		}

		private static InventoryController BuildInventoryController(GameObject panel)
		{
			RectTransform rect = panel.GetComponent<RectTransform>();
			Vector4 border = panel.GetComponent<Image>().sprite.border;

			Vector2 min = new Vector2(rect.anchoredPosition.x + border.x, rect.anchoredPosition.y + border.y);
			Vector2 max = new Vector2((rect.anchoredPosition.x + rect.sizeDelta.x) - border.z, (rect.anchoredPosition.y + rect.sizeDelta.y) - border.w);

			return new InventoryController(min, max);
		}
	}
}
