using UnityEngine;
using System.Collections;
using InteractableObjects.Kitchen;

namespace NPC.Action
{
    //Action Object connecting an NPC with a Kitchen object
    //Planner initiates a HungerAction object, which does the necessary actions to Reduce the NPCs hunger
	public class HungerAction : Action {
        
		public HungerAction(NPC owner) : base(owner, "hunger")
		{
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
			Debug.Log(Owner);
			Debug.Log(Owner.inventory);
			if (Owner.inventory.HasObjectNameInInventory("meal"))
			{
				Debug.Log("I have food. I will eat!");
				Meal toEat = (Meal)Owner.inventory.FetchObject("meal");
				Debug.Log("toEat: " + toEat.mealName + " " + toEat.mealValue);
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
			DetermineInteractableObject(); //Base class method to determine what the kitchen is 
			Kitchen kitchen = (Kitchen)IO; //Cast the IO into its subclass
			Debug.Log(kitchen);
			kitchen.StartCooking(Owner, "meal"); //Start cooking

		}

		public void FinishCooking()
		{
			Debug.Log("Finished Cooking");
			Owner.inventory.Add("meal", 1, Meal.GetMeal("meal"));
			Owner.planner.FinishGoal();
			CheckInventory();
		}
	}
}