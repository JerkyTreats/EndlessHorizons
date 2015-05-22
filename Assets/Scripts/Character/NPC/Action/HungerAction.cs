using UnityEngine;
using System.Collections;
using Kitchen;

namespace NPC.Action
{
    //Action Object connecting an NPC with a Kitchen object
    //Planner initiates a HungerAction object, which does the necessary actions to Reduce the NPCs hunger
	public class HungerAction : Action {
		public Kitchen.Kitchen kitchen;
        Need.NPCNeed hunger; 

        
		public HungerAction(NPC owner) : base(owner, "hunger")
		{
			Debug.Log("I am hungry enough to eat!"); //Turn debug.log into a popup text.
            hunger = (Need.NPCNeed)owner.needs.LookUp("hunger"); //find the data class hunger for this NPC
			if (!CheckInventory()) //Eat any food in inventory, else start cooking; 
			{
				StartCooking();
			}
		}

        //Check the players inventory for a meal; 
        //Eat the meal; returns true if eating was complete;
		public bool CheckInventory()
		{
			Debug.Log(owner);
			Debug.Log(owner.inventory);
			if (owner.inventory.HasObjectNameInInventory("meal"))
			{
				Debug.Log("I have food. I will eat!");
				Meal toEat = (Meal)owner.inventory.FetchObject("meal");
				Debug.Log("toEat: " + toEat.mealName + " " + toEat.mealValue);
				if (toEat != null)
				{
					owner.inventory.RemoveAmountFromInventory("meal", 1);
					hunger.IncreaseCurrentValue(toEat.mealValue);
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
			if (owner.planner.worldObjects.Count == 0) 
			{
				Debug.Log ("NPC cannot find kitchen. Annoucing kitchen objects now");
				NotificationCenter.DefaultCenter().PostNotification(owner.planner, "GetWorldLocations");
			}
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

		public void FinishCooking()
		{
			Debug.Log("rh FinishedCooking");
			owner.inventory.Add("meal", 1, Meal.GetMeal("meal"));
			owner.planner.FinishGoal();
			CheckInventory();
		}
	}
}