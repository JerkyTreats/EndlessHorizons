using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using Character;

namespace Kitchen{
	public class Kitchen : MonoBehaviour {
		public string goalName; //associated goalName for AI planning purposes
		public List<Meal> meals;
		public int ingredients;
		private GameObject kitchenNode1; //kitchen triggers that will be the location of cooking
		private GameObject kitchenNode2;
		private GameObject kitchenNode3;
		private List<GameObject> kitchenNodes; 
		public List<PendingMeal>pendingMeals; //remove required ingredients, place in a temporary list, if cooking fails, return igredients, etc.

		// Use this for initialization
		void Start () {
			goalName = "ReduceHunger";
			kitchenNodes = new List<GameObject>();
			pendingMeals = new List<PendingMeal>();
			//temporary meal list. Will find a better data implementation later;
			meals = Meal.GetMealsAsList();

			NotificationCenter.DefaultCenter().AddObserver(this, "GetWorldLocations");

            
            //get the 3 circleCollider triggers in in the children
			//assign the children colliders to a reference here.
			foreach (Transform child in transform) //get all the children into a list
			{
				if (child.name.Equals("Kitchen Trigger 1"))
				{
					kitchenNode1=child.gameObject;
					kitchenNodes.Add(kitchenNode1);
				}
				if (child.name.Equals("Kitchen Trigger 2"))
				{
					kitchenNode2=child.gameObject;
					kitchenNodes.Add(kitchenNode2);				
				}
				if (child.name.Equals("Kitchen Trigger 3"))
				{
					kitchenNode3=child.gameObject;
					kitchenNodes.Add(kitchenNode3);
				}
			}
		}

		//Start cooking a meal at the kitchen workstation
		//takes a character controller componenet and the mealName to cook
		public void StartCooking(NPC.NPC control, string mealName)
		{
			for (int i = 0; i<meals.Count; i++) //iterate through the meals
			{
				if (meals [i].mealName == mealName) //if the meal matches
				{
					Debug.Log("I will make a " + mealName);
					PendingMeal newMeal = new PendingMeal(mealName, control);
					pendingMeals.Add(newMeal);
					GoToNode(DetermineKitchenNode(newMeal.GetNextKitchenNode()),control);
					break; //mealName == meal[i], we don't need to loop anymore
				}
			}
		}

		//get the meal in progress by the NPC. 
		PendingMeal GetPendingMealByOwner(Character.Character owner)
		{
			for (int i =0;i<pendingMeals.Count;i++)
			{
				if (pendingMeals[i].owner == owner)
					return pendingMeals[i];
			}
			return null;
		}

		//called from PendingMeal; continues the cooking by going to the next node in the process
		public void ContinueCooking(PendingMeal meal)
		{
			Character.Character owner = meal.owner;
			GoToNode(DetermineKitchenNode(meal.GetNextKitchenNode()),owner);
		}
		
		GameObject DetermineKitchenNode(int nodeOrderNumber)
		{
			GameObject kitchenNode = null; 
			switch (nodeOrderNumber)
			{
				case 1:
					kitchenNode = kitchenNode1;
					break;
				case 2:
					kitchenNode = kitchenNode2;
					break;
				case 3:
					kitchenNode = kitchenNode3;
					break;
			}
			return kitchenNode;
		}
		
		//for the meal to cook, set the location to the the kitchen nodes
		void GoToNode(GameObject destination, Character.Character control)
		{
			Debug.Log("I need to go to the " + destination + " to cook!");
			control.SetDestination(destination.transform.position); //send the character to the kitchen
		}

		//Each update tick should update the PendingMeals for the character. 
		//Only one cook per trigger allowed;
		void Update()
		{
			foreach (GameObject node in kitchenNodes)
			{
				KitchenTrigger trigger = node.GetComponent<KitchenTrigger>();

				//If there is only one cook in the trigger
				if (trigger.charactersInTrigger.Count == 1)
				{
					PendingMeal meal = GetPendingMealByOwner(trigger.charactersInTrigger[0]);
					if (meal != null)
					{
						if (meal.isMealComplete)
						{
							pendingMeals.Remove(meal);
						} else {
							meal.UpdateMealProgress(Time.deltaTime);
						}
					} 
				} else {
					continue;
				}
			}
		}

		void GetWorldLocations(Notification notification)
		{
			NotificationCenter.DefaultCenter().PostNotification(this, "AnnounceWorldLocation");
		}
	}
}