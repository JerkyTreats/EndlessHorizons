using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kitchen;

namespace Character
{
	//REFACTOR: Add an object[][] that allows [[name,amount,objectref]]
	//If possible, map the dictionary<name,index> to the objarr name@index
	//In theory, dictionary allows for fast lookup, object array allows for information storage;
	public class Inventory : MonoBehaviour {
		public Dictionary<string,int> inventory;

		// Use this for initialization
		void Start () {
			inventory = new Dictionary<string,int>();
		}

		//Add an object/amount to the characters inventory
		//increases amount if key already exists
		public void Add(string obj, int amount)
		{

			if (inventory.ContainsKey(obj))
			{
				amount += inventory [obj];
				inventory.Remove(obj);
			}
			Debug.Log(obj + ", " + amount);
			inventory.Add(obj,amount);
			Debug.Log(inventory [obj]);
		}

		//Get the amount of an object the character has in their inventory
		public int GetObjectAmount(string obj)
		{
			if (inventory.ContainsKey(obj))
			{
				return inventory [obj];
			} else
			{
				return 0;
			}
		}

		//Remove an amount of an object from the characters inventory
		//Returns -1 if object does not exist or does not have enough of the amount
		//Will not remove the amount if the amount is less than zero
		public int RemoveAmountFromObject(string obj, int amount)
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

		public bool HasObjectNameInInventory(string toFind)		
		{
			Debug.Log("GetFoodFromInventory");
			if (GetObjectAmount(toFind) == 0)
			{
				return false;
			} else
			{
				RemoveAmountFromObject(toFind,1);
				return true;
			}
		}
	}
}