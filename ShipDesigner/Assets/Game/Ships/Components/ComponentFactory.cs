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
			GameObject gameObject;
			switch (Type)
			{
				case Blueprints.Component.Tiles:
					TileData model = GameData.Instance.Components.TileData.TileTypes[component.Name];
					gameObject = TileFactory.BuildTile(model);
					break;

				default:
					Debug.LogError(new ArgumentException(string.Format("Cannot create component: [{0}]", Type)));
					gameObject = new GameObject();
					break;
			}
			float z = GameData.Instance.Grid.GetComponent<Grid>().ZAxisItemPlacement;
			gameObject.transform.position = new Vector3(component.GridLocation.x, component.GridLocation.y, z);
			gameObject.transform.parent = GameData.Instance.Blueprint.transform;
		}
	}
}