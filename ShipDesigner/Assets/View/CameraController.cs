using UnityEngine;
using Util;

namespace View
{
	public class CameraController
	{
		private IMovementController m_movementController;

		private float m_translateSpeed;
		private float m_scrollSpeed;
		private Vector3 m_position;
		private Boundary m_boundaries;

		public float TranslateSpeed { get { return m_translateSpeed; } }
		public float ScrollSpeed { get { return m_scrollSpeed; } }
		public Vector3 Position { get { return m_position; } }
		public Boundary Boundary { get { return m_boundaries; } }

		public CameraController(float translateSpeed, float scrollSpeed, Vector3 startLocation, Boundary boundary)
		{
			m_translateSpeed = translateSpeed;
			m_scrollSpeed = scrollSpeed;
			m_position = startLocation;
			m_boundaries = boundary;
		}

		public void SetMovementController( IMovementController controller)
		{
			m_movementController = controller;
		}

		public void MoveX(float value)
		{
			value *= m_translateSpeed;
			m_movementController.MoveX(value);
		}

		public void MoveY(float value)
		{
			value *= m_translateSpeed;
			m_movementController.MoveY(value);
		}

		public void MoveZ(float value)
		{
			value *= m_scrollSpeed;
			m_movementController.MoveZ(value);
		}
	}
}
