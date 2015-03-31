using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kitchen;

namespace NPC
{
	public class Hunger : Character.Hunger {
		public Goal goal; //Associated goal for AI Planner
		private Dictionary<string,int> hungerGoalMap; //Maps "hungry", "peckish" strings to a goal weight
		Planner planner;

		// Use this for initialization
		new void Start () 
	    {
			goal = ScriptableObject.CreateInstance<Goal>();
			hungerGoalMap = new Dictionary<string, int>();
			MapHungerGoals ();
			goal.Init("ReduceHunger", 0);
			planner = gameObject.GetComponent<Planner> ();
			base.Start(); //trigger base class constructor (Character.Hunger);
		}

		void MapHungerGoals()
		{
			hungerGoalMap.Add ("Totally Satisfied", 0);
			hungerGoalMap.Add ("Very Full", 0);
			hungerGoalMap.Add ("Full", 0);
			hungerGoalMap.Add ("Satisfied", 0);
			hungerGoalMap.Add ("Peckish", 5);
			hungerGoalMap.Add ("Hungry", 21);
			hungerGoalMap.Add ("Starving", 34);
			hungerGoalMap.Add ("Dangerously Hungry", 89);

		}

	    //override class SetCurrentState to call the planner
		protected override void SetCurrentState()
		{
			string oldState = currentState;
			base.SetCurrentState ();  
			if (currentState != oldState)
			{
				goal.goalWeight = hungerGoalMap[currentState];
                planner.UpdateStatus(goal);
			}
	    }
	}
}
