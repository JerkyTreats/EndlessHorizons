using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InteractableObjects.Bed
{
	class Bed : InteractableObject
	{
		public Character.Character Occupant { get; set; }

		public override void Start()
		{
			base.Start();
			ActionType = "sleep";
		}

		//Add the occupant and state that it's occupied
		void OnTriggerEnter2D(Collider2D other)
		{
			if (Occupant != null) //determine if someone is already in bed
			{
				Occupant = other.gameObject.GetComponent<Character.Character>();
			}
			else
			{
				Debug.Log("Bed is already occupied");
			}
		}

		//Null the occupant, bed should be empty.
		void OnTriggerExit2D(Collider2D other)
		{
			if (Occupant != null) //Ensure that the bed was occupied
			{
				Occupant = null;
			}
			else
			{
				Debug.LogError("Bed.OnTriggerExit2D: Occupant left trigger but was already null!");
			}
		}
	}
}
