using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Needs
{
    public abstract class Need : MonoBehaviour
    {
        public string needName { get; set; }
        public NeedStatus currentStatus { get; set; }
        public int valueDecrementRate { get; set; }
        public int timeToDecrement { get; set; }
        private int currentValue;
        private List<NeedStatus> needStatuses;

        //Constructor for MonoBehaviour object
        //Will have to resolve the Start method invoking an empty object
        public void Init(string needName, List<NeedStatus> needStatuses, int startingValue, int valueDecrementRate, int timeToDecrement)
        {
            this.needName = needName;
            this.needStatuses = needStatuses;
            this.valueDecrementRate = valueDecrementRate;
            this.timeToDecrement = timeToDecrement;
            currentValue = startingValue;
			SetCurrentStatus();
            InvokeRepeating("DecrementCurrentValue", 0, timeToDecrement);

			Debug.Log(this.needName + " Init Completed");
        }
        
        //Overloaded for no assignment, just start the value decrementation
        public void Init()
        {
            InvokeRepeating("DecrementCurrentValue",0,timeToDecrement);
        }

        //Continuously reduce the currentValue of the characters need. Update the status. 
        //This should be called via InvokeRepeating
        public void DecrementCurrentValue()
        {
			Debug.Log(currentValue + " " + valueDecrementRate);
            currentValue -= valueDecrementRate;
            SetCurrentStatus();
        }

        public void IncreaseCurrentValue(int amount)
        {
            currentValue+=amount;
            SetCurrentStatus();
        }
        
        //Loop through the NeedStatuses list to find the currentStatus 
        //Update the current status if changed
        //NPC.Need overloads this method to send updates to its AI Planner
        //Player.Need will likely overload this method to send updates to UI
        virtual protected void SetCurrentStatus()
        {
            for (int i = 0; i < needStatuses.Count; i++)
            {
                if (currentValue >= needStatuses[i].lowerThreshold &&
                    currentValue <= needStatuses[i].upperThreshold)
                {
                    if(currentStatus==null) 
					{
						currentStatus = needStatuses[i];
					}
					else if (!currentStatus.text.Equals(needStatuses[i].text))
					{
						currentStatus = needStatuses[i];
					}
                    break;
                }
            }
        }
    }
}