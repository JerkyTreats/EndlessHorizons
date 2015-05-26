using UnityEngine;
using System.Collections.Generic;
using NPC;
using Need;
using InteractableObjects;

namespace NPC.Action
{
    public abstract class Action
    {
        protected NPC Owner;
		public NPCNeed Need { get; set; }
		public InteractableObject IO { get; set; }
		public string ActionType { get; set; }

		public Action(NPC controller, string actionType)
		{
			Owner = controller;
			this.ActionType = actionType;
			Need = (Need.NPCNeed)Owner.needs.LookUp(ActionType); //find the data class hunger for this NPC
		}

		//Looks for a Planner.WorldObject (is a Dictionary) by the ActionType (which would be key)
		protected void DetermineInteractableObject()
		{
			if (Owner.planner.WorldObjects.Count == 0)
			{
				Debug.Log("NPC cannot find InteractableObject. Announcing all IO's now");
				NotificationCenter.DefaultCenter().PostNotification(Owner.planner, "AnnounceAllInteractableObjects");
			}
			IO = Owner.planner.GetWorldObject(ActionType);
		}

    }
}
