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
		public Inventory inventory;
		public Goal currentGoal; //characters current goal
		public string characterType; //characters type, limits the actions available to this character
		private List<GameObject> worldObjects;


		// Use this for initialization
		void Start () {
			characterController = gameObject.GetComponent<Character.Controller>();
			characterType = characterController.characterType;
			inventory = characterController.inventory;
			goals = new List<Goal>();
			worldObjects = new List<GameObject>();

			goals.Add(new Goal("Idle",5)); //Default goal
			UpdateStatus(); //call the update status so that the initial behaviour is to Idle;

			NotificationCenter.DefaultCenter().AddObserver(this, "AnnounceWorldLocation");
			NotificationCenter.DefaultCenter().AddObserver(this, "UpdateStatus"); //receive "update status" notifications;
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
				for(int i = 0; i<=goals.Count; i++)
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
			switch (currentGoal.goalName)
			{
				case "ReduceHunger":
					Debug.Log("I am hungry enough to eat!");
					Meal meal = inventory.GetFoodFromInventory();
					if (meal != null)
					{
						Hunger.Eat(meal.mealValue);
						Destroy(meal);
					} else
					{
						foreach(GameObject obj in worldObjects)
						{
							if (obj is Kitchen)
							{
								obj = (Kitchen)obj;
								Kitchen test = obj;
							}
						}
					}
					break;
			}	
		}
	}


	//goal object to create, makes for easier (conceptually) goalWeight sorting;
	public class Goal : MonoBehaviour
	{
		public string goalName;
		public int goalWeight;

		public Goal(string name, int weight)
		{
			goalName = name;
			goalWeight = weight;
		}
	}
}