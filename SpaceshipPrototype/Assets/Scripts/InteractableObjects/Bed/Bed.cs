using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Characters;

namespace InteractableObjects
{
	class Bed : InteractableObject
	{
		override public void Start()
		{
			ActionType = "sleep";
			base.Start();
		}

		//What happens when the character enters the Bed;
		void OnTriggerEnter2D(Collider2D other)
		{
			Character occupant = other.gameObject.GetComponent<Character>();
			occupant.CurrentInteractableObject = this;
		}

		//Define what happens with the Character leaves the bed;
		void OnTriggerExit2D(Collider2D other)
		{
			Character occupant = other.gameObject.GetComponent<Character>();
			occupant.CurrentInteractableObject = null;
		}

		//Called per frame(ish)
		// public void Update()
		// {
		// 	if (Occupant != null)
		// 	{
		// 		if (sa != null)
		// 		{
		// 			sa.UpdateSleep();
		// 		}
		// 	}
		// }
	}
}
