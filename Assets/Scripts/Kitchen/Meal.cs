using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Kitchen{
	public class Meal : Object {
		public string mealName;  //name of the meal 
		public int mealValue; //character.hunger mealValue 
		public List<int> kitchenNodeOrder; //a kitchen has 3 nodes, how many nodes does character have to go to to cook meal
		public int ingredientsNeeded;  //ingredients as a int for now, will probably have increased complexity later
		public float minimumCookTime; //cook time with a "perfect" cook

		public Meal(){
			//default to allow pendingMeal class constructing
		}

		//constructor
		public Meal(string mealName, int mealValue, List<int> kitchenNodeOrder,int ingredientsNeeded, float minimumCookTime){
			this.mealName = mealName;
			this.mealValue=mealValue;
			this.kitchenNodeOrder=kitchenNodeOrder;
			this.ingredientsNeeded=ingredientsNeeded;
			this.minimumCookTime=minimumCookTime;
		}

		//Temporary data init static methods
		public static List<Meal> GetMealsAsList()
		{
			List<Meal> meals = new List<Meal>(); //to return
			List<int> mealOrder = new List<int>(); 

			mealOrder.Add(1);
			meals.Add(new Meal("snack",8,mealOrder,1,34f));
			mealOrder.Add(2);
			meals.Add(new Meal("meal", 21, mealOrder,3,55f));
			return meals;
		}

		//Temporary data init static methods
		public static Meal GetMeal(string mealName)
		{
			List<Meal> meals = GetMealsAsList();
			foreach (Meal meal in meals)
			{
				if (meal.mealName == mealName)
				{
					return meal;
				}
			}
			Debug.LogError("Meal.GetMeal " + mealName + " is not a valid meal name. Returning null.");
			return null;
		}
	}
}