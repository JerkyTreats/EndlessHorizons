using UnityEngine;
using System.Collections.Generic;

namespace Needs
{
    public abstract class Need : MonoBehaviour
    {
        public string NeedName { get; set; } //match to ActionType/GoalName
        public NeedStatus CurrentStatus { get; set; }
        public int ValueDecrementRate { get; set; }
        public int TimeToDecrement { get; set; }
		public int CurrentValue { get; set; }
        private List<NeedStatus> NeedStatuses;

        //Constructor for MonoBehaviour object
        //Will have to resolve the Start method invoking an empty object
        public void Init(NeedData needData)
        {
            NeedName = needData.NeedName;
            NeedStatuses = needData.NeedStatuses;
            ValueDecrementRate = needData.ValueDecrementRate;
            TimeToDecrement = needData.TimeToDecrement;
            CurrentValue = needData.StartingValue;
			SetCurrentStatus();
            InvokeRepeating("DecrementCurrentValue", 0, needData.TimeToDecrement);

			Debug.Log(this.NeedName + " Init Completed");
        }
        
        //Overloaded for no assignment, just start the value decrementation
        public void Init()
        {
            InvokeRepeating("DecrementCurrentValue",0,TimeToDecrement);
        }

        //Continuously reduce the currentValue of the characters need. Update the status. 
        //This should be called via InvokeRepeating
        public void DecrementCurrentValue()
        {
			Debug.Log(CurrentValue + " " + ValueDecrementRate);
            CurrentValue -= ValueDecrementRate;
            SetCurrentStatus();
        }

        public void IncreaseCurrentValue(int amount)
        {
            CurrentValue+=amount;
            SetCurrentStatus();
        }
        
        //Loop through the NeedStatuses list to find the currentStatus 
        //Update the current status if changed
        //NPC.Need overloads this method to send updates to its AI Planner
        //Player.Need will likely overload this method to send updates to UI
        virtual protected void SetCurrentStatus()
        {
            for (int i = 0; i < NeedStatuses.Count; i++)
            {
                if (CurrentValue >= NeedStatuses[i].lowerThreshold &&
                    CurrentValue <= NeedStatuses[i].upperThreshold)
                {
                    if(CurrentStatus==null) 
					{
						CurrentStatus = NeedStatuses[i];
					}
					else if (!CurrentStatus.text.Equals(NeedStatuses[i].text))
					{
						CurrentStatus = NeedStatuses[i];
					}
                    break;
                }
            }
        }
    }
}