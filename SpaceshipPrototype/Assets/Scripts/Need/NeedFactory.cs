using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

namespace Needs
{
    // Static class to create Need objects
    public static class NeedFactory
    {
		public static void NPCNeedFactory(Characters.Character character)
		{
			Debug.Log("In NPCNeedFactory");
			JSONNode j = Connect.GetJSONNode(new List<string> { "Need", "NeedData.json" });

			for (int i = 0; i < j["NPCNeed"].Count; i++)
			{
                Need charNeed = character.gameObject.AddComponent<Need>();

                //Debug.Log("name " + j["NPCNeed"][i]["needName"].Value);
                //Debug.Log("stati " + NeedStatusFactory(j, i));
                //Debug.Log("starting " + j["NPCNeed"][i]["startingValue"].AsInt);
                //Debug.Log("decrementvalue " + j["NPCNeed"][i]["valueDecrementRate"].AsInt);
                //Debug.Log("time " + j["NPCNeed"][i]["timeToDecrement"].AsInt);

                NeedData need = new NeedData(
					j["NPCNeed"][i]["needName"].Value,
					NeedStatusFactory(j, i),
					j["NPCNeed"][i]["startingValue"].AsInt,
					j["NPCNeed"][i]["valueDecrementRate"].AsInt, 
					j["NPCNeed"][i]["timeToDecrement"].AsInt
					);
                charNeed.Init(need);
			}
		}

		static List<NeedStatus> NeedStatusFactory(JSONNode j, int i)
		{
			List<NeedStatus> toReturn = new List<NeedStatus>();
			for (int n = 0; n < j["NPCNeed"][i]["needStatus"].Count; n++)
			{
				int upper = j["NPCNeed"][i]["needStatus"][n]["upperThreshold"].AsInt;
				int lower = j["NPCNeed"][i]["needStatus"][n]["lowerThreshold"].AsInt;
				string text = j["NPCNeed"][i]["needStatus"][n]["text"].Value;
				int goal = j["NPCNeed"][i]["needStatus"][n]["goalWeight"].AsInt;

				toReturn.Add(new NeedStatus(upper, lower, text, goal));
			}
			//Debug.Log(toReturn[0].upperThreshold + " " + toReturn[0].lowerThreshold + " " + toReturn[0].text + " " + toReturn[0].goalWeight);
			return toReturn;
		}
    }
}
