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
		public List<InventoryItem> inventory;

		// Use this for initialization
		void Start () {
			inventory = new List<InventoryItem>();
		}

		//Add an object/amount to the characters inventory
		//increases amount if key already exists
		public void Add(string name, int amount, object obj)
		{
			for (int i=0; i<inventory.Count; i++)
			{
				if (inventory [i].name == name)
				{
					inventory[i].amount+=amount;
					return;
				}
			}
			Debug.Log(name + ", " + amount + ", " + obj);
			inventory.Add(new InventoryItem(name, amount, obj));
		}

		//Add an object name/amount to the characters inventory
		//Allow for inventory name without an object reference
		public void Add(string name, int amount)
		{
			for (int i=0; i<inventory.Count; i++)
			{
				if (inventory [i].name == name)
				{
					inventory[i].amount+=amount;
					return;
				}
			}
			Debug.Log(name + ", " + amount);
			inventory.Add(new InventoryItem(name, amount));
		}

		//Get the amount of an object the character has in their inventory
		public int GetObjectAmount(string name)
		{
			for (int i =0; i<inventory.Count; i++)
			{
				if (inventory[i].name == name)
				{
					return inventory[i].amount;
				}
			}
			return 0;
		}

		//Remove an amount of an object from the characters inventory
		//Returns -1 if object does not exist or does not have enough of the amount
		//Will not remove the amount if the amount is less than zero
		public int RemoveAmountFromInventory(string name, int amount)
		{
			int i;
			for (i=0;i<inventory.Count;i++)
			{
				if (inventory[i].name == name)
				{
					break; //we now know the index of the matching item; there should never be duplicates
				}
			}
			int newAmount = inventory [i].amount - amount;
			if (newAmount > 0)
			{
				inventory[i].amount = newAmount;
			} else if (newAmount == 0)
			{
				inventory.RemoveAt(i);
			} else if (newAmount < 0)
			{
				return -1;
			}
			return newAmount;
		}

		//check if the inv name is in the inventory, return bool
		public bool HasObjectNameInInventory(string toFind)		
		{
			Debug.Log("GetFoodFromInventory");
			if (GetObjectAmount(toFind) == 0)
			{
				return false;
			} 
			return true;
		}
	}

	//inventory item, allows for a list of item variables to be stored.
	public class InventoryItem : Object
	{
		public int amount;
		public object obj;

		public InventoryItem(string name, int amount, object obj)
		{
			this.name = name;
			this.amount = amount;
			this.obj = obj;
		}

		public InventoryItem(string name, int amount)
		{
			this.name = name;
			this.amount = amount;
		}
	}
}