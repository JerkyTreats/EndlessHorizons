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
		private Need OccupantNeed;
		private int OccupantValueDecrementRate;
		private float SleepTime;

		override public void Start()
		{
			ActionType = "sleep";
			base.Start();
		}

		//What happens when the character enters the Bed;
		void OnTriggerEnter2D(Collider2D other)
		{
			if (Occupant != null) //determine if someone is already in bed
			{
				Occupant = other.gameObject.GetComponent<Characters.Character>();
				OccupantNeed = GetOccupantNeed();
				if (OccupantNeed.NeedName == ActionType)
				{
					SleepTime = Time.realtimeSinceStartup;
					OccupantValueDecrementRate = OccupantNeed.ValueDecrementRate;
					OccupantNeed.ValueDecrementRate = 0; //Dont become more sleepy when sleeping
				}

			}
			else
			{
				Debug.Log("Bed is already occupied");
			}
		}

		//Define what happens with the Character leaves the bed;
		void OnTriggerExit2D(Collider2D other)
		{
			OccupantNeed.ValueDecrementRate = OccupantValueDecrementRate; //Return sleepiness decrement to previous
			Occupant = null;
			OccupantNeed = null;
		}

		//Publically accessable method to go to this objects location.
		//Simply moves to a protected GoToObjectLocation;
		public void GoToBed(Characters.Character owner)
		{
			GoToObjectLocation(owner);
		}

		private Need GetOccupantNeed()
		{
			if (Occupant != null)
			{
				Need OccupantNeed = Occupant.Needs.LookUp(ActionType);
				return OccupantNeed;
			}
			Debug.LogError("Bed.GetOccupantNeed => No Occupant");
			return null;
		}

		public void Update()
		{
			if (Occupant != null)
			{
				if (OccupantNeed != null)
				{
					float currentTime = Time.realtimeSinceStartup; //Get the time since startup
					float newTime = currentTime - SleepTime; //calculate how much time has passed since SleepTime last updated
					if (newTime >= 1) //Need.IncreaseCurrentValue only takes int, don't want to update it with zeros
					{
						OccupantNeed.IncreaseCurrentValue(Mathf.RoundToInt(newTime)); //Will be at least >= 1
						SleepTime = currentTime; //Update SleepTime with the current time, avoids exponential sleep growth
					}
				}
			}
		}
	}
}
