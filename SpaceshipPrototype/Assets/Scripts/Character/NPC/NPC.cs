using UnityEngine;
using System.Collections.Generic;
using Characters;
using Needs;

namespace NPC
{
	//"Non Player Character"
    public class NPC : Character
    {
    	public Planner Planner;
    	
		new void Start()
		{
			base.Start();
			Needs = NeedFactory.NPCNeedFactory(this);
			Planner = gameObject.GetComponent<Planner>();
			Planner.InvokeDetermineHighestGoal();
		}
    }
}