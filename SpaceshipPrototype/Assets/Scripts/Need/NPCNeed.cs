using UnityEngine;
using System.Collections.Generic;
using NPC;

namespace Needs
{
    //NPC takes the base class Need and implements communication with the AI planner
    public class NPCNeed : Need
    {
        // private Planner planner;
		public int goalWeight { get; set; }

        public void Start()
        {
			Debug.Log("START NPCNEED");
            // planner = gameObject.GetComponent<Planner>();
        }

        //override class SetCurrentState to call the planner
   //      protected override void SetCurrentStatus()
   //      {
   //          NeedStatus oldStatus = CurrentStatus;
   //          base.SetCurrentStatus();
			// if (oldStatus==null)
			// {
			// 	if (planner == null)
			// 	{
			// 		Start(); 
			// 	}
			// 	planner.UpdateStatus(new Goal(NeedName, CurrentStatus.goalWeight));
			// }
			// else if (!CurrentStatus.text.Equals(oldStatus.text))
   //          {
   //              planner.UpdateStatus(new Goal(NeedName, CurrentStatus.goalWeight));
   //          }
   //      }
    }
}
