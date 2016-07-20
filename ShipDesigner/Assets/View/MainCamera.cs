using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace View
{
	public class MainCamera
	{
		private static string GAME_OBJECT_NAME = "MainCamera";

		private GameObject m_CameraGameObject;
		private Camera m_CameraComponent;
		private float m_translateSpeed;
		private float m_scrollSpeed;
		private Vector3 m_position;
		private Boundary m_boundaries;

		public float TranslateSpeed { get { return m_translateSpeed; } }
		public float ScrollSpeed { get { return m_scrollSpeed; } }
		public Vector3 Position { get { return m_position; } }
		public Boundary Boundary { get { return m_boundaries; } }
		public Camera Camera { get { return m_CameraComponent; } }

		public MainCamera(float translateSpeed, float scrollSpeed, Vector3 startLocation, Boundary boundary)
		{
			m_translateSpeed = translateSpeed;
			m_scrollSpeed = scrollSpeed;
			m_position = startLocation;
			m_boundaries = boundary;

			InitializeGameObject();
		}

		private void InitializeGameObject()
		{
			m_CameraGameObject = new GameObject(GAME_OBJECT_NAME);
			var rigidbody = m_CameraGameObject.AddComponent<Rigidbody2D>();
			rigidbody.isKinematic = true;
			m_CameraComponent = m_CameraGameObject.AddComponent<Camera>();
			var obj = m_CameraGameObject.AddComponent<Camera_GameObject>();
			obj.Initialize(this);
		}
	}
}
