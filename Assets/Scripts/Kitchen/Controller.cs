using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using Character;

namespace Kitchen{
	public class Controller : MonoBehaviour {
		public string goalName; //associated goalName for AI planning purposes
		public List<Meal> meals;
		public int ingredients;
		private KitchenTrigger kitchenNode1;
		private KitchenTrigger kitchenNode2;
		private KitchenTrigger kitchenNode3;
		private string activeNode = null;

		// Use this for initialization
		void Start () {
			goalName = "ReduceHunger";

			//temporary meal list. Will find a better data implementation later;
			meals = Meal.GetMealsAsList();

			NotificationCenter.DefaultCenter().PostNotification(this, "AnnounceWorldLocation");
			//get the 3 circleCollider triggers in in the children
			//assign the children colliders to a reference here.
			foreach (Transform child in transform) //get all the children into a list
			{
				//Debug.Log(child.name);
				if (child.name =="Kitchen Trigger 1")
				{
					kitchenNode1=child.gameObject.GetComponent<KitchenTrigger>();
				}
				if (child.name =="Kitchen Trigger 2")
				{
					kitchenNode2=child.gameObject.GetComponent<KitchenTrigger>();
				}
				if (child.name =="Kitchen Trigger 3")
				{
					kitchenNode3=child.gameObject.GetComponent<KitchenTrigger>();
				}
			}
		}

		//cooks a meal at the kitchen workstation
		//takes a character gameObject and the mealName to cook
		void Cook(GameObject other, string mealName){
			Character.Controller control = other.GetComponent<Character.Controller>();
			for (int i = 0; i<=meals.Count; i++) //iterate through the meals
			{
				if (meals[i].mealName==mealName) //if the meal matches
				{
					if (ingredients==meals[i].ingredientsNeeded) //and if the kitchen has the ingredients needed
					{
						List<int> nodeOrder = meals[i].kitchenNodeOrder; //get the node order of the meal
						//determine the total time spent in the kitchen creating the meal
						float actualCookTime = (other.GetComponent<Hunger>().cookMultiplier * meals[i].minimumCookTime) ;
						//determine the amount of time spent in each node;
						float timeInNode = actualCookTime / nodeOrder.Count;
						int nodesComplete = 0;
						foreach (int node in nodeOrder)//for each node
						{
							KitchenTrigger kitchenNode=null;
							switch (node)
							{
								case 1:
									kitchenNode = kitchenNode1;
									break;
								case 2:
									kitchenNode = kitchenNode2;
									break;
								case 3:
									kitchenNode = kitchenNode3;
									break;
							}
							//find the exact center of the nodes position in worldspace
							Vector3 nodeLocation = new Vector3(kitchenNode.transform.position.x,kitchenNode.transform.position.y,0); //-kitchenNode.colliderTrigger.radius
							control.SetDestination(nodeLocation);
							while(kitchenNode.isActive)
							{
								timeInNode-=Time.deltaTime;
								if (timeInNode<0)
								{
									nodesComplete+=1;
								}
							}
						}
						if (nodesComplete == nodeOrder.Count)
						{
							control.inventory.Add(Meal.GetMeal(mealName),1);
						}
					}
				}
			}
		}
	}
}