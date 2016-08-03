using UnityEngine;
using System.Collections;

public class UIEngineComponent : MonoBehaviour
{
	RectTransform Rect;

	void Awake()
	{
		Rect = GetComponent<RectTransform>();
		if (Rect == null)
			Rect = gameObject.AddComponent<RectTransform>();


	}
}
