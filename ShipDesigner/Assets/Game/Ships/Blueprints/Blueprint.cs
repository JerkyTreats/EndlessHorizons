using Engine;
using Newtonsoft.Json;
using Ships.Components;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Ships.Blueprints
{
	public class Blueprint : MonoBehaviour
	{
		private Blueprints m_model;

		/// <summary>
		/// Hook up the Blueprint Model (BlueprintData) to the Blueprint Game Object Component
		/// </summary>
		/// <param name="model">BlueprintData object to act as the Components Model</param>
		public void Initialize(Blueprints model)
		{
			m_model = model;
		}

		/// <summary>
		/// Determines if a provided gridLocation already has an object of the same type
		/// </summary>
		/// <param name="key">The type of Component</param>
		/// <param name="gridPosition">The gridPosition to match against</param>
		/// <returns></returns>
		public bool isOccupied(Component key, Vector3 gridPosition)
		{
			var componentList = m_model.ContainerMap[key];
			if (componentList.Components.Count == 0) { return false; }

			for (int i = componentList.Components.Count - 1; i >= 0; i--)
			{
				Vector2 blueprintPosition = componentList.Components[i].GetGridLocation();

                // Find approx values as floats are rarely exactly equal
				if (Mathf.Approximately(gridPosition.x, blueprintPosition.x) && (Mathf.Approximately(gridPosition.y, blueprintPosition.y)))
					return true;
			}

            return false;
		}

		/// <summary>
		/// Add a BlueprintComponent representing a Tile to the Blueprint
		/// </summary>
		/// <param name="key">The type of Component</param>
		/// <param name="component">The BlueprintComponent object to Add</param>
		public void Add(Component key, BlueprintComponent component)
		{
			m_model.ContainerMap[key].Components.Add(component);
		}

		/// <summary>
		/// Converts the Blueprint to JSON, saves to disk 
		/// </summary>
		public void Save()
		{
			if (string.IsNullOrEmpty(m_model.Name))
			{
				m_model.Name = "Blueprint";
				m_model.SetFileName();
			}

			string path = Path.Combine(BlueprintRepository.DIRECTORY_LOCATION, m_model.GetFileName());
			JsonSerializer serializer = new JsonSerializer();

			using (StreamWriter sw = new StreamWriter(path))
				using(JsonWriter writer = new JsonTextWriter(sw))
				{
				    serializer.Serialize(writer, m_model.GetSaveObject());
				}
		}

		public void Load(string fileName)
		{
			BlueprintFactory.ReplaceActiveBlueprint(fileName);
		}

		/// <summary>
		/// Create and Initialize all Ship Components saved in the Blueprint
		/// </summary>
		public void SpawnChildren()
		{
			// For each type of container (Tiles, Doors, etc)
			for (int z = m_model.Containers.Count - 1; z >= 0; z--)
			{
				// For each component saved in the container
				for (int y = m_model.Containers[z].Components.Count -1; y >= 0; y--)
				{
					ComponentFactory.CreateComponent(m_model.Containers[z].Key, m_model.Containers[z].Components[y]);
				}
			}

		}
	}
}
