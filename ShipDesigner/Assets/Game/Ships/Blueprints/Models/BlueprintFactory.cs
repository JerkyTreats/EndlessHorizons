using System.IO;
using UnityEngine;
using Newtonsoft.Json;

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
			string path = Path.Combine(BlueprintRepository.DIRECTORY_LOCATION, fileName);
            if (!File.Exists(path))
                return null;
			
			BlueprintSaveObject data = JsonConvert.DeserializeObject<BlueprintSaveObject>(File.ReadAllText(path));
			Blueprints model = new Blueprints(data, fileName);
            GameObject blueprint = new GameObject();

            Blueprint controller = blueprint.AddComponent<Blueprint>();
            controller.Initialize(model);
            return blueprint;
        }
    }
}
