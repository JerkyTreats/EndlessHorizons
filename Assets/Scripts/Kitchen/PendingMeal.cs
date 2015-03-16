using UnityEngine;
using System.Collections;
using Character;

namespace Kitchen
{
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
				NPC.ReduceHunger obj = (NPC.ReduceHunger)owner.planner.goalObject; 
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

		public int GetNextKitchenNode()
		{
			return currentNode;
		}
	}
}
