using UnityEngine;
using SimpleJSON;
using System.Collections.Generic;
using InteractableObjects;
using Needs;

namespace NPC.Action
{
    //Action Object connecting an NPC with a Kitchen object
    //Planner initiates a HungerAction object, which does the necessary actions to Reduce the NPCs hunger
    public class Hunger : MonoBehaviour {
        private static float ACTION_DELAY_TIME = 1.0f;
        public Kitchen Kitchen { get; set; }
        public string ActionType = "hunger";


        void Start()
        {
            JSONNode j = Connect.GetJSONNode(new List<string> { "Character", "NPC", "Action", "Hunger.json" });
            for (int i = 0; i < j["Action"].Count; i++)
            {
                Invoke(j["Action"][i].Value, ACTION_DELAY_TIME);
            }
            Destroy(this);
        }

        public void Init(Kitchen k, Need Need)
        {
            Kitchen = k;
        }

        void Eat()
        {
            Eat eatAction = gameObject.AddComponent<Eat>();
            if (eatAction.EatMeal())
            {
                Destroy(eatAction);
                Destroy(this);
            }
            return;
        }

        void Cook()
        {
            Cook cookAction = gameObject.AddComponent<Cook>();
            cookAction.Init(Kitchen);
            Destroy(this);
        }

		void FinishAction()
		{
			//Owner.Planner.FinishAction(); //Leaves this object to wither and die?
		}
	}
}