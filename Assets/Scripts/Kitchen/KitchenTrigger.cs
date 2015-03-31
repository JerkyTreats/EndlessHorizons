using UnityEngine;
using System.Collections;

namespace Kitchen
{
	public class KitchenTrigger : MonoBehaviour {
		public Character.Character characterInTrigger;
		public int numberOfCooks;

		void Start()
		{
			characterInTrigger = null;
			numberOfCooks = 0;
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			numberOfCooks += 1;
			Debug.Log(other.gameObject.name + " has entered the kitchen trigger");
			characterInTrigger = other.gameObject.GetComponent<Character.Character>();
		}
		void OnTriggerExit2D(Collider2D other)
		{
			numberOfCooks -= 1;
			Debug.Log(other.gameObject.name + " has entered the kitchen trigger");
			characterInTrigger = null;
		}
	}
}