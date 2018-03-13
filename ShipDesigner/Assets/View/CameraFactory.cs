using System;
using Engine.Utility;
using UnityEngine;
using SimpleJSON;
using System.IO;
using Newtonsoft.Json;

namespace View
{
	public class CameraFactory
	{
		public static void BuildCamera()
		{
			GameObject cameraObject = new GameObject("MainCamera");
			cameraObject.SetActive(false);

			cameraObject.AddComponent<UnityEngine.Camera>();
			cameraObject.tag = "MainCamera"; // sets Camera.main property
			var camComponent = cameraObject.AddComponent<Camera>();
			camComponent.Initialize(BuildModel());
			cameraObject.SetActive(true);
		}
		

		public static Cameras BuildModel()
		{
			JsonSerializer serializer = new JsonSerializer();

			using (StreamReader sw = new StreamReader(Util.CombinePath(Directory.GetCurrentDirectory(), "Assets", "View", "Camera.json")))
			using (JsonReader reader = new JsonTextReader(sw))
			{
				return serializer.Deserialize<Cameras>(reader);
			}
		}
	}
}
