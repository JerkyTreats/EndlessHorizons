using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Needs
{
    public class NeedContainer
    {
        public List<Need> needs {get; set;}
        public Dictionary<string, Need> map { get; set;}

        public NeedContainer()
        {
            needs = new List<Need>();
            map = new Dictionary<string,Need>();
        }

        public NeedContainer(List<Need> needs)
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

        public Need LookUp(string name)
        {
            if (map.Count == 0) { generateMap(); }
            return map[name];
        }
    }
}
