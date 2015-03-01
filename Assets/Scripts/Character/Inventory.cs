using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kitchen;

namespace Character
{
	public class Inventory : MonoBehaviour {
		public Dictionary<Object,int> inventory;

		// Use this for initialization
		void Start () {
			inventory = new Dictionary<Object,int>();
		}

		//Add an object/amount to the characters inventory
		//increases amount if key already exists
		public void Add(Object obj, int amount)
		{
			if (inventory.ContainsKey(obj))
			{
				amount += inventory [obj];
				inventory.Remove(obj);
			}
			inventory.Add(obj,amount);
		}

		//Get the amount of an object the character has in their inventory
		public int GetObjectAmount(Object obj)
		{
			return inventory [obj];
		}

		//Remove an amount of an object from the characters inventory
		//Returns -1 if object does not exist or does not have enough of the amount
		//Will not remove the amount if the amount is less than zero
		public int RemoveAmountFromObject(Object obj, int amount)
		{
			int newAmount = inventory [obj] - amount;
			if (newAmount > 0)
			{
				inventory.Remove(obj);
				inventory.Add(obj, newAmount);
			} else if (newAmount == 0)
			{
				inventory.Remove(obj);
			} else if (newAmount < 0)
			{
				return -1;
			}
			return newAmount;
		}

		public Meal GetFoodFromInventory(string mealName)		
		{
			Meal meal = Meal.GetMeal(mealName);
			if (GetObjectAmount(meal) == 0)
			{
				return null;
			} else
			{
				RemoveAmountFromObject(meal,1);
				return meal;
			}
		}
	}
}