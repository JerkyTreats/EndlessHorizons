using UnityEngine;
using System.Collections;
using InteractableObjects;

namespace NPC.Action
{
    //Action Object connecting an NPC with a Kitchen object
    //Planner initiates a HungerAction object, which does the necessary actions to Reduce the NPCs hunger
	public class HungerAction : Action {
        private Kitchen Kitchen;
        private bool ActionCompleted = false;
        private string Step;

		public HungerAction(NPC owner, Kitchen kitchen) : base(owner, "hunger")
		{
			Kitchen = kitchen;
			Debug.Log("I am hungry enough to eat!"); //Turn debug.log into a popup text.
			Step = "eat";
			while (!ActionCompleted)
			{
				DetermineAction();
			}
		}

		void DetermineAction()
		{
			switch (Step)
			{
				case "eat" :
				{
					EatMeal();
					break;
				}
				case "cook" :
				{
					StartCooking();
					break;
				}
			}
			Debug.Log("HungerAction.DetermineAction: [" + Step + "] is not a valid step");
		}

        //Check the players inventory for a meal; 
        //Eat the meal; returns true if eating was complete;
		Meal GetMealFromInventory()
		{
			return (Meal)Owner.Inventory.PopItem("meal");
		}

		void EatMeal()
		{
			Meal toEat = GetMealFromInventory();
			if (toEat != null)
			{
				Need.IncreaseCurrentValue(toEat.NeedValue);
				FinishAction();
			}
			else 
			{
				Step = "cook";
			}
		}

        //Find a kitchen, start cooking at that kitchen;
		public void StartCooking()
		{
			Debug.Log("Start Cooking");
			// Owner.SetDestination(Kitchen.)
			Kitchen.StartCooking(Owner, "mealValue"); //Start cooking

		}

		public void FinishCooking()
		{
			Debug.Log("Finished Cooking");
			Owner.Inventory.Add("meal", 1, Meal.GetMeal("meal"));
			Step = "eat";
		}

		void FinishAction()
		{
			ActionCompleted = true;
			Owner.Planner.CurrentAction = null; //Leaves this object to wither and die?
		}
	}
}