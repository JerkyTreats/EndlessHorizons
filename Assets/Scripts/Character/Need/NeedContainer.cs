using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Character.Need
{
    public class NeedContainer
    {
        public List<Need> needs {get; set;}
        public Dictionary<string, Need> map { get; set;}

        NeedContainer()
        {
            needs = new List<Need>();
            map = new Dictionary<string,Need>();
        }

        NeedContainer(List<Need> needs)
        {
            this.needs = needs;
        }

        void generateMap()
        {
            foreach(Need need in needs)
            {
                map.Add(need.needName,need);
            }
        }
    }
}
