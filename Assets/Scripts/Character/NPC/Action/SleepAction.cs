using System.Collections.Generic;
using System.Linq;
using InteractableObjects.Bed;
using Needs;
using UnityEngine;

namespace NPC.Action
{
	class SleepAction : Action
	{	

		public SleepAction(NPC owner)
			: base(owner, "sleep")
		{
			Debug.Log("I need to go to sleep!");
			DetermineInteractableObject();
			Bed bed = (Bed)IO;
			bed.GoToBed(owner);
		}
	}
}
