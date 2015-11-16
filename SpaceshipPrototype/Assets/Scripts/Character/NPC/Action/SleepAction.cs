using System.Collections.Generic;
using InteractableObjects.Bed;
using Needs;
using UnityEngine;

namespace NPC.Action
{
	//Responsible for the act of sleeping. 
	//Finding, going to, and updating the Need related to Sleep.
	//Ties Bed InteractableObject to NPC.
	class SleepAction : Action
	{
		private float SleepTime;
		private Need OwnerNeed;
		private int OccupantValueDecrementRate;

		//Get the need of the NPC, determine which object to go to, init the process to go to sleep;
		public SleepAction(NPC owner)
			: base(owner, "sleep")
		{
			Debug.Log("I need to go to sleep!");

			OwnerNeed = Owner.Needs.LookUp(ActionType);

			DetermineInteractableObject();
			Bed bed = (Bed)IO;
			bed.GoToBed(owner);
		}

		public void StartSleep()
		{
			SleepTime = Time.realtimeSinceStartup;
			OccupantValueDecrementRate = OwnerNeed.ValueDecrementRate;
			OwnerNeed.ValueDecrementRate = 0; //Dont become more sleepy when sleeping
		}

		//Essentially called every frame when conditions in IO.Bed have been met.
		public void UpdateSleep()
		{
			if (OwnerNeed.CurrentValue <= 75)
			{
				float currentTime = Time.realtimeSinceStartup; //Get the time since startup
				float newTime = currentTime - SleepTime; //calculate how much time has passed since SleepTime last updated
				if (newTime >= 1) //Need.IncreaseCurrentValue only takes int, don't want to update it with zeros
				{
					OwnerNeed.IncreaseCurrentValue(Mathf.RoundToInt(newTime)); //Will be at least >= 1
					SleepTime = currentTime; //Update SleepTime with the current time, avoids exponential sleep growth
				}
			}
			else
			{
				FinishSleep();
			}
		}

		public void FinishSleep()
		{
			OwnerNeed.ValueDecrementRate = OccupantValueDecrementRate; //Return sleepiness decrement to previous
			Owner.planner.FinishGoal();
		}
	}
}
