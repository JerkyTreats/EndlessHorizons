using UnityEngine;
using System.Collections.Generic;

namespace Character
{
	//Base class for NPC/Player 
    [RequireComponent(typeof(PolyNavAgent))]
    public class Character : MonoBehaviour
    {
        public string characterType = "character";
        private PolyNavAgent _agent;
        private Animator anim;
        public Inventory inventory;
        public NPC.Hunger hunger;

        public void Start()
        {
            inventory = GetComponent<Inventory>();
			hunger = GetComponent<NPC.Hunger>();
            anim = GetComponent<Animator>();
        }

        public PolyNavAgent agent
        {
            get
            {
                if (!_agent)
                    _agent = GetComponent<PolyNavAgent>();
                return _agent;
            }
        }

        //sets a vector3 location for the character to go to 
        public void SetDestination(Vector3 goal)
        {
            Debug.Log(goal);
            agent.SetDestination(goal);
        }

        //Message from Agent: When a pathfinding has started
        void OnNavigationStarted()
        {
            anim.SetBool("isMoving", true);
        }

        //Message from Agent: When a corner point has been reached
        void OnNavigationPointReached()
        {

            //do something here...		
        }

        //Message from Agent: When the destination has been reached
        void OnDestinationReached()
        {
            anim.SetBool("isMoving", false);
        }

        //Message from Agent: When the destination is or becomes invalid
        void OnDestinationInvalid()
        {

            //do something here...
        }
    }
}