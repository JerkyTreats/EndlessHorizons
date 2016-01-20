using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InteractableObjects;

namespace NPC.Action
{
	public static class ActionFactory
	{
		public static Action StartAction(string actionName, NPC owner, InteractableObject io)
		{
			actionName = actionName.ToLower();

			if (actionName.Equals("hunger"))
			{
				Kitchen k = (Kitchen)io;
				return new HungerAction(owner, k);
			}
			else if (actionName.Equals("sleep"))
			{
				Bed b = (Bed)io;
				return new SleepAction(owner, b);
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
