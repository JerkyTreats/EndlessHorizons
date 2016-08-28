using UnityEngine;
using System.Collections;

namespace View
{
	public class CameraComponent : MonoBehaviour, IMovementController
	{
		private CameraController controller;

		void FixedUpdate()
		{
			if (Input.GetButton("Horizontal"))
			{
				var input = Input.GetAxis("Horizontal") * Time.deltaTime;
				controller.MoveX(input);
			}
			if (Input.GetButton("Vertical"))
			{
				var input = Input.GetAxis("Vertical") * Time.deltaTime;
				controller.MoveY(input);
			}
			if (Input.GetButton("Mouse ScrollWheel"))
			{
				var input = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;
				controller.MoveZ(input);
			}
		}

		public void MoveX(float value)
		{
			Boundary.State state = controller.Boundary.WithinBounds(controller.Boundary.X, transform.position.x + value);
			switch (state)
			{
				case Boundary.State.WithinBounds:
					transform.position += new Vector3(value, 0);
					return;
				case Boundary.State.AboveMax:
					transform.position = new Vector3(controller.Boundary.X.Max, transform.position.y, transform.position.z);
					return;
				case Boundary.State.BelowMin:
					transform.position = new Vector3(controller.Boundary.X.Min, transform.position.y, transform.position.z);
					return;
			}

		}

		public void MoveY(float value)
		{
			Boundary.State state = controller.Boundary.WithinBounds(controller.Boundary.Y, transform.position.y + value);
			switch (state)
			{
				case Boundary.State.WithinBounds:
					transform.position += new Vector3(0, value);
					return;
				case Boundary.State.AboveMax:
					transform.position = new Vector3(transform.position.x, controller.Boundary.Y.Max, transform.position.z);
					return;
				case Boundary.State.BelowMin:
					transform.position = new Vector3(transform.position.x, controller.Boundary.Y.Min, transform.position.z);
					return;
			}
		}

		public void MoveZ(float value)
		{
			Boundary.State state = controller.Boundary.WithinBounds(controller.Boundary.Z, transform.position.z + value);
			switch (state)
			{
				case Boundary.State.WithinBounds:
					transform.position += new Vector3(0, 0, value);
					return;
				case Boundary.State.AboveMax:
					transform.position = new Vector3(transform.position.x, transform.position.y, controller.Boundary.Z.Max);
					return;
				case Boundary.State.BelowMin:
					transform.position = new Vector3(transform.position.x, transform.position.y, controller.Boundary.Z.Min);
					return;
			}
		}

		public void SetController(CameraController controller)
		{
			this.controller = controller;
			this.controller.SetMovementController(this);
			transform.position = controller.Position;
		}
	}
}	