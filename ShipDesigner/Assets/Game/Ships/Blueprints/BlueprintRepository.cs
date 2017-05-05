using UnityEngine;
using Engine;
using System.Collections.Generic;
using System.IO;

namespace Ships.Blueprints
{
	public class BlueprintRepository : DataRepository
	{
		public static string DIRECTORY_LOCATION = Path.Combine(Application.streamingAssetsPath, "Blueprints");

		public Dictionary<string, Blueprints> Blueprints;

		public BlueprintRepository()
		{
			Blueprints = new Dictionary<string, Blueprints>();
			BuildRepository(DIRECTORY_LOCATION, Blueprints);
		}
	}
}
