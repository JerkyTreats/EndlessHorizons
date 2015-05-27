using UnityEngine;
using System.Collections.Generic;
using Characters;
using Needs;

namespace NPC
{
    public class NPC : Characters.Character
    {
	    public Planner planner;

		new void Start()
		{
			base.Start();
			planner = GetComponent<Planner>();
			Needs = NeedFactory.NPCNeedFactory(this);
		}
    }
}