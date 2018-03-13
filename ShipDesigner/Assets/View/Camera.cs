using UnityEngine;
using Engine.Utility;

namespace View
{
	public class Camera : MonoBehaviour
	{
		Cameras m_model;

		public void Initialize(Cameras model)
		{
			m_model = model;

			transform.position = m_model.StartLocation;
			transform.eulerAngles = m_model.StartRotation;
		}

		void FixedUpdate()
		{
			if (Input.GetButton("Horizontal"))
			{
				var input = Input.GetAxis("Horizontal") * Time.deltaTime * m_model.TranslateSpeed;
				transform.position += transform.TransformDirection(new Vector3(input, 0));
			}
			if (Input.GetButton("Vertical"))
			{
				var input = Input.GetAxis("Vertical") * Time.deltaTime * m_model.TranslateSpeed;
				transform.position += transform.TransformDirection(new Vector3(0, input));
			}
			if (Input.GetButton("Mouse ScrollWheel"))
			{
				var input = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * m_model.ScrollSpeed;
				transform.position += transform.TransformDirection(new Vector3(0, 0, input));
			}
			if (Input.GetButton("Rotate"))
			{
				var input = Input.GetAxis("Rotate") * Time.deltaTime;
				Vector3 focus = transform.position + Vector3.forward;
				transform.RotateAround(focus, Vector3.up, (input * m_model.RotateSpeed) * Time.deltaTime);
			}
		}
	}
}
