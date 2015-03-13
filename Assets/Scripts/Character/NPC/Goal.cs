using UnityEngine;
using System;

namespace NPC
{
    //goal object to create, makes for easier (conceptually) goalWeight sorting;
    public class Goal : ScriptableObject
    {
        public string goalName;
        public int goalWeight;

        public void Init(string name, int weight)
        {
            goalName = name;
            goalWeight = weight;
        }
    }
}