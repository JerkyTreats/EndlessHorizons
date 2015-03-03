using UnityEngine;
using System.Collections.Generic;

namespace Character
{
	[RequireComponent(typeof(PolyNavAgent))]
	public class Controller : MonoBehaviour{
		public string characterType = "character";
		private PolyNavAgent _agent;
		public Vector3 goal;
		private Animator anim;
		public Planner planner;
		public Hunger hunger;
		public Inventory inventory;

		public PolyNavAgent agent{
			get
			{
				if (!_agent)
					_agent = GetComponent<PolyNavAgent>();
				return _agent;			
			}
		}


		void Start(){
			inventory = GetComponent<Inventory>();
			hunger = GetComponent<Hunger>();
			planner = GetComponent<Planner>();
			anim = GetComponent<Animator>();
		}

		void Update() {
			if (Input.GetMouseButtonDown(0)){
				Vector3 mouse = new Vector3(Input.mousePosition.x,Input.mousePosition.y,(Camera.main.transform.position.z*-1));
				goal = Camera.main.ScreenToWorldPoint(mouse);
				SetDestination(goal);
			}
		}

		public void SetDestination(Vector3 goal)
		{
			Debug.Log(goal);
			agent.SetDestination(goal);
		}

		
		//Message from Agent: When a pathfinding has started
		void OnNavigationStarted(){
			anim.SetBool ("isMoving", true);
		}

		//Message from Agent: When a corner point has been reached
		void OnNavigationPointReached(){

			//do something here...		
		}

		//Message from Agent: When the destination has been reached
		void OnDestinationReached(){
			anim.SetBool ("isMoving", false);
		}

		//Message from Agent: When the destination is or becomes invalid
		void OnDestinationInvalid(){

			//do something here...
		}
	}
}

