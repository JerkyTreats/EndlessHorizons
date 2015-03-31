using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Kitchen
{
	public class KitchenTrigger : MonoBehaviour {
		public List<Character.Character> charactersInTrigger;

		void Start()
		{
			charactersInTrigger = new List<Character.Character>();
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			charactersInTrigger.Add (other.gameObject.GetComponent<Character.Character>());
			Debug.Log(other.gameObject.name + " has entered the kitchen trigger");
		}

		void OnTriggerExit2D(Collider2D other)
		{
			Character.Character obj = other.gameObject.GetComponent<Character.Character> ();
			if (charactersInTrigger.Contains(obj))
			{
				charactersInTrigger.Remove(obj);
			} else 
			{
				Debug.LogError ("Character " + other + " was not in charactersInTriggerList");
			}
		}
	}
}