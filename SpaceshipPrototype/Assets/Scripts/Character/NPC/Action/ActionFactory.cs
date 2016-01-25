using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InteractableObjects;

namespace NPC.Action
{
	public static class ActionFactory
	{
		public static void StartAction(string actionName, NPC owner, InteractableObject io)
		{
			actionName = actionName.ToLower();

			if (actionName.Equals("hunger"))
			{
               Hunger h = owner.gameObject.AddComponent<Hunger>();
                h.Init((Kitchen)io);
			}
			else if (actionName.Equals("sleep"))
			{
				Sleep s = owner.gameObject.AddComponent<Sleep>();
                s.Init((Bed)io);
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
