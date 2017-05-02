using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Ships.Blueprints
{
	/// <summary>
	/// An object containing all BlueprintComponents of a single type
	/// </summary>
	public class BlueprintComponentContainer
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public Component Key { get; set; }
		public List<BlueprintComponent> Components { get; set; }

		/// <summary>
		/// Constructs a new BlueprintComponent Container
		/// </summary>
		/// <param name="key">The type of Components that wil be contained</param>
		public BlueprintComponentContainer(Component key)
		{
			Key = key;
			Components = new List<BlueprintComponent>();
		}
	}
}
