using System.Collections.Generic;
using System.Linq;
using InteractableObjects.Bed;
using Need;
using UnityEngine;

namespace NPC.Action
{
	class SleepAction : Action
	{
		public Bed Bed { get; set; }
		

		public SleepAction(NPC owner)
			: base(owner, "sleep")
		{
			Debug.Log("I need to go to Bed!");
		}
	}
}
