using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Blueprints
{
	public class Blueprint : MonoBehaviour
	{
		private BlueprintData m_model;

		public List<BlueprintComponent> Tiles;
		public List<BlueprintComponent> Doors;
		public List<BlueprintComponent> Equipment;
		public List<BlueprintComponent> Rooms;

		public void Initialize(BlueprintData model)
		{
			m_model = model;

			Tiles = m_model.Tiles;
			Doors = m_model.Doors;
			Equipment = m_model.Equipment;
			Rooms = m_model.Rooms;
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
					return MatchGridLocations(Tiles, gridPosition);
				default:
					throw new NotImplementedException("Type of [" + type + "] not implemented as blue.isOccupied object");
			}
		}

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
