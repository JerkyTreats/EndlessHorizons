using UnityEngine;
using System.Collections.Generic;


namespace Needs
{
    public class NeedStatus : Object
    {
        public int lowerThreshold { get; set; }
        public int upperThreshold { get; set; }
        public string text { get; set; }
		public int goalWeight { get; set; }

		public NeedStatus(int upper, int lower, string text, int goal)
		{
			this.lowerThreshold = lower;
			this.upperThreshold = upper;
			this.text = text;
			this.goalWeight = goal;
		}
    }
}
