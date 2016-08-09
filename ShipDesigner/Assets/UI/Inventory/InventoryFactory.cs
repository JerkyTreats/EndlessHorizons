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
			BuildInventoryAreaScrollRect(panel);

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
			return new InventoryController();
		}

		private static void BuildInventoryAreaScrollRect(GameObject panel)
		{
			RectTransform panelRect = panel.GetComponent<RectTransform>();
			Vector4 border = panel.GetComponent<Image>().sprite.border;

			GameObject inventoryArea = new GameObject("InventoryArea");
			inventoryArea.transform.SetParent(panel.transform);
			RectTransform rect = inventoryArea.AddComponent<RectTransform>();

			//We want the anchor point to be the top left of the "inside" of the inventory area. 
			//We take the sprite border and convert it into a percentage based on the Width of the parent RectTransform
			//This gives us the exact padding amount we want for the inventory area anchor
			Vector2 anchorPosition = new Vector2(0 + (border.x / panelRect.sizeDelta.x), 1 - (border.w / panelRect.sizeDelta.y));
			rect.anchorMin = anchorPosition;
			rect.anchorMax = anchorPosition;
			rect.pivot = new Vector2(0,1);

			//BORDER: X=left, Y=bottom, Z=right, W=top.
			//Determine the size of the inventory area panel by adding the padded sides for each axis
			//Subtract that amount from the height/width (sizeDelta) of the parent RectTransform
			float height = panelRect.sizeDelta.x - (border.x + border.z);
			float width = panelRect.sizeDelta.y - (border.y + border.w);
			rect.sizeDelta = new Vector2(height, width);
			rect.anchoredPosition = new Vector2();
		}
	}
}
