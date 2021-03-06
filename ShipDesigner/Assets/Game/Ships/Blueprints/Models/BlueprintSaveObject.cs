﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ships.Blueprints
{
	/// <summary>
	/// Data that is saved/loaded from disk
	/// </summary>
	public class BlueprintSaveObject
	{
		[JsonProperty(PropertyName = "Containers")]
		public List<BlueprintComponentContainer> Containers;
		public string Name;

		public BlueprintSaveObject(string name, List<BlueprintComponentContainer> containers)
		{
			Name = name;
			Containers = containers;
		}
	}
}
