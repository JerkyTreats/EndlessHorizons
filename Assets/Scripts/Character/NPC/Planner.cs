using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InteractableObjects;

namespace NPC
{
	//Determines what the character should do based on their needs 
	public class Planner : MonoBehaviour {
		private NPC Controller; 
		private List<Goal> Goals; //goal name + weight
		public Goal CurrentGoal; //characters current goal
        public Action.Action CurrentAction;
		public string CharacterType; //characters type, limits the actions available to this character
		public List<InteractableObject> WorldObjects;
		private Goal Idle;


		// Use this for initialization
		void Start () {
			Controller = gameObject.GetComponent<NPC>();
			CharacterType = Controller.characterType;
			Goals = new List<Goal>();
			WorldObjects = new List<InteractableObject>();

			//We're adding Idle behaviour here as the default NPC behaviour, this is ripe for improvement
			Idle = new Goal("idle",5);
            Goals.Add(Idle); 
			CurrentGoal = Idle;

            //Constantly evaluate the NPC goal to ensure NPC is doing the most important thing
            InvokeRepeating("CalculateCurrentStatus",0,1);

			//Sign up for InteractableObjects announcements. See method AnnounceInteractableObjects();
			NotificationCenter.DefaultCenter().AddObserver(this, "AnnounceInteractableObjects"); 

		}

		//When called, all InteractableObjects announce themselves
		//This allows the planner to know what objects to interact with to acheive goals
		//ie. Kitchen announces itself, Planner will know to go to Kitchen to do a HungerAction;
		void AnnounceInteractableObjects(Notification notification)
		{
			Debug.Log("IO Notification recieved by planner");
			WorldObjects.Add((InteractableObject)notification.sender);
		}
		
		//Update/Add an entry in the Goal list; determine if the current Intent has changed
		//If it does, start doing the actions;
		public void UpdateStatus(Goal newGoal)
		{
			bool goalExists = false;
			//Debug.Log("UpdateStatus recieved: " + newGoal.goalName + " " + newGoal.goalWeight);
			//Debug.Log("Count: " + goals.Count);
			//Check the list if the goal to update exists, replace;
			for(int i = 0; i<Goals.Count; i++)
			{
				if (newGoal.goalName.Equals(Goals[i].goalName))
				{
					//Debug.Log("Goal exists");
					Goals[i] = newGoal;
					goalExists = true;
				}	
			}

			//Add the goal to the list of goals if it does not exist, 
			if (!goalExists)
			{
				Goals.Add(newGoal);
				//Debug.Log("New Goal Count " + goals.Count);

			}
		}

        //Should be invokeRepeating by Start, constantly determining the most important thing to do
        public void CalculateCurrentStatus()
		{
			if (CurrentGoal == null)
			{
				CurrentGoal = Idle;
			}

			Goal highestGoal = CurrentGoal;

			//Debug.Log("Current highest goal: " + currentGoal.goalName + " " + currentGoal.goalWeight);
			//Determine the goal with the highest goalWeight
			for (int i = 0; i < Goals.Count; i++)
			{
				if (highestGoal.goalWeight < Goals[i].goalWeight)
				{
					highestGoal = Goals[i];
					//Debug.Log("New highest goal: " + highestGoal.goalName + " " + highestGoal.goalWeight);
				}
			}

			//Do the goal with the highest goalWeight if not already doing it;
			if (!CurrentGoal.goalName.Equals(highestGoal.goalName))
			{
				CurrentGoal = highestGoal;
				DoAction();
			}
		}

		//Armed with the current Intent, find a list of actions available to satisfy the intent
		//Do all actions by cheapest action cost until the intended status is changed
		void DoAction()
		{
			Debug.Log("Do Action: " + CurrentGoal.goalName);
			CurrentAction = Action.ActionFactory.GetAction(CurrentGoal.goalName, Controller);
		}

		//Called by an Action once a goal is complete to deref the current Action and Goal
		//This solves the case if an action is completed but is still the most important action
		public void FinishGoal()
		{
			CurrentAction = null;
			CurrentGoal = null;
		}

		public InteractableObject GetWorldObject(string ActionType)
		{
			foreach (InteractableObject io in WorldObjects)
			{
				if (io.ActionType == ActionType)
				{
					return io;
				}
			}
			Debug.LogError("Planner.GetWorldObject() error: " + ActionType + " does not exist");
			return null;
		}
	}
}