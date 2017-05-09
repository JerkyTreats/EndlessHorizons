using UnityEngine;
using Ships.Blueprints;
using Engine;
using Workshop.Grid;
using System;

namespace Ships.Components
{
	public static class ComponentFactory
	{
		/// <summary>
		///  Creates and initializes Ship Component game objects by Component Type
		/// </summary>
		/// <param name="Type">Type of ship component to build</param>
		/// <param name="component">BlueprintComponent containing component information</param>
		public static void CreateComponent(Blueprints.Component Type, BlueprintComponent component)
		{
			iComponentSpawner spawner;
			switch (Type)
			{
				case Blueprints.Component.Tiles:
					spawner = GameData.Instance.Components.TileData.TileTypes[component.Name];
					GameObject spawned = spawner.SpawnObject(new Vector3(component.GridLocation.x, component.GridLocation.y, GameData.Instance.ZAxisItemPlacement));
					GameData.Instance.Blueprint.GetComponent<Blueprint>().MakeParent(spawned);
					return;

				default:
					Debug.LogError(new ArgumentException(string.Format("Cannot create component: [{0}]", Type)));
					return;
			}
		}
	}
}