using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace UI.Inventory.Item
{
	public class OnClick : MonoBehaviour
	{

		// Use this for initialization
		void Start()
		{
			EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = EventTriggerType.PointerClick;
			entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); } );
			trigger.triggers.Add(entry);
		}

		public void OnPointerDownDelegate(PointerEventData data)
		{
				Debug.Log("OnPointerDownDelegate called.");
		}
	}
}

