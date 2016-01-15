using UnityEngine;
using System.IO;
using System.Collections.Generic;
using SimpleJSON;

namespace Needs
{
    // Static class to create Need objects
    public static class NeedFactory
    {
		static JSONNode Connect(string fileName)
		{
			string path = GetPath(fileName);
			StreamReader file = File.OpenText(path);
			string jsonString = file.ReadToEnd();
			Debug.Log(jsonString);
			return JSON.Parse(jsonString);
		}

		private static string GetPath(string fileName)
		{
			string file = fileName + ".json";
			string[] folders = new string[] {"Assets", "Scripts", "Need", file};
			string dir = Directory.GetCurrentDirectory();

			foreach (string folder in folders)
			{
				dir = Path.Combine(dir, folder);
			}			
			return dir;
		}

		public static NeedContainer NPCNeedFactory(NPC.NPC character)
		{
			Debug.Log("In NPCNeedFactory");
			NeedContainer nc = new NeedContainer();
			JSONNode j = Connect("NeedData");

			for (int i = 0; i < j["NPCNeed"].Count; i++)
			{
				NPCNeed charNeed = character.gameObject.AddComponent<NPCNeed>();
			
				//Debug.Log("name " + j["NPCNeed"][i]["needName"].Value);
				//Debug.Log("stati " + NeedStatusFactory(j, i));
				//Debug.Log("starting " + j["NPCNeed"][i]["startingValue"].AsInt);
				//Debug.Log("decrementvalue " + j["NPCNeed"][i]["valueDecrementRate"].AsInt);
				//Debug.Log("time " + j["NPCNeed"][i]["timeToDecrement"].AsInt);

				charNeed.Init(
					j["NPCNeed"][i]["needName"].Value,
					NeedStatusFactory(j, i),
					j["NPCNeed"][i]["startingValue"].AsInt,
					j["NPCNeed"][i]["valueDecrementRate"].AsInt, 
					j["NPCNeed"][i]["timeToDecrement"].AsInt
					);
				nc.needs.Add(charNeed);
			}
			return nc;
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
