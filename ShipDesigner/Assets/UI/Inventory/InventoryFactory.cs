using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public static class InventoryFactory
	{
		public static void BuildInventory(GameObject canvas)
		{
			GameObject panel = BuildPanel(canvas);
		}

		public static GameObject BuildInventoryItemPanel(string name, Sprite sprite, Transform transform, Vector2 anchor, Vector2 spriteSize, Vector2 pivot, Vector2 position, Vector2 textSize)
		{
			GameObject inventoryItem = Engine.UI.BuildImageUIObject(name, sprite, transform, pivot, spriteSize, pivot, position);
			AddText(name, inventoryItem.transform, textSize);

			return inventoryItem;
		}

		private static void AddText(string name, Transform transform, Vector2 textSize)
		{
			GameObject textArea = new GameObject("Text");
			textArea.transform.SetParent(transform);
			Text text = textArea.AddComponent<Text>();

			text.text = name;
			text.verticalOverflow = VerticalWrapMode.Overflow;
			text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			text.alignment = TextAnchor.MiddleCenter;
			text.resizeTextForBestFit = true;

			Vector2 vector = new Vector2();
			RectTransform rect = textArea.GetComponent<RectTransform>();
			rect.anchorMin = vector;
			rect.anchorMax = vector;
			rect.sizeDelta = textSize;
			vector.x = rect.sizeDelta.x / 2;
			vector.y = ((rect.sizeDelta.y / 2) + 1f) * -1;
			rect.anchoredPosition = vector;
		}

		private static GameObject BuildPanel(GameObject canvas)
		{
			GameObject panel = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/InventoryPanel"));
			panel.name = "InventoryPanel";
			panel.transform.SetParent(canvas.transform);
			SetStartPosition(panel);
			BuildPanelSelectionArea(panel);
			var scrollRect = BuildInventoryArea(panel);

			InventoryComponent component = panel.AddComponent<InventoryComponent>();
			InventoryController controller = BuildInventoryController(scrollRect);
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

		private static InventoryController BuildInventoryController(GameObject scrollRect)
		{
			return new InventoryController(scrollRect);
		}

		private static GameObject BuildInventoryArea(GameObject panel)
		{
			RectTransform panelRect = panel.GetComponent<RectTransform>();
			Vector4 border = panel.GetComponent<Image>().sprite.border;

			Vector2 sizeDelta = GetInventoryAreaSize(panelRect, border);
			Vector2 anchor = GetInventoryAreaAnchor(panelRect, border);
			Vector2 pivot = new Vector2(0, 1);
			Vector2 position = new Vector2();

			GameObject scrollContainer = Engine.UI.BuildEmptyUIObject("ScrollContainer", panel, anchor, sizeDelta, pivot, new Vector2());
			scrollContainer.AddComponent<ScrollRect>();

			GameObject inventoryArea = Engine.UI.BuildEmptyUIObject("InventoryArea", scrollContainer, new Vector2(0,1), sizeDelta, pivot, position);

			return inventoryArea;
		}

		//BORDER: X=left, Y=bottom, Z=right, W=top.
		//Determine the size of the inventory area panel by adding the padded sides for each axis
		//Subtract that amount from the height/width (sizeDelta) of the parent RectTransform
		private static Vector2 GetInventoryAreaSize(RectTransform panelRect, Vector4 border)
		{
			return new Vector2(panelRect.sizeDelta.x - (border.x + border.z), panelRect.sizeDelta.y - (border.y + border.w));
		}

		//We want the anchor point to be the top left of the "inside" of the inventory area. 
		//We take the sprite border and convert it into a percentage based on the Width of the parent RectTransform
		//This gives us the exact padding amount we want for the inventory area anchor
		private static Vector2 GetInventoryAreaAnchor(RectTransform panelRect, Vector4 border)
		{
			return new Vector2(0 + (border.x / panelRect.sizeDelta.x), 1 - (border.w / panelRect.sizeDelta.y));
		}
	}
}
