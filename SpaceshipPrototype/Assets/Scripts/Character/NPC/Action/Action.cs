using UnityEngine;
using System.Collections.Generic;
using NPC;
using Needs;
using InteractableObjects;

namespace NPC.Action
{
    public abstract class Action
    {
        protected NPC Owner;
		public NPCNeed Need { get; set; }
		public string ActionType { get; set; }

		public Action(NPC npc, string actionType)
		{
			Owner = npc;
			this.ActionType = actionType;
			Need = (Needs.NPCNeed)Owner.Needs.LookUp(ActionType); //find the data class for this NPC
		}
    }
}
