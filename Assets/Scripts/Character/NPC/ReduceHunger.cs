using UnityEngine;
using System.Collections;
using Kitchen;

namespace NPC
{
    //Action Object connecting an NPC with a Kitchen object
    //Planner initiates a ReduceHunger object, which does the necessary actions to Reduce the NPCs hunger
	public class ReduceHunger : ScriptableObject {
		public Kitchen.Kitchen kitchen;
		NPC owner;


        //Set variables as constructors are weird for MonoBehaviours
		public void Init(NPC owner)
		{
			Debug.Log("I am hungry enough to eat!");
			this.owner = owner;
			if (!CheckInventory())
			{
				StartCooking();
			}
		}

        //Check the players inventory for a meal; 
        //Eat the meal; returns true if eating was complete;
		public bool CheckInventory()
		{
			if (owner.inventory.HasObjectNameInInventory("meal"))
			{
				Debug.Log("I have food. I will eat!");
				Meal toEat = Meal.GetMeal("meal");
				owner.hunger.Eat(toEat.mealValue);
				return true;
			}
			return false;
		}

        //Find a kitchen, start cooking at that kitchen;
		public void StartCooking()
		{
			Debug.Log("Start Cooking");
			Debug.Log(owner.planner.worldObjects.Count);
			foreach (Component comp in owner.planner.worldObjects)
			{
				Debug.Log(comp);
				if (comp is Kitchen.Kitchen)
				{
					Debug.Log("I need to cook!");
					kitchen = (Kitchen.Kitchen)comp;
					kitchen.StartCooking(owner, "meal");
					break;
				}
			}
		}

        //Remove the pending meal, add a True meal;
		public void FinishCooking(){
			if (CheckInventory())
			{
				foreach (PendingMeal toRemove in kitchen.pendingMeals)
				{
					if (toRemove.owner == owner)
					{
						kitchen.pendingMeals.Remove(toRemove);
						break;
					}
				}
				owner.planner.GoalComplete();
			}
		}
	}
}