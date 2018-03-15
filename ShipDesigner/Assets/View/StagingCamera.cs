using UnityEngine;
using Engine.Utility;

namespace View
{
	public class StagingCamera : MonoBehaviour
	{
		StangingCameras m_model;

		public void Initialize(StangingCameras model)
		{
			m_model = model;

			gameObject.AddComponent<UnityEngine.Camera>();
			gameObject.tag = "MainCamera"; // sets Camera.main property
			
			// Set starting positions
			transform.position = m_model.StartLocation;
			transform.eulerAngles = m_model.StartRotation;

			Debug.Log(string.Format("INIT:\nRadius: [{0}]", m_model.BoundaryRadius));
		}

		void FixedUpdate()
		{
			if (Input.GetButton("Horizontal"))
			{
				var input = Input.GetAxis("Horizontal") * Time.deltaTime * m_model.TranslateSpeed;
				Move(new Vector3(input, 0));
			}
			if (Input.GetButton("Vertical"))
			{
				var input = Input.GetAxis("Vertical") * Time.deltaTime * m_model.TranslateSpeed;
				Move(new Vector3(0, input));
			}
			if (Input.GetButton("Mouse ScrollWheel"))
			{
				var input = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * m_model.ScrollSpeed;
				Move(new Vector3(0, 0, input));
			}
			if (Input.GetButton("Rotate"))
			{
				var input = Input.GetAxis("Rotate") * Time.deltaTime;
				Vector3 focus = transform.position + Vector3.forward;
				transform.RotateAround(focus, Vector3.up, (input * m_model.RotateSpeed) * Time.deltaTime);
			}
		}

		void Move(Vector3 moveAmount)
		{
			Vector3 newLocation = transform.TransformDirection(moveAmount);
			float oldDistance = Vector3.Distance(m_model.StartLocation, transform.position);
			float newDistance = Vector3.Distance(m_model.StartLocation, (transform.position + newLocation));
			if (newDistance < m_model.BoundaryRadius || (newDistance <= oldDistance))
				transform.position += newLocation;
		}
	}
}
