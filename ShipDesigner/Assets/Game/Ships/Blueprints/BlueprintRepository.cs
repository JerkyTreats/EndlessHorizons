using Engine.Utility;
using Engine;
using System.Collections.Generic;

namespace Ships.Blueprints
{
	public class BlueprintRepository : DataRepository
	{
		private static string[] relativePath = new string[] { "Assets", "Game", "Ships", "Blueprints", "Data" };
		public static string DIRECTORY_LOCATION = Util.GetRelativePath(relativePath);

		public Dictionary<string, Blueprints> Blueprints;

		public BlueprintRepository()
		{
			Blueprints = new Dictionary<string, Blueprints>();
			BuildRepository(DIRECTORY_LOCATION, Blueprints);
		}
	}
}
