using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InteractableObjects
{
	public abstract class InteractableObject : MonoBehaviour
	{
		public string ActionType { get; set; } //associated goalName for AI planning purposes

		virtual public void Start()
		{
			//This tells an NPC Planner that this object can be interacted with. 
			NotificationCenter.DefaultCenter().AddObserver(this, "AnnounceAllInteractableObjects");

			// NotificationCenter.DefaultCenter().AddObserver(this, "AnnounceInteractableObjects");
		}

		void AnnounceAllInteractableObjects(Notification notification)
		{
			Debug.Log("AnnounceAllInteractableObjects: " + ActionType);
			NotificationCenter.DefaultCenter().PostNotification(this, "AnnounceInteractableObjects", ActionType);
		}

		// void AnnounceInteractableObjects(Notification notification)
		// {
		// 	NotificationCenter.DefaultCenter().PostNotification(this, "AnnounceInteractableObjects", ActionType);
		// }

		//Go to the object location. Define where to go and who should go there. 
		protected void GoToObjectLocation(GameObject destination, Characters.Character owner)
		{
			Debug.Log("I am going to the " + destination);
			owner.SetDestination(destination.transform.position); //send the character to the kitchen
		}

		//Overloaded method to go to this objects location. 
		protected void GoToObjectLocation(Characters.Character owner)
		{
			owner.SetDestination(this.transform.position); //send the character to the kitchen
		}

		public Vector3 GetLocation()
		{
			return this.transform.position;
		}
	}
}
