using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kitchen;

namespace Character
{
	//intent: to determine what the character should do based on their needs 
	public class Planner : MonoBehaviour {
		//Controller component with references to all other components
		//Used to reduce number of GetComponent calls.
		private Character.Controller characterController; 
		private List<Goal> goals; //goal name + weight
		public Goal currentGoal; //characters current goal
		public GameObject goalObject; //goal actualized into an object;
		public string characterType; //characters type, limits the actions available to this character
		public List<Component> worldObjects;
		private Goal idle;


		// Use this for initialization
		void Start () {
			characterController = gameObject.GetComponent<Character.Controller>();
			characterType = characterController.characterType;
			goals = new List<Goal>();
			goalObject = new GameObject();
			worldObjects = new List<Component>();
			idle = ScriptableObject.CreateInstance<Goal>();
			idle.Init("Idle", 5);

			NotificationCenter.DefaultCenter().AddObserver(this, "AnnounceWorldLocation");
			NotificationCenter.DefaultCenter().AddObserver(this, "UpdateStatus"); //receive "update status" notifications;
			NotificationCenter.DefaultCenter().AddObserver(this, "GoalComplete");

			//this chincey shit is not optimal: send a notification to itself to inject a default "Idle" state;
			currentGoal = idle;
			NotificationCenter.DefaultCenter().PostNotification(this,"UpdateStatus",idle); 
		}

		//Add a world object that the character can interact with;
		//This object should have a Goal or goalName associated with it or bad things WILL happen;
		void AnnounceWorldLocation(Notification notification)
		{
			worldObjects.Add(notification.sender);
		}
		
		//Update/Add an entry in the Goal list; determine if the current Intent has changed
		//If it does, start doing the actions;
		void UpdateStatus(Notification notification)
		{
			if (notification.data is Goal)
			{
				bool goalExists = false;
				Goal newGoal = (Goal)notification.data;
				Debug.Log("UpdateStatus recieved: " + notification.sender + " " + newGoal.goalName + " " + newGoal.goalWeight); 

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
			} else
			{
				Debug.LogError(notification.sender + " sent UpdateStatus notification with incorrect data type (requires Goal object)" );
			}
		}

		//Armed with the current Intent, find a list of actions available to satisfy the intent
		//Do all actions by cheapest action cost until the intended status is changed
		void DoAction()
		{
			//Debug.Log("I will do an Action:");
			switch (currentGoal.goalName)
			{
				case "ReduceHunger":
					goalObject.AddComponent<ReduceHunger>();
					ReduceHunger rh = goalObject.GetComponent<ReduceHunger>();
					rh.Init(characterController);
					break;
				case "Idle":
					Debug.Log("\tNothing to do, I will Idle");
					//do nothing ye lazy @#$%
					break;
			}	
		}

		void GoalComplete(Notification notification)
		{
			Notification note = new Notification(this, "UpdateStatus", idle); 
			UpdateStatus(note);
		}
	}

	//goal object to create, makes for easier (conceptually) goalWeight sorting;
	public class Goal : ScriptableObject
	{
		public string goalName;
		public int goalWeight;

		public void Init(string name, int weight)
		{
			goalName = name;
			goalWeight = weight;
		}
	}
}