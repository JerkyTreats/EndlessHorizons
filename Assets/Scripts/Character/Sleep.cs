using UnityEngine;
using System.Collections;

namespace Character 
{
	// TiredLevel @ 100 == very awake
	// TiredLevel @ 0 == will pass out
	public class Sleep : MonoBehaviour {
		public int tiredLevel;
		public int tireRate; 
		public string currentState;

		void Start()
		{
			tiredLevel = 100;
			tireRate = 5;
			InvokeRepeating ("IncreaseTiredness",0,15);
		}

		void IncreasedTiredness()
		{
			tiredLevel -= tireRate;
			SetCurrentState ();
		}

		void Rest(int sleepValue)
		{
			tiredLevel += sleepValue;
			SetCurrentState ();
		}

		void SetCurrentState()
		{
			string newState;
			if (tiredLevel > 100)
			{
				newState = "Hyper";
			} else if (tiredLevel < 100 && tiredLevel >= 50)
			{
				newState = "Awake";
			} else if (tiredLevel < 50 && tiredLevel >= 33)
			{
				newState = "Nappish";
			} else if (tiredLevel < 33 && tiredLevel >= 25)
			{
				newState = "Tired";
			}  else if (tiredLevel < 25 && tiredLevel >= 10)
			{
				newState = "Sleepy";	
			} else if (tiredLevel < 10 && tiredLevel >= 0)
			{
				newState = "Exhausted";
			} else if (tiredLevel <= 0)
			{
				newState = "Dangerously Exhausted";
			}

			if (currentState != newState && newState != null)
			{
				currentState = newState;
			}
		}
	}
}
