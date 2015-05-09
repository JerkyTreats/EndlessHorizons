using UnityEngine;
using System.Collections.Generic;
using NPC;

namespace NPC.Action
{
    public abstract class Action
    {
        protected NPC owner;

		public Action(NPC controller)
		{
			owner = controller;
		}
    }
}
