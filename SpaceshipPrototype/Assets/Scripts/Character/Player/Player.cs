using UnityEngine;
using System.Collections.Generic;

namespace Characters
{	
	public class Player : Character{

		void Update() {
			if (Input.GetMouseButtonDown(1)){
				Vector3 mouse = new Vector3(Input.mousePosition.x,Input.mousePosition.y,(Camera.main.transform.position.z*-1));
				Vector3 goal = Camera.main.ScreenToWorldPoint(mouse);
				SetDestination(goal);
			}
		}

		
	}
}

