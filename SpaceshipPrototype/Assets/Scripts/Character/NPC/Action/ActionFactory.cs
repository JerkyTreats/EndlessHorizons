using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InteractableObjects;
using Needs;

namespace NPC.Action
{
	public static class ActionFactory
	{
		public static void StartAction(Need Need, NPC owner, InteractableObject io)
		{
			string actionName = Need.NeedName.ToLower();

			if (actionName.Equals("hunger"))
			{
               Hunger h = owner.gameObject.AddComponent<Hunger>();
               h.Init((Kitchen)io, Need);
			}
			else if (actionName.Equals("sleep"))
			{
				Sleep s = owner.gameObject.AddComponent<Sleep>();
                s.Init((Bed)io, Need);
			}
			else if (actionName.Equals("idle"))
			{
				throw new NotImplementedException();
				//return new IdleAction(owner);
			}
			else
			{
				//Debug.Log(actionName + " does not exist");
				throw new NotImplementedException();
			}
		}
	}
}
