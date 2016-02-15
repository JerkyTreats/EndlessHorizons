using System.Collections.Generic;
using Needs;
using UnityEngine;
using InteractableObjects;

namespace NPC.Action
{
	//Responsible for the act of sleeping. 
	//Finding, going to, and updating the Need related to Sleep.
	//Ties Bed InteractableObject to NPC.
	class Sleep : MonoBehaviour
	{
        Need Need;
		float SleepTime;
		int OriginalDecrementRate; 
		bool IsInBed;
		Bed Bed;


		public void Init(Bed bed, Need Need)
		{
			Bed = bed;
            NPC owner = gameObject.GetComponent<NPC>();
			owner.SetDestination(bed.GetLocation());
            this.Need = Need;
		}

		public void StartSleep()
		{
			SleepTime = Time.realtimeSinceStartup;

			//Dont become more sleepy when sleeping
			OriginalDecrementRate = Need.ValueDecrementRate;
			Need.ValueDecrementRate = 0; 
		}

		//Essentially called every frame when conditions in IO.Bed have been met.
		public void UpdateSleep()
		{
			if (Need.CurrentValue <= 75)
			{
				float currentTime = Time.realtimeSinceStartup; //Get the time since startup
				float newTime = currentTime - SleepTime; //calculate how much time has passed since SleepTime last updated
				if (newTime >= 1) //Need.IncreaseCurrentValue only takes int, don't want to update it with zeros
				{
					Need.IncreaseCurrentValue(Mathf.RoundToInt(newTime)); //Will be at least >= 1
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
			Need.ValueDecrementRate = OriginalDecrementRate; //Return sleepiness decrement to previous
			// Owner.planner.FinishGoal();
			// WakeUp()
		}
	}
}
