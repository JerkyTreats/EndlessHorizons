﻿using UnityEngine;
using System.Collections;

namespace Door
{
	public class Controller : MonoBehaviour {
		//public int startingRotation;
		private Animator anim;
		// Use this for initialization
		void Start () {
			anim = GetComponent<Animator>();
			//Quaternion q = new Quaternion();
			//q.z = startingRotation;
			//gameObject.transform.rotation = q;
		}

		

		void OnTriggerEnter2D(Collider2D other){
			if (other.tag == "Character")
			{
				TriggerDoor();
			}
		}

		void OnTriggerExit2D(Collider2D other)
		{
			if(other.tag == "Character")
			{
				TriggerDoor();
			}
		}

		void TriggerDoor()
		{
			anim.SetBool ("isCollision", !anim.GetBool("isCollision"));
		}
	}
}