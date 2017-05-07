using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Engine;

namespace Ships.Blueprints
{
    public static class BlueprintFactory
    {
		/// <summary>
		/// Creates and initializes a blueprint Game Object by fileName
		/// </summary>
		/// <returns>Blueprint Game Object</returns>
		/// <param name="fileName">Filename as it appears in the Blueprint Folder</param>
        public static GameObject CreateBlueprint(string fileName)
        {
			Blueprints model;
			if (string.IsNullOrEmpty(fileName))
				model = new Blueprints();
			else
			{
				string path = Path.Combine(BlueprintRepository.DIRECTORY_LOCATION, fileName);
				if (File.Exists(path))
				{
					BlueprintSaveObject data = JsonConvert.DeserializeObject<BlueprintSaveObject>(File.ReadAllText(path));
					model = new Blueprints(data, fileName);
				}
				else
				{
					model = new Blueprints();
				}
			}

			GameObject blueprint = new GameObject();
			blueprint.name = model.Name;
			Blueprint controller = blueprint.AddComponent<Blueprint>();
            controller.Initialize(model);
            return blueprint;
        }

		/// <summary>
		/// Creates a new Blueprint Game Object, updates the GameData instance, and spawns all blueprint components
		/// </summary>
		public static void ReplaceActiveBlueprint(string fileName)
		{
			GameObject newBlueprint = CreateBlueprint(fileName);

			Engine.Utility.Util.DestroyGameObjectFamily(GameData.Instance.Blueprint);
			GameData.Instance.Blueprint = newBlueprint;

			Blueprint controller = newBlueprint.GetComponent<Blueprint>();
			controller.SpawnChildren();
		}
    }
}
