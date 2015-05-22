using UnityEngine;
using System.Collections;
using Character;
using NPC.Action;

namespace Kitchen
{
    //Pending meal is a meal that is currently in the process of being "cooked"
    //It has an owner (Character), 
    //if the owner is in the correct kitchen node with the Intent to cook, the PendingMeal will continue the cooking process
    //Once the meal is complete, pendingMeal calls the owners ReduceHunger action to FinishCooking();  
	public class PendingMeal : Meal {
		public float timeInNode;
		public int currentNode;
		public NPC.NPC owner;
		public bool isMealComplete = false;

		public PendingMeal(string mealName, NPC.NPC owner) 
		{
			//Needs to be refactored to have the pending meal defined properly
			//This throws a warning about Meal.GetMeal instantiating badly (new ScriptableObject(?) compile warning)
			//Meal.GetMeal is a temporary method to get end-to-end functionality working, use it knowing its throwaway.
			Meal meal = Meal.GetMeal(mealName);
			this.mealName = mealName;
			this.mealValue=meal.mealValue;
			this.ingredientsNeeded=meal.ingredientsNeeded;
			this.minimumCookTime=meal.minimumCookTime;
			this.kitchenNodeOrder=meal.kitchenNodeOrder;
			currentNode = kitchenNodeOrder [0];

			this.owner = owner;
			

			timeInNode = minimumCookTime;
		}

		//Called during a kitchen update, handles how to use the progress for the cooking.
		public void UpdateMealProgress(float timeAmountToRemove)
		{
			HungerAction rh = (HungerAction)owner.planner.currentAction;
			Debug.Log("Cooking!");
			timeInNode -= timeAmountToRemove;
			if (timeInNode <= 0)
			{
				Debug.Log(kitchenNodeOrder.Count);
				 
				if (kitchenNodeOrder.Count <=1) //1 means this is the last node
				{
					Debug.Log("Finished Cooking!");
					isMealComplete = true;
				} else 
				{
					Debug.Log("Next step!");
					kitchenNodeOrder.RemoveAt(0);
					timeInNode = minimumCookTime;
					currentNode = kitchenNodeOrder[0];
					Debug.Log(rh);
					Debug.Log(rh.kitchen);
					rh.kitchen.ContinueCooking(this);
				}
			}
		}

		//Kitchen triggers that the pendingMeal is done, now turned into a meal
		//ReduceHunger and Kitchen know nothing of each other, pendingMeal ties them together
		//Pending meal just sends the message up to the ReduceHunger Object for proper deconstruction.
		public void FinishCooking()
		{
			HungerAction rh = (HungerAction)owner.planner.currentAction;
			rh.FinishCooking();
		}
	}
}
