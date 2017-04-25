using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Blueprints
{
	public class Blueprint : MonoBehaviour
	{
		private BlueprintData m_model;

		/// <summary>
		/// Hook up the Blueprint Model (BlueprintData) to the Blueprint Game Object Component
		/// </summary>
		/// <param name="model">BlueprintData object to act as the Components Model</param>
		public void Initialize(BlueprintData model)
		{
			m_model = model;
		}

		/// <summary>
		/// Determines if a provided gridLocation already has an object of the same type
		/// </summary>
		/// <param name="type">The component type as a string</param>
		/// <param name="gridPosition">The gridPosition to match against</param>
		/// <returns></returns>
		public bool isOccupied(string type, Vector3 gridPosition)
		{
			switch (type)
			{
				case "tile":
					return MatchGridLocations(m_model.Tiles, gridPosition);
				default:
					throw new NotImplementedException("Type of [" + type + "] not implemented as blueprint.isOccupied object");
			}
		}

		/// <summary>
		/// Add a BlueprintComponent representing a Tile to the Blueprint
		/// </summary>
		/// <param name="component">The BlueprintComponent to Add</param>
		public void AddTile(BlueprintComponent component)
		{
			m_model.Tiles.Add(component);
		}

		/// <summary>
		/// Given the list to loop through, find if a provided Vector3 matches the BlueprintComponents.GridLocation
		/// </summary>
		/// <param name="list">One of the Blueprints Models BlueprintComponent lists types</param>
		/// <param name="gridPosition">This should match a GridTile.origin Vector3 position</param>
		/// <returns></returns>
		bool MatchGridLocations(List<BlueprintComponent> list, Vector3 gridPosition)
		{
			if (list.Count == 0) { return false; }

			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (gridPosition.Equals(list[i].GridLocation))
				{
					return true;
				}
			}
			return false;
		}
	}
}
