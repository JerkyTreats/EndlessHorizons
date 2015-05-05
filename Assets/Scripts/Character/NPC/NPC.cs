using UnityEngine;
using System.Collections.Generic;
using Character;

namespace NPC
{
    public class NPC : Character.Character
    {
	    public Planner planner;

		new void Start()
		{
			base.Start();
			planner = GetComponent<Planner>();
			needs = Need.NeedFactory.NPCNeedFactory(this);
		}
    }
}