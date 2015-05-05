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
        public Action.Action currentAction;
		public string characterType; //characters type, limits the actions available to this character
		public List<Component> worldObjects;
		private Goal idle;


		// Use this for initialization
		void Start () {
			controller = gameObject.GetComponent<NPC>();
			characterType = controller.characterType;
			goals = new List<Goal>();
			worldObjects = new List<Component>();

			//We're adding Idle behaviour here as the default NPC behaviour, this is ripe for improvement
			idle = new Goal("idle",5);
            goals.Add(idle); 
			currentGoal = idle;

            //Constantly evaluate the NPC goal to ensure NPC is doing the most important thing
            InvokeRepeating("CalculateCurrentStatus",0,0);

			//Sign up for world announcements (via the Notification Oberver handler)
			NotificationCenter.DefaultCenter().AddObserver(this, "AnnounceWorldLocation"); 
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
		}

        //Overloaded UpdateStatus with no newGoal, recalculates top action
        public void CalculateCurrentStatus()
        {
            Goal highestGoal = idle;
            //Determine the goal with the highest goalWeight
            for (int i = 0; i < goals.Count; i++)
            {
                if (highestGoal.goalWeight > goals[i].goalWeight)
                {
                    highestGoal = goals[i];
                }
            }
            //Do the goal with the highest goalWeight if not already doing it;
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
					currentAction = new Action.ReduceHunger(controller);
					break;
				case "Idle":
					Debug.Log("\tNothing to do, I will Idle");
					//would probably ping mechanim to idle at this point in the future
					break;
			}	
		}
	}
}