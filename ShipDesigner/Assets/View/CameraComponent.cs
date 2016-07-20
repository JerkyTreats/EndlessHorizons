using UnityEngine;
using System.Collections;


namespace View
{
	public class CameraComponent : MonoBehaviour, ICameraMovement
	{
		private CameraController controller;

		void OnEnable()
		{
			controller.SetMovementController(this);
		}

		void LateUpdate()
		{
			float x = Input.GetAxis("Horizontal");
			float y = Input.GetAxis("Vertical");
			float z = Input.GetAxis("Mouse ScrollWheel");
			if (x != 0 || y != 0 || z != 0)
				controller.Move(transform.position, x, y, z);
		}

		public void Move (float x, float y, float z)
		{
			transform.position += new Vector3 (x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
		}

		public void SetController(CameraController controller)
		{
			this.controller = controller;
			transform.position = controller.Position;
		}
	}
}	