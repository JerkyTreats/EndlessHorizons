using System.Collections.Generic;
using Needs;

namespace Needs
{
    public class NeedData
    {
        public string NeedName { get; set; }
        public List<NeedStatus> NeedStatuses { get; set; }
        public int StartingValue { get; set; }
        public int ValueDecrementRate { get; set; }
        public int TimeToDecrement { get; set; }

        public NeedData(string needName, List<NeedStatus> needStatuses, int startingValue, int valueDecrementRate, int timeToDecrement)
        {
            this.NeedName = needName;
            this.NeedStatuses = needStatuses;
            this.StartingValue = startingValue;
            this.ValueDecrementRate = valueDecrementRate;
            this.TimeToDecrement = timeToDecrement;
        }
    }
}
