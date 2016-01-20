using UnityEngine;
using System.Collections;
using InteractableObjects;

namespace NPC.Action
{
    //Action Object connecting an NPC with a Kitchen object
    //Planner initiates a HungerAction object, which does the necessary actions to Reduce the NPCs hunger
	public class HungerAction : Action {
        private Kitchen Kitchen;

		public HungerAction(NPC owner, Kitchen kitchen) : base(owner, "hunger")
		{
			Kitchen = kitchen;
			Debug.Log("I am hungry enough to eat!"); //Turn debug.log into a popup text.
			if (!CheckInventory()) //Eat any food in inventory, else start cooking; 
			{
				StartCooking();
			}
		}

        //Check the players inventory for a meal; 
        //Eat the meal; returns true if eating was complete;
		public bool CheckInventory()
		{
			if (Owner.inventory.HasObjectNameInInventory("meal"))
			{
				Meal toEat = (Meal)Owner.inventory.FetchObject("meal");
				if (toEat != null)
				{
					Owner.inventory.RemoveAmountFromInventory("meal", 1);
					Need.IncreaseCurrentValue(toEat.mealValue);
					toEat = null;
					return true;
				}
				else
				{
					Debug.Log("Meal toEat is null");
				}
			}
			return false;
		}

        //Find a kitchen, start cooking at that kitchen;
		public void StartCooking()
		{
			Debug.Log("Start Cooking");
			Kitchen.StartCooking(Owner, "mealValueal"); //Start cooking

		}

		public void FinishCooking()
		{
			Debug.Log("Finished Cooking");
			Owner.inventory.Add("meal", 1, Meal.GetMeal("meal"));
			CheckInventory();
		}
	}
}