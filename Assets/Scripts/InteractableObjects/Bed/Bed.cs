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
			Occupant = other.gameObject.GetComponent<Characters.Character>();
			OccupantNeed =  Occupant.Needs.LookUp(ActionType);
			if (OccupantNeed.NeedName == ActionType)
			{
				SleepTime = Time.realtimeSinceStartup;
				OccupantValueDecrementRate = OccupantNeed.ValueDecrementRate;
				OccupantNeed.ValueDecrementRate = 0; //Dont become more sleepy when sleeping
			}
			else
			{
				Debug.Log("Bed.OnTriggerEnter => Occupant Current Action differs from Beds");
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

		public void Update()
		{
			if (Occupant != null)
			{
				Debug.Log(ActionType + " " + OccupantNeed.NeedName);
				if (OccupantNeed.NeedName.Equals(ActionType) || OccupantNeed == null)
				{
					float currentTime = Time.realtimeSinceStartup; //Get the time since startup
					float newTime = currentTime - SleepTime; //calculate how much time has passed since SleepTime last updated
					if (newTime >= 1) //Need.IncreaseCurrentValue only takes int, don't want to update it with zeros
					{
						OccupantNeed.IncreaseCurrentValue(Mathf.RoundToInt(newTime)); //Will be at least >= 1
						SleepTime = currentTime; //Update SleepTime with the current time, avoids exponential sleep growth
						Debug.Log(OccupantNeed.CurrentValue);
					}
				}
				else
				{
					Debug.LogError("Bed.Update => OccupantNeed does not match Bed.ActionType");
				}
			}
		}
	}
}
