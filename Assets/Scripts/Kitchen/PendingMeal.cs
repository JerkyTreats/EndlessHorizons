using UnityEngine;
using System.Collections;
using Character;
using NPC.Action;

namespace Kitchen
{
    //Pending meal is a meal that is currently in the process of being "cooked"
    //It has an owner (Character), 
    //if the owner is in the correct kitchen node with the Intent to cook, the PendingMeal will continue the cooking process
    //Once the meal is complete, the PendingMeal is destroyed and a new Meal is added to Character.Inventory  
	public class PendingMeal : Meal {
		public float timeInNode;
		public int currentNode;
		public NPC.NPC owner;
		public bool isMealComplete = false;

		public PendingMeal(string mealName, NPC.NPC owner) 
		{
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

		public void UpdateMealProgress(float timeAmountToRemove)
		{
			Debug.Log("Cooking!");
			timeInNode -= timeAmountToRemove;
			if (timeInNode <= 0)
			{
				Debug.Log(kitchenNodeOrder.Count);
				ReduceHunger obj = (ReduceHunger)owner.planner.currentAction; 
				if (kitchenNodeOrder.Count <=1) //1 means this is the last node
				{
					Debug.Log("Finished Cooking!");
					owner.inventory.Add(mealName,1);
					isMealComplete = true;
				} else 
				{
					Debug.Log("Next step!");
					kitchenNodeOrder.RemoveAt(0);
					timeInNode = minimumCookTime;
					currentNode = kitchenNodeOrder[0];
					obj.kitchen.ContinueCooking(this);
				}
			}
		}
    }
}
