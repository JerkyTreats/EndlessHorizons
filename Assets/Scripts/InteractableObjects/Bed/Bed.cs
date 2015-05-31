using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Needs;
using NPC.Action;

namespace InteractableObjects.Bed
{
	class Bed : InteractableObject
	{
		public NPC.NPC Occupant { get; set; }
		private SleepAction sa;

		override public void Start()
		{
			ActionType = "sleep";
			base.Start();
		}

		//What happens when the character enters the Bed;
		void OnTriggerEnter2D(Collider2D other)
		{
			Occupant = other.gameObject.GetComponent<NPC.NPC>();

			//if the actiontype of the NPC's current action matches IO actiontype, assume the Action can be successfully cast to a SleepAction
			if (Occupant.planner.CurrentAction.ActionType.Equals(ActionType)) 
			{
				sa = (SleepAction)Occupant.planner.CurrentAction;
				sa.StartSleep();
			}
			else
			{
				Debug.Log("Bed.OnTriggerEnter => Occupant Current Action differs from Beds");
			}
		}

		//Define what happens with the Character leaves the bed;
		void OnTriggerExit2D(Collider2D other)
		{
			if (sa != null)
			{
				sa.FinishSleep();
			}
			else
			{
				Debug.LogError("Bed.OnTriggerExit2D => SleepAction was null!");
			}
			Occupant = null;
			sa = null;
		}

		//Publically accessable method to go to this objects location.
		//Simply moves to a protected GoToObjectLocation;
		public void GoToBed(Characters.Character owner)
		{
			GoToObjectLocation(owner);
		}

		//Called per frame(ish)
		public void Update()
		{
			if (Occupant != null)
			{
				if (sa != null)
				{
					sa.UpdateSleep();
				}
			}
		}
	}
}
