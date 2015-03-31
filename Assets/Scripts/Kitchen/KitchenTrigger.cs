using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Kitchen
{
	public class KitchenTrigger : MonoBehaviour {
//		public Character.Character characterInTrigger;
//		public bool isActive;
//		private int numberOfCooks = 0;
		public List<Character.Character> charactersInTrigger;

		void Start()
		{
			charactersInTrigger = new List<Character.Character>();
//			characterInTrigger = null;
//			isActive = false;
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			charactersInTrigger.Add (other.gameObject.GetComponent<Character.Character>());
			//isActive = true;
			Debug.Log(other.gameObject.name + " has entered the kitchen trigger");
//			if (characterInTrigger == null)
//			{ 
//				characterInTrigger = other.gameObject.GetComponent<Character.Character>();
//			}
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

//			numberOfCooks = - 1;
//			if (numberOfCooks==0)
//			{
//				isActive = false;
//				characterInTrigger = null;
//			} else {
//				characterInTrigger = other.gameObject.GetComponent<Character.Character>();
//			}
//			Debug.Log(other.gameObject.name + " has entered the kitchen trigger");
		}
	}
}