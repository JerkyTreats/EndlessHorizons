using UnityEngine;
using System;

namespace NPC
{
    //goal object to create, makes for easier (conceptually) goalWeight sorting;
    public class Goal
    {
        public string goalName;
        public int goalWeight;

        public Goal(string name, int weight)
        {
            goalName = name;
            goalWeight = weight;
        }

        public Goal() {}
    }
}