using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using Characters;

namespace InteractableObjects.Kitchen{
	public class Kitchen : InteractableObject {
		public List<Meal> Meals;
		public int Ingredients;
		private GameObject KitchenNode1; //kitchen triggers that will be the location of cooking
		private GameObject KitchenNode2;
		private GameObject KitchenNode3;
		private List<GameObject> KitchenNodes; 
		public List<PendingMeal>PendingMeals; //remove required ingredients, place in a temporary list, if cooking fails, return igredients, etc.

		// Use this for initialization
		override public void Start()
		{
			base.Start();
			ActionType = "hunger";
			KitchenNodes = new List<GameObject>();
			PendingMeals = new List<PendingMeal>();
			//temporary meal list. Will find a better data implementation later;
			Meals = Meal.GetMealsAsList();

            //get the 3 circleCollider triggers in in the children
			//assign the children colliders to a reference here.
			foreach (Transform child in transform) //get all the children into a list
			{
				if (child.name.Equals("Kitchen Trigger 1"))
				{
					KitchenNode1=child.gameObject;
					KitchenNodes.Add(KitchenNode1);
				}
				if (child.name.Equals("Kitchen Trigger 2"))
				{
					KitchenNode2=child.gameObject;
					KitchenNodes.Add(KitchenNode2);				
				}
				if (child.name.Equals("Kitchen Trigger 3"))
				{
					KitchenNode3=child.gameObject;
					KitchenNodes.Add(KitchenNode3);
				}
			}
		}

		//Start cooking a meal at the kitchen workstation
		//takes a character controller componenet and the mealName to cook
		public void StartCooking(NPC.NPC control, string mealName)
		{
			for (int i = 0; i<Meals.Count; i++) //iterate through the meals
			{
				if (Meals [i].mealName == mealName) //if the meal matches
				{
					Debug.Log("I will make a " + mealName);
					PendingMeal newMeal = new PendingMeal(mealName, control);
					PendingMeals.Add(newMeal);
					GoToObjectLocation(DetermineKitchenNode(newMeal.currentNode),control);
					break; //mealName == meal[i], we don't need to loop anymore
				}
			}
		}

		//get the meal in progress by the NPC. 
		PendingMeal GetPendingMealByOwner(Characters.Character owner)
		{
			for (int i =0;i<PendingMeals.Count;i++)
			{
				if (PendingMeals[i].owner == owner)
					return PendingMeals[i];
			}
			return null;
		}

		//called from PendingMeal; continues the cooking by going to the next node in the process
		public void ContinueCooking(PendingMeal meal)
		{
			Characters.Character owner = meal.owner;
			GoToObjectLocation(DetermineKitchenNode(meal.currentNode),owner);
		}
		
		GameObject DetermineKitchenNode(int nodeOrderNumber)
		{
			GameObject kitchenNode = null; 
			switch (nodeOrderNumber)
			{
				case 1:
					kitchenNode = KitchenNode1;
					break;
				case 2:
					kitchenNode = KitchenNode2;
					break;
				case 3:
					kitchenNode = KitchenNode3;
					break;
			}
			return kitchenNode;
		}

		//Each update tick should update the PendingMeals for the character. 
		//Only one cook per trigger allowed;
		void Update()
		{
			foreach (GameObject node in KitchenNodes)
			{
				KitchenTrigger trigger = node.GetComponent<KitchenTrigger>();

				//If there is only one cook in the trigger
				if (trigger.CharactersInTrigger.Count == 1)
				{
					PendingMeal meal = GetPendingMealByOwner(trigger.CharactersInTrigger[0]);
					if (meal != null)
					{
						if (meal.isMealComplete)
						{
							PendingMeals.Remove(meal);
							meal.FinishCooking();
						} else {
							meal.UpdateMealProgress(Time.deltaTime);
						}
					} 
				} 
			}
		}
	}
}