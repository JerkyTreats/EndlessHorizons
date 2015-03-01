using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kitchen;

namespace Character
{
	public class Hunger : MonoBehaviour {
		public Goal goal; //Associated goal for AI Planner
		public int hungerRate; //rate at which hunger is increased
		public float cookMultiplier; //will multiply the length of time to cook a meal. 
		private int hungerLevel; //current hunger level as an int; decreases over time, increases on eat
		private string currentState; //string stating what the current hunger level is;

		// Use this for initialization
		void Start () 
	    {
			goal = new Goal("ReduceHunger", 0);
	        hungerLevel = 100;
			cookMultiplier = 1f;
	        InvokeRepeating("IncreaseHunger", 0,(1*60));
			NotificationCenter.DefaultCenter().PostNotification(this, "AddAvailableAction", "FindFoodInInventory");
		}
		
		void IncreaseHunger()
	    {
	        hungerLevel -= hungerRate;
	        SetCurrentState();
	    }

	    public void Eat(int mealValue)
	    {
	        hungerLevel += mealValue;
	        SetCurrentState();
	    }

	    void SetCurrentState()
	    {
			string newState=null;
	        if (hungerLevel > 110)
			{
				Debug.Log("Would totally throw up right now");
				goal.goalWeight=0;
			} else if (hungerLevel >= 100 && hungerLevel <= 110)
			{
				newState ="Totally Satisfied";
				if (currentState != newState){
					Debug.Log(newState);
				}
				hungerLevel = 100;
				goal.goalWeight = 0;
			} else if (hungerLevel < 100 && hungerLevel >= 90)
			{
				newState = "Very Full";
				if (currentState != newState){
					Debug.Log(newState);
				}
				goal.goalWeight = 0;
			} else if (hungerLevel < 90 && hungerLevel >= 80)
			{
				newState="Full";
				if (currentState != newState){
					Debug.Log(newState);
				}
				goal.goalWeight = 0;
			} else if (hungerLevel < 80 && hungerLevel >= 70)
			{
				newState = "Satisfied";
				if (currentState != newState){
					Debug.Log(newState);
				}
				goal.goalWeight = 5;
			} else if (hungerLevel < 70 && hungerLevel >= 60)
			{
				newState = "Peckish";
				if (currentState != newState){
					Debug.Log(newState);
				}
				goal.goalWeight = 8;
	        } else if (hungerLevel < 60 && hungerLevel >= 30)
	        {
				newState = "Hungry";
				if (currentState != newState){
					Debug.Log(newState);
				}
				goal.goalWeight = 13;
	        } else if (hungerLevel < 30 && hungerLevel >= 20)
	        {
				newState = "Starving";
				if (currentState != newState){
					Debug.Log(newState);
				}
				goal.goalWeight = 21;
	        } else if (hungerLevel < 20 && hungerLevel >= 0)
	        {
				newState = "Dangerously Hungry";
				if (currentState != newState){
					Debug.Log(newState);
				}
				goal.goalWeight = 34;

	        }
			if (currentState != newState && newState != null)
			{
				currentState = newState;
				Debug.Log(currentState);
				NotificationCenter.DefaultCenter().PostNotification(this, "UpdateStatus", goal); //Send a notification to listeners
				CancelInvoke("IncreaseHunger"); //cancel the current invoke
				InvokeRepeating("IncreaseHunger", (1*60),(1*60)); //reset the hunger timer to be every x minutes again
			}
	    }
	}
}
