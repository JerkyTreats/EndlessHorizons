using UnityEngine;
using System.Collections;
using Util;


namespace View
{
	public class CameraComponent : MonoBehaviour, IMovementController
	{
		private CameraController controller;

		void OnEnable()
		{
			controller.SetMovementController(this);
		}

		void FixedUpdate()
		{
			if (Input.GetButton("Horizontal"))
				controller.MoveX(Input.GetAxis("Horizontal") * Time.deltaTime);
			if (Input.GetButton("Vertical"))
				controller.MoveY(Input.GetAxis("Vertical") * Time.deltaTime);
			if(Input.GetButton("Mouse ScrollWheel"))
				controller.MoveZ(Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime);
		}

		public void MoveX(float value)
		{
			if ((transform.position.x + value > controller.Boundary.X.Min) && (transform.position.x + value < controller.Boundary.X.Max))
				transform.position += new Vector3(value, 0);
		}

		public void MoveY(float value)
		{
			if ((transform.position.y + value > controller.Boundary.Y.Min) && (transform.position.y + value < controller.Boundary.Y.Max))
				transform.position += new Vector3(0, value);
		}

		public void MoveZ(float value)
		{
			if ((transform.position.z + value > controller.Boundary.Z.Min) && (transform.position.z + value < controller.Boundary.Z.Max))
				transform.position += new Vector3(0, 0, value);
		}

		public void SetController(CameraController controller)
		{
			this.controller = controller;
			transform.position = controller.Position;
		}
	}
}	