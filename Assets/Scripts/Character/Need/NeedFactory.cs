using UnityEngine;
using Newtonsoft.Json;
using System.IO;

namespace Character.Need
{
    // Static class to create Need objects
    public static class NeedFactory
    {
        //Needs are ordered in NeedData.json as an array of Needs. The array is turned into a List<Need> through the NeedContainer
        private static NeedContainer BuildNeedContainerFromJson() {
            string path = @"C:/SpaceshipPrototype/Assets/Scripts/Character/Need/NeedData.json";
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (NeedContainer)serializer.Deserialize(file, typeof(NeedContainer));
             }
        }

        //For all the needs, add components to gameObject
        //Handle validation in this method, checking what needs are allowed for what type of character, etc.
        //Should also probably handle the case where a same Need is already attached to the Character
        private static NeedContainer AttachNeedsFromNeedContainer(NeedContainer needContainer, Character character)
        {
            foreach (Need need in needContainer.needs)
            {
                Need charNeed = character.gameObject.AddComponent<Need>();
                Debug.Log("Attaching Component: " + need.needName);
                charNeed = need;
                charNeed.Init();
            }
            
            return needContainer;
        }

        //public function triggering the built needs.
        public static NeedContainer BuildNeeds(Character character)
        {
            return AttachNeedsFromNeedContainer(BuildNeedContainerFromJson(), character);
        }
    }
}
