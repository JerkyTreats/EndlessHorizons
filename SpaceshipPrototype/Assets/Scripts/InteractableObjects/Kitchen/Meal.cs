using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace InteractableObjects
{
    public class Meal
    {
        public string Name;  //name of the meal 
        public int NeedValue; //character.hunger NeedValue 
        public int ingredientsNeeded;  //ingredients as a int for now, will probably have increased complexity later
        List<MealNode> MealNodes;

        public Meal() {
            //default to allow pendingMeal class constructing
        }

        //constructor
        public Meal(string mealName, int NeedValue, List<MealNode> MealNodes, int ingredientsNeeded, float minimumCookTime) {
            this.Name = mealName;
            this.NeedValue = NeedValue;
            this.ingredientsNeeded = ingredientsNeeded;
            this.MealNodes = MealNodes;
        }

        internal int GetKitchenNode(int v)
        {
            return MealNodes[v].KitchenNodeOrder;
        }

        internal float GetNodeCookTime(int v)
        {
            return MealNodes[v].NodeCookTime;
        }

        internal int GetKitchenNodeTotal()
        {
            return MealNodes.Count;
        }

        //Temporary data init static methods
        public static List<Meal> GetMealsAsList()
        {
            List<Meal> meals = new List<Meal>(); //to return
            List<MealNode> mealNodes = new List<MealNode>();

            mealNodes.Add(new MealNode(21.0f, 1));
            mealNodes.Add(new MealNode(10.0f, 2));

            //meals.Add(new Meal("snack", 8, mealNodes, 1, 18f));
            Meal test = new Meal("meal", 21, mealNodes, 3, 15f);

            Debug.Log(test.Name + " " + test.NeedValue + " " + test.ingredientsNeeded + " " + test.MealNodes.Count);
            meals.Add(test);

            return meals;
        }

        //Temporary data init static methods
        public static Meal GetMeal(string mealName)
        {
            List<Meal> meals = GetMealsAsList();
            foreach (Meal meal in meals)
            {
                if (meal.Name == mealName)
                {
                    Debug.Log(meal);
                    return meal;
                }
            }
            Debug.LogError("Meal.GetMeal " + mealName + " is not a valid meal name. Returning null.");
            return null;
        }
    }

    public class MealNode
    {
        public float NodeCookTime;
        public int KitchenNodeOrder;

        public MealNode(float nodeCookTime, int kitchenNodeOrder)
        {
            NodeCookTime = nodeCookTime;
            KitchenNodeOrder = kitchenNodeOrder;
        }
    }
}