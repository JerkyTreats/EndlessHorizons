using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI.Inventory.Item
{
	public class ItemComponent : MonoBehaviour
	{
		ItemController Controller;
		
		public void SetController(ItemController controller)
		{
			Controller = controller;
		}

		public void AddTextLabel()
		{
			GameObject textArea = new GameObject("Text");
			textArea.transform.SetParent(transform);
			Text text = textArea.AddComponent<Text>();
			Controller.SetTextData(text);

			Vector2 vector = new Vector2();
			RectTransform rect = textArea.GetComponent<RectTransform>();
			rect.anchorMin = vector;
			rect.anchorMax = vector;
			rect.sizeDelta = Controller.TextPanelSize;
			vector.x = rect.sizeDelta.x / 2;
			vector.y = ((rect.sizeDelta.y / 2) + 1f) * -1;
			rect.anchoredPosition = vector;
		}
	}
}

