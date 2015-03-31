using UnityEngine;
using System.Collections;


namespace PrototypeCamera {
	public class Controller : MonoBehaviour {
		public float cameraSpeed = 10f;
		public float scrollSpeed = 5f;

		// Update is called once per frame
		void Update(){

			//move camera on z axis via mouseScroll
			//still need to implement upper/lower bounds to prevent excessive scrolling
			float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
			Camera.main.transform.Translate (0,0, mouseScroll * Time.deltaTime * scrollSpeed, Camera.main.transform);
		
		}

		//Called at constant rate? Only use for 2D Physics movement
		void FixedUpdate () {
			float cameraZDistance = Camera.main.transform.position.z;
			if (cameraZDistance < 0) {
				cameraZDistance *= -1;
			}

			//move camera along x/y axis on input
			float moveHorizontal = Input.GetAxis ("Horizontal"); //get current horizontal input
			float moveVertical = Input.GetAxis ("Vertical"); //get current vertical input
			GetComponent<Rigidbody2D>().AddForce (gameObject.transform.up * cameraSpeed * moveVertical * cameraZDistance);
			GetComponent<Rigidbody2D>().AddForce (gameObject.transform.right * cameraSpeed * moveHorizontal * cameraZDistance);
	}
}
}	