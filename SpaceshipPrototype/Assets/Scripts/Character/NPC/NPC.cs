using UnityEngine;
using System.Collections.Generic;
using Characters;
using Needs;

namespace NPC
{
	//"Non Player Character"
    public class NPC : Character
    {
		new void Start()
		{
			base.Start();
			Planner planner = gameObject.GetComponent<Planner>();
			Needs = NeedFactory.NPCNeedFactory(this);
		}
    }
}