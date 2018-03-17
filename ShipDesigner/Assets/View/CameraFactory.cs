using System;
using Engine.Utility;
using UnityEngine;
using SimpleJSON;
using System.IO;
using Newtonsoft.Json;

namespace View
{
	/// <summary>
	/// Creates the Camera objects
	/// </summary>
	public class CameraFactory
	{
		/// <summary>
		/// Create the main camera for the staging area
		/// </summary>
		public static void BuildCamera()
		{
			StangingCameras model = BuildModel();

			GameObject cameraObject = new GameObject("MainCamera");
			cameraObject.SetActive(false);

			var camComponent = cameraObject.AddComponent<StagingCamera>();
			camComponent.Initialize(model);
			cameraObject.SetActive(true);
		}
		
		// Deserialize camera.json data and return model object
		static StangingCameras BuildModel()
		{
			JsonSerializer serializer = new JsonSerializer();

			using (StreamReader sw = new StreamReader(Util.CombinePath(Directory.GetCurrentDirectory(), "Assets", "View", "Camera.json")))
			using (JsonReader reader = new JsonTextReader(sw))
			{
				return serializer.Deserialize<StangingCameras>(reader);
			}
		}
	}
}
