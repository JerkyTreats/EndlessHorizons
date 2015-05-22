using UnityEngine;
using System.Collections.Generic;
using NPC;

namespace NPC.Action
{
    public abstract class Action
    {
        protected NPC owner;
		public string actionType { get; set; }

		public Action(NPC controller, string actionType)
		{
			owner = controller;
			this.actionType = actionType; 
		}


    }
}
