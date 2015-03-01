using UnityEngine;
using System.Collections;

namespace Kitchen
{
	public class KitchenTrigger : MonoBehaviour {
		public CircleCollider2D colliderTrigger;
		public bool isActive = false;

		void Start()
		{
			colliderTrigger = GetComponent<CircleCollider2D>();
		}

		void OnTriggerEnter2D()
		{
			isActive = true;
			//NotificationCenter.DefaultCenter().PostNotification(this, "KitchenNodeActive");
		}
		void OnTriggerExit2D()
		{
			isActive = false;
			//NotificationCenter.DefaultCenter().PostNotification(this, "KitchenNodeInactive");
		}
	}
}