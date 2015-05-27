using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Needs;

namespace InteractableObjects.Bed
{
	class Bed : InteractableObject
	{
		public Characters.Character Occupant { get; set; }

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
				Occupant = other.gameObject.GetComponent<Characters.Character>();
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
				Occupant = null; //Just in case, right?
			}
		}

		//Publically accessable method to go to this objects location.
		//Simply moves to a protected GoToObjectLocation;
		public void GoToBed(Characters.Character owner)
		{
			GoToObjectLocation(owner);
		}

		public void Update()
		{
			if (Occupant != null)
			{
				Need toUpdate = Occupant.Needs.LookUp(ActionType);
				toUpdate.IncreaseCurrentValue(Mathf.RoundToInt(Time.deltaTime));
			}
		}
	}
}
