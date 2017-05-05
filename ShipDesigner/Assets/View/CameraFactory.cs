using System;
using Engine.Utility;
using UnityEngine;
using SimpleJSON;
using System.IO;

namespace View
{
	public class CameraFactory
	{
		private static string FILE_NAME = "Camera.json";
		private JSONNode JsonValues;

		private float m_translateSpeed;
		private float m_scrollSpeed;
		private Vector3 m_position;
		private Boundary m_boundary;

		public float TranslateSpeed { get { return m_translateSpeed; } }
		public float ScrollSpeed { get { return m_scrollSpeed; } }
		public Vector3 Position { get { return m_position; } }
		public Boundary Boundary { get { return m_boundary; } }


		public static void BuildCamera()
		{
			GameObject cameraObject = new GameObject("MainCamera");
			cameraObject.SetActive(false);

			cameraObject.AddComponent<Camera>();
			cameraObject.tag = "MainCamera"; // sets Camera.main property
			var camComponent = cameraObject.AddComponent<CameraComponent>();
			camComponent.SetController(GetCameraController());
			cameraObject.SetActive(true);
		}

		public static CameraController GetCameraController()
		{
			CameraFactory cf = new CameraFactory();
			return new CameraController(cf.TranslateSpeed, cf.ScrollSpeed, cf.Position, cf.Boundary);
		}

		public CameraFactory()
		{
			JsonValues = JSONTools.GetJSONNode(GetGridInformation());
			m_translateSpeed = JsonValues["TranslateSpeed"].AsFloat;
			m_scrollSpeed = JsonValues["ScrollSpeed"].AsFloat;
			m_position = GetStartPosition();
			m_boundary = GetBoundary();
		}

		private string GetGridInformation()
		{
			return Util.CombinePath(Application.streamingAssetsPath, "View", FILE_NAME);
		}

		private Vector3 GetStartPosition()
		{
			string key = "StartLocation";
			return new Vector3(
				JsonValues[key]["x"].AsFloat,
				JsonValues[key]["y"].AsFloat,
				JsonValues[key]["z"].AsFloat);
		}

		private Boundary GetBoundary()
		{
			string key = "Boundaries";
			return new Boundary(
				JsonValues[key]["x"]["min"].AsFloat,
				JsonValues[key]["x"]["max"].AsFloat,

				JsonValues[key]["y"]["min"].AsFloat,
				JsonValues[key]["y"]["max"].AsFloat,
				
				JsonValues[key]["z"]["min"].AsFloat,
				JsonValues[key]["z"]["max"].AsFloat
				);
		}
	}
}
