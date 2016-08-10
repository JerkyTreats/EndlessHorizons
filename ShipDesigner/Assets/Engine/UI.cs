using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
	public static class UI
	{
		public static GameObject BuildUIObject(string name, GameObject parent, Vector2 anchor, Vector2 sizeDelta, Vector2 pivot, Vector2 position)
		{
			GameObject uiObject = new GameObject(name);
			uiObject.transform.SetParent(parent.transform);

			RectTransform rect = uiObject.AddComponent<RectTransform>();
			rect.anchorMin = anchor;
			rect.anchorMax = anchor;
			rect.anchoredPosition = position;
			rect.pivot = pivot;
			rect.sizeDelta = sizeDelta;

			return uiObject;
		}
	}
}
