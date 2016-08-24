using System;
using UnityEngine;
using UnityEngine.UI;

namespace Engine.UI
{
	public static class Common
	{
		public static GameObject BuildEmptyUIObject(string name, GameObject parent, Vector2 anchor, Vector2 sizeDelta, Vector2 pivot, Vector2 position)
		{
			GameObject uiObject = new GameObject(name);
			uiObject.transform.SetParent(parent.transform);

			RectTransform rect = uiObject.AddComponent<RectTransform>();
			SetRectTransform(anchor, sizeDelta, pivot, position, rect);

			return uiObject;
		}

		public static GameObject BuildImageUIObject(string name, Sprite sprite, Transform parent, Vector2 anchor, Vector2 sizeDelta, Vector2 pivot, Vector2 position)
		{
			GameObject gameObject = new GameObject(name);
			gameObject.transform.SetParent(parent);

			Image image = gameObject.AddComponent<Image>();
			image.sprite = sprite;

			RectTransform rect = gameObject.GetComponent<RectTransform>();
			SetRectTransform(anchor, sizeDelta, pivot, position, rect);

			return gameObject;
		}

		private static void SetRectTransform(Vector2 anchor, Vector2 sizeDelta, Vector2 pivot, Vector2 position, RectTransform rect)
		{
			rect.anchorMin = anchor;
			rect.anchorMax = anchor;
			rect.anchoredPosition = position;
			rect.pivot = pivot;
			rect.sizeDelta = sizeDelta;
		}
	}
}
