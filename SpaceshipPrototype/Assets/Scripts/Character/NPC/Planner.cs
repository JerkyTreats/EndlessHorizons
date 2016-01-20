using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InteractableObjects;
using Needs;

namespace NPC
{
	//Determines what the character should do based on their needs 
	public class Planner : MonoBehaviour {
		private NPC Controller; 
        public Action.Action CurrentAction;
		public List<InteractableObject> WorldObjects;

		void Start () {
			Controller = gameObject.GetComponent<NPC>();
			WorldObjects = new List<InteractableObject>();

			//Sign up for InteractableObjects announcements. See method AnnounceInteractableObjects();
			NotificationCenter.DefaultCenter().AddObserver(this, "AnnounceInteractableObjects"); 
		}

		//When called, all InteractableObjects announce themselves
		//This allows the planner to know what objects to interact with to acheive goals
		//ie. Kitchen announces itself, Planner will know to go to Kitchen to do a HungerAction;
		void AnnounceInteractableObjects(Notification notification)
		{
			Debug.Log("IO Notification recieved by planner");
			WorldObjects.Add((InteractableObject)notification.sender);
		}

        //Should be invokeRepeating by Start, constantly determining the most important thing to do
        public void DetermineHighestGoal()
		{
			Need need = GetMostImportantNeed();
			DoAction(need);
		}

		void DoAction(Need need)
		{
			InteractableObject obj = GetInteractableObjectByNeed(need);
			CurrentAction = Action.ActionFactory.StartAction(need.NeedName, Controller, obj);
		}

		public Need GetMostImportantNeed()
		{
			List<Need> needs = Controller.Needs.needs;
			int mostImportantGoal = 0;
			Need mostImportantNeed= null;

			foreach (Need need in needs)
			{
				if (need.CurrentStatus.goalWeight > mostImportantGoal)
				{
					mostImportantNeed = need;
				}
			}

			return mostImportantNeed;
		}

		public InteractableObject GetInteractableObjectByNeed(Need need)
		{
			for (int i = 0; i < WorldObjects.Count; i++)
			{
				if (WorldObjects[i].ActionType.Equals(need.NeedName))
				{
					return WorldObjects[i];
				}
			}
			Debug.Log("No InteractableObjects known fulfill Need [" + need.NeedName + "]");
			return null;
		}
	}
}