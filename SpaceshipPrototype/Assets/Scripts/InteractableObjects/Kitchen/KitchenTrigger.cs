using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InteractableObjects
{
	/// <summary>
	/// Trigger for the Kitchen. 
	/// It knows which character is in each kitchen trigger, so that correct pendingMeal object will update for correct Character.
	/// Has a List of characters current in its trigger
	/// </summary>
	public class KitchenTrigger : MonoBehaviour {
		public List<Characters.Character> CharactersInTrigger;

		//initialize
		void Start()
		{
			CharactersInTrigger = new List<Characters.Character>();
		}

		//Change Debug.Log to a better logging system. 
		//Add a character to the list on entry
		void OnTriggerEnter2D(Collider2D other)
		{
			CharactersInTrigger.Add (other.gameObject.GetComponent<Characters.Character>());
			Debug.Log(other.gameObject.name + " has entered the kitchen trigger");
		}

		//Remove the character from the list on exit
		void OnTriggerExit2D(Collider2D other)
		{
			Characters.Character obj = other.gameObject.GetComponent<Characters.Character> ();
			if (CharactersInTrigger.Contains(obj))
			{
				CharactersInTrigger.Remove(obj);
			} else 
			{
				Debug.LogError ("Character " + other + " was not in charactersInTriggerList");
			}
		}
	}
}