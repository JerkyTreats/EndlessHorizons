using Engine;
using System;
using UI.Inventory.Item;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
	public static class BuildUIObject
	{
		/// <summary>
		/// Builds and returns an empty UI object
		/// </summary>
		/// <param name="name">Name of the UI Object to build</param>
		/// <param name="parent">Parent object UI Object to be a child of. Should be a [grand]child of Canvas</param>
		/// <param name="anchor"> Anchor of the UI Object in RectTransform space</param>
		/// <param name="sizeDelta"> Size of the UI Object RectTransform</param>
		/// <param name="pivot"> Pivot point of the UI Object</param>
		/// <param name="position"> Position of the UI Object in relation to the parent</param>
		/// <returns></returns>
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

		/// <summary>
		/// Add Text Label to a UI GameObject
		/// </summary>
		/// <param name="textPanelSize">Size of the panel</param>
		/// <param name="textData">Text Data containing text, font, etc</param>
		/// <param name="parent"> Parent UI Object to be a child of. Parent should be a [grand]child of Canvas</param>
		public static void AddTextLabel(Vector2 textPanelSize, TextData textData, Transform parent)
		{
			TextLabel.BuildTextLabel(parent, textData, textPanelSize);
		}

		/// <summary>
		/// Add a Placement Handler to a UI GameObject
		/// </summary>
		/// <param name="gameObject">GameObject to add the PlacementHandler to</param>
		/// <param name="previewQuad">Quad object to appear during drag operations</param>
		public static void AddPlacementHandler(GameObject gameObject, Quad previewQuad, iInventoryObjectSpawner spawner)
		{
			PlacementHandler placementHandler = gameObject.AddComponent<PlacementHandler>();
			placementHandler.Quad = previewQuad;
			placementHandler.ObjectSpawner = spawner;
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
