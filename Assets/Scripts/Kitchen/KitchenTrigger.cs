using UnityEngine;
using System.Collections;

namespace Kitchen
{
	public class KitchenTrigger : MonoBehaviour {
		public bool isActive;
		public Character.Character characterInTrigger;

		void Start()
		{
			characterInTrigger = null;
			isActive = false;
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			Debug.Log(other.gameObject.name + " has entered the kitchen trigger");
			isActive = true;
			characterInTrigger = other.gameObject.GetComponent<Character.Character>();
		}
		void OnTriggerExit2D(Collider2D other)
		{
			Debug.Log(other.gameObject.name + " has entered the kitchen trigger");
			isActive = false;
			characterInTrigger = null;
		}
	}
}