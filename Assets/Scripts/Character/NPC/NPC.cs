using UnityEngine;
using System.Collections.Generic;

namespace NPC
{
    public class NPC : Character.Character
    {
	    public Planner planner;

		void Start()
		{
			base.Start();
			planner = GetComponent<Planner>();
		}
    }
}