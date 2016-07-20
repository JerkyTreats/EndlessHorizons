using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace View
{
	public class CameraController
	{
		private static string GAME_OBJECT_NAME = "Camera";

		private ICameraMovement m_movementController;

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

		public void SetMovementController( ICameraMovement controller)
		{
			m_movementController = controller;
		}


		public void Move(Vector3 currentPosition, float x, float y, float z)
		{
			x *= m_translateSpeed;
			y *= m_translateSpeed;
			z *= m_translateSpeed;

			float newPositionX = currentPosition.x + x;
			float newPositionY = currentPosition.y + y;
			float newPositionZ = currentPosition.z + z;

			if (newPositionX < m_boundaries.X.Min || newPositionX > m_boundaries.X.Max)
				x = 0;
			if (newPositionY < m_boundaries.Y.Min || newPositionY > m_boundaries.Y.Max)
				y = 0;
			if (newPositionZ < m_boundaries.Z.Min || newPositionZ > m_boundaries.Z.Max)
				z = 0;

			if (x != 0 || y != 0 || z != 0)
				m_movementController.Move(x, y, z);
		}
	}
}
