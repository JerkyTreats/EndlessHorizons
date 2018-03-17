using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Engine;
using Engine.Utility;
using System;

namespace Ships.Blueprints
{
    public static class BlueprintFactory
    {
		/// <summary>
		/// Creates a new, empty Blueprint
		/// </summary>
		/// <returns>Blueprint Game Object</returns>
		public static GameObject CreateBlueprint()
		{
			return Spawn(new Blueprints());
		}

		/// <summary>
		/// Creates and initializes a blueprint Game Object by fileName
		/// </summary>
		/// <returns>Blueprint Game Object</returns>
		/// <param name="fileName">Filename as it appears in the Blueprint Folder</param>
        public static GameObject CreateBlueprint(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				Debug.LogError(new NullReferenceException("FileName is null or empty"));
				return CreateBlueprint();
			}

			fileName = Util.EnsureIsJSONFile(fileName); //Ensure the file has .json at the end
			string path = Path.Combine(BlueprintRepository.DIRECTORY_LOCATION, fileName);
			if (!File.Exists(path))
			{
				Debug.LogError(new FileNotFoundException(string.Format("File not found: [{0}]", path)));
				return CreateBlueprint();
			}

			BlueprintSaveObject data = JsonConvert.DeserializeObject<BlueprintSaveObject>(File.ReadAllText(path));
			Blueprints model = new Blueprints(data, fileName);
			return Spawn(model);
		}

		private static GameObject Spawn(Blueprints model)
		{
			GameObject blueprint = new GameObject();
			blueprint.name = model.Name;
			Blueprint controller = blueprint.AddComponent<Blueprint>();
			controller.Initialize(model);
			return blueprint;
		}
	}
}
