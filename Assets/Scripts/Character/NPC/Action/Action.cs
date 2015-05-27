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
		public InteractableObject IO { get; set; }
		public string ActionType { get; set; }

		public Action(NPC controller, string actionType)
		{
			Owner = controller;
			this.ActionType = actionType;
			Need = (Needs.NPCNeed)Owner.Needs.LookUp(ActionType); //find the data class for this NPC
		}

		//Looks for a Planner.WorldObject by the ActionType 
		protected void DetermineInteractableObject()
		{
			if (Owner.planner.GetWorldObject(ActionType)==null)
			{
				Debug.Log("NPC cannot find InteractableObject. Announcing all IO's now");
				NotificationCenter.DefaultCenter().PostNotification(Owner.planner, "AnnounceAllInteractableObjects");
			}
			IO = Owner.planner.GetWorldObject(ActionType);
		}

    }
}
