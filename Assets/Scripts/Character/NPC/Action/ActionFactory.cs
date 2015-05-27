using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPC.Action
{
	public static class ActionFactory
	{
		public static Action GetAction(string actionName, NPC owner)
		{
			actionName = actionName.ToLower();

			if (actionName.Equals("hunger"))
			{
				return new HungerAction(owner);
			}
			else if (actionName.Equals("sleep"))
			{
				return new SleepAction(owner);
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
