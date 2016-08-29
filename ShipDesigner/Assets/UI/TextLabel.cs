using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public static class TextLabel
	{

		/// <summary>
		/// Build and return a Text UI GameObject
		/// </summary>
		/// <param name="parent">Parent GameObject label is to be attached to</param>
		/// <param name="data"> TextData containing text information and value settings</param>
		/// <param name="textPanelSize"> Vector2 size of the panel</param>
		/// <returns></returns>
		public static GameObject BuildTextLabel(Transform parent, TextData data, Vector2 textPanelSize)
		{
			GameObject textArea = new GameObject("Text");
			textArea.transform.SetParent(parent);
			Text text = textArea.AddComponent<Text>();
			SetRect(textArea, textPanelSize);
			SetTextData(text, data);

			return textArea;
		}

		private static void SetRect(GameObject textArea, Vector2 textPanelSize)
		{
			Vector2 vector = new Vector2();
			RectTransform rect = textArea.GetComponent<RectTransform>();
			rect.anchorMin = vector;
			rect.anchorMax = vector;
			rect.sizeDelta = textPanelSize;
			vector.x = rect.sizeDelta.x / 2;
			vector.y = ((rect.sizeDelta.y / 2) + 1f) * -1;
			rect.anchoredPosition = vector;
		}

		private static void SetTextData(Text text, TextData textData)
		{
			text.text = textData.Text;
			text.verticalOverflow = textData.VerticalWrapMode;
			text.font = textData.Font;
			text.alignment = textData.TextAnchor;
			text.resizeTextForBestFit = textData.BestFit;
		}
	}
}
