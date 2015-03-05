using UnityEngine;
using System.Collections;
using Kitchen;

namespace Character
{
	public class ReduceHunger : MonoBehaviour {
		public Kitchen.Controller kitchen;
		Character.Controller owner;

		public void Init(Character.Controller owner)
		{
			Debug.Log("I am hungry enough to eat!");
			this.owner = owner;
			if (!CheckInventory())
			{
				StartCooking();
			}
		}


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

		public void StartCooking()
		{
			foreach (Component comp in owner.planner.worldObjects)
			{
				if (comp is Kitchen.Controller)
				{
					Debug.Log("I need to cook!");
					kitchen = (Kitchen.Controller)comp;
					kitchen.StartCooking(owner, "meal");
					break;
				}
			}
		}

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
				NotificationCenter.DefaultCenter().PostNotification(this, "GoalComplete");
			}
		}
	}
}