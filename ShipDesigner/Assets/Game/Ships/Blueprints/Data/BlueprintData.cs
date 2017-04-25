using SimpleJSON;
using System.Collections.Generic;
using Engine.Utility;
using Engine;
using UnityEngine;

namespace Ships.Blueprints
{
	/// <summary>
	/// Model for Blueprints. Contains 'components' that allows to save|load complex data to disk
	/// </summary>
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

		/// <summary>
		/// Create and attach empty Blueprint object during Game Initalization
		/// </summary>
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
