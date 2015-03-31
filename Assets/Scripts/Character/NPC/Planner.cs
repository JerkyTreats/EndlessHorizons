using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kitchen;

namespace NPC
{
	//Determines what the character should do based on their needs 
	public class Planner : MonoBehaviour {
		private NPC controller; 
		private List<Goal> goals; //goal name + weight
		public Goal currentGoal; //characters current goal
		public ScriptableObject goalObject;
		public string characterType; //characters type, limits the actions available to this character
		public List<Component> worldObjects;
		private Goal idle;


		// Use this for initialization
		void Start () {
			controller = gameObject.GetComponent<NPC>();
			characterType = controller.characterType;
			goals = new List<Goal>();
			worldObjects = new List<Component>();

			idle = ScriptableObject.CreateInstance<Goal>();
			idle.Init("Idle", 5);
			currentGoal = idle; //start goal list with at least one goal 
			UpdateStatus(idle); // tell NPC that the idle goal is their current

            //These need to be refactored to be contained in the NPC. 
            //Reducing functionality of the Observer pattern to only deal with unrelated objects
            //Else increase observing methods to validate incoming message with high degree of confidence; 
			NotificationCenter.DefaultCenter().AddObserver(this, "AnnounceWorldLocation");
			NotificationCenter.DefaultCenter().PostNotification(this, "GetWorldLocations");
            
		}

		//Add a world object that the character can interact with;
		//This object should have a Goal or goalName associated with it or bad things WILL happen;
		void AnnounceWorldLocation(Notification notification)
		{
			worldObjects.Add(notification.sender);
		}
		
		//Update/Add an entry in the Goal list; determine if the current Intent has changed
		//If it does, start doing the actions;
		public void UpdateStatus(Goal newGoal)
		{
			bool goalExists = false;
			//Debug.Log("UpdateStatus recieved: " + newGoal.goalName + " " + newGoal.goalWeight); 

			//Check the list if the goal to update exists, replace;
			//Update the currentGoal if the newGoal has the highest weighting;
			for(int i = 0; i<goals.Count; i++)
			{
				if (newGoal.goalName.Equals(goals[i].goalName))
				{
					goals[i] = newGoal;
					goalExists = true;
				}	
			}

			//Add the goal to the list of goals if it does not exist, 
			if (!goalExists)
			{
				goals.Add(newGoal);
			}

			//update the current goal if necessary;
			if (newGoal.goalWeight > currentGoal.goalWeight)
			{
				//Debug.Log("CurrentGoal updated");
				currentGoal = newGoal;
				DoAction(); //Get the character to actions to satisfy the goal 
			}
		}

        //Overloaded UpdateStatus with no newGoal, recalculates top action
        public void UpdateStatus()
        {
            Goal highestGoal = idle;
            //Get highest goal to do
            for (int i = 0; i < goals.Count; i++)
            {
                if (highestGoal.goalWeight > goals[i].goalWeight)
                {
                    highestGoal = goals[i];
                }
            }

            if (!currentGoal.goalName.Equals(highestGoal.goalName))
            {
                DoAction();
            }
        }

		//Armed with the current Intent, find a list of actions available to satisfy the intent
		//Do all actions by cheapest action cost until the intended status is changed
		void DoAction()
		{
			switch (currentGoal.goalName)
			{
				case "ReduceHunger":
					ReduceHunger rh = ScriptableObject.CreateInstance<ReduceHunger>();
					goalObject = rh;
					rh.Init(controller);
					break;
				case "Idle":
					Debug.Log("\tNothing to do, I will Idle");
					//would probably ping mechanim to idle at this point in the future
					break;
			}	
		}

        //Complete a goal; a previous UpdateStatus should have already be run. 
        //Honestly not sure why this is here;
		public void GoalComplete()
		{
			UpdateStatus();
		}
	}
}