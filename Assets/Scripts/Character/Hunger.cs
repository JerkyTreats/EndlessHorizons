using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kitchen;

namespace Character
{
	public class Hunger : MonoBehaviour {
		protected int hungerLevel; //current hunger level as an int; decreases over time, increases on eat
		protected string currentState; //string stating what the current hunger level is;
		public int hungerRate; //rate at which hungerLevel is decreased
		public float cookMultiplier; //will multiply the length of time to cook a meal. 

		// Use this for initialization
		protected void Start () 
	    {
	        hungerLevel = 59;
			hungerRate = 3;
			cookMultiplier = 1f;
	        InvokeRepeating("IncreaseHunger", 0,(15));
		}
		
		protected void IncreaseHunger()
	    {
	        hungerLevel -= hungerRate;
	        SetCurrentState();
	    }

	    public void Eat(int mealValue)
	    {
			Debug.Log("Eat");
	        hungerLevel += mealValue;
	        SetCurrentState();
	    }

	    protected virtual void SetCurrentState()
	    {
			string newState=null;
	        if (hungerLevel > 110)
			{
				Debug.Log("Would totally throw up right now");
			} else if (hungerLevel >= 100 && hungerLevel <= 110)
			{
				newState ="Totally Satisfied";
				hungerLevel = 100;
			} else if (hungerLevel < 100 && hungerLevel >= 90)
			{
				newState = "Very Full";
			} else if (hungerLevel < 90 && hungerLevel >= 80)
			{
				newState="Full";
			} else if (hungerLevel < 80 && hungerLevel >= 70)
			{
				newState = "Satisfied";
			} else if (hungerLevel < 70 && hungerLevel >= 60)
			{
				newState = "Peckish";
	        } else if (hungerLevel < 60 && hungerLevel >= 30)
	        {
				newState = "Hungry";
	        } else if (hungerLevel < 30 && hungerLevel >= 20)
	        {
				newState = "Starving";
	        } else if (hungerLevel < 20 && hungerLevel >= 0)
	        {
				newState = "Dangerously Hungry";
	        }
			if (currentState != newState && newState != null)
			{
				currentState = newState;
			}
		}
	}
}
