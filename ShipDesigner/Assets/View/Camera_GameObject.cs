using UnityEngine;
using System.Collections;


namespace View
{
	public class Camera_GameObject : MonoBehaviour
	{
		private Camera m_camera;
		private MainCamera controller;
		private float m_translateSpeed;
		private float m_scrollSpeed;


		public void Initialize(MainCamera camera)
		{
			controller = camera;
			m_translateSpeed = controller.TranslateSpeed;
			m_scrollSpeed = controller.ScrollSpeed;

			SetCamera();
		}

		private void SetCamera()
		{
			m_camera = controller.Camera;
			m_camera.transform.position = controller.Position;
			m_camera.enabled = true;
		}

		// Update is called once per frame
		void Update()
		{
			float newPosition = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * m_scrollSpeed;
			float currentPosition = m_camera.transform.position.z;
			if ((currentPosition + newPosition > controller.Boundary.Z.Min)
				&& (currentPosition + newPosition < controller.Boundary.Z.Max))
			{
				m_camera.transform.Translate(0, 0, newPosition, m_camera.transform);
			}

		}

		void LateUpdate() {
			MoveCamera();
		}

		void MoveCamera()
		{
			float xDirection = Input.GetAxis("Horizontal") * Time.deltaTime * m_scrollSpeed;
			float xPosition = m_camera.transform.position.x;

			float yDirection = Input.GetAxis("Vertical") * Time.deltaTime * m_scrollSpeed;
			float yPosition = m_camera.transform.position.y;

			if ((xDirection < 0 && xPosition < controller.Boundary.X.Min)
				|| (xDirection > 0 && xPosition > controller.Boundary.X.Max))
				xDirection = 0;

			if ((yDirection < 0 && yPosition < controller.Boundary.Y.Min)
				|| (yDirection > 0 && yPosition > controller.Boundary.Y.Max))
				yDirection = 0;

			gameObject.transform.position = gameObject.transform.position + new Vector3(xDirection, yDirection);
		}

		void AddForce(Vector3 axis, float direction)
		{
			float cameraZDistance = m_camera.transform.position.z;
			if (cameraZDistance < 0)
				cameraZDistance *= -1;
			var test = axis * m_translateSpeed * direction * cameraZDistance;
			Debug.Log("force = " + test);
			GetComponent<Rigidbody2D>().MovePosition(axis * m_translateSpeed * direction * cameraZDistance);
		}
	}
}	