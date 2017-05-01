using System.Collections.Generic;

namespace Ships.Blueprints
{
	public class BlueprintSaveObject
	{
		public List<BlueprintComponentContainer> Containers;
		public string Name;

		public BlueprintSaveObject(string name, List<BlueprintComponentContainer> containers)
		{
			Name = name;
			Containers = containers;
		}
	}
}