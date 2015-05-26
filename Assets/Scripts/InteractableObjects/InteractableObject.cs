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
		}

		void AnnounceAllInteractableObjects(Notification notification)
		{
			NotificationCenter.DefaultCenter().PostNotification(this, "AnnounceInteractableObjects", ActionType);
		}
	}
}
