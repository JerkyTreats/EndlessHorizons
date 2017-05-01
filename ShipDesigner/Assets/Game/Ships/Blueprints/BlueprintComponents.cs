using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Ships.Blueprints
{
	public class BlueprintComponentContainer
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public Blueprints.ComponentKey Key { get; set; }
		public List<BlueprintComponent> Components { get; set; }

		public BlueprintComponentContainer(Blueprints.ComponentKey key)
		{
			Key = key;
			Components = new List<BlueprintComponent>();
		}
	}
}
