using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PolyNavAgent))]
public class Controller : MonoBehaviour{
	
	private PolyNavAgent _agent;
	private Animator anim;


	public PolyNavAgent agent{
		get
		{
			if (!_agent)
				_agent = GetComponent<PolyNavAgent>();
			return _agent;			
		}
	}

	void Start(){
		anim = GetComponent<Animator>();
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)){
			Vector3 mouse = new Vector3(Input.mousePosition.x,Input.mousePosition.y,(Camera.main.transform.position.z*-1));
			var goal = Camera.main.ScreenToWorldPoint(mouse);
			if (agent.SetDestination(goal) == true){
			} else {
				//Debug.Log("Goal is blocked or is outside of the navigation map. If you want me to go as closer as I can, enable 'Closer Point On Invalid' in my inspector");
			}
		}
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

