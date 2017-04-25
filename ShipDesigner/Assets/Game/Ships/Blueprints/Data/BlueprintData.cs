using SimpleJSON;
using System.Collections.Generic;
using Engine.Utility;
using Engine;
using UnityEngine;

namespace Ships.Blueprints
{
	public class BlueprintData
	{
		public List<BlueprintComponent> Tiles { get; set; }
		public List<BlueprintComponent> Doors { get; set; }
		public List<BlueprintComponent> Equipment { get; set; }
		public List<BlueprintComponent> Rooms { get; set; }

		public BlueprintData()
		{
			Tiles = new List<BlueprintComponent>();
			Doors = new List<BlueprintComponent>();
			Equipment = new List<BlueprintComponent>();
			Rooms = new List<BlueprintComponent>();
		}

		public static void OnGameStart()
		{
			BlueprintData emptyModel = new BlueprintData();
			GameObject blueprint = new GameObject();

			blueprint.name = "Blueprint";
			Blueprint component = blueprint.AddComponent<Blueprint>();
			component.Initialize(emptyModel);
			GameData.Instance.Blueprint = blueprint;
		}
	}
}
