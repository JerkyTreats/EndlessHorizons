using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Characters;
using System;

namespace InteractableObjects{
	public class Kitchen : InteractableObject {
		public List<Meal> Menu;
		public int Ingredients;
		private List<GameObject> KitchenNodes; 

        internal GameObject GetNode(int v)
        {
            return KitchenNodes[v];
        }

        // Use this for initialization
        override public void Start()
		{
			base.Start();
			ActionType = "hunger";
			KitchenNodes = new List<GameObject>();
			
			Menu = Meal.GetMealsAsList(); //temporary meal list. Will find a better data implementation later;

            foreach (Transform child in transform) //get all the children into a list
			{
                if (child.GetType().ToString().Equals("KitchenTrigger"))
                {
                    KitchenNodes.Add(child.gameObject);
                }
			}
		}
	}
}