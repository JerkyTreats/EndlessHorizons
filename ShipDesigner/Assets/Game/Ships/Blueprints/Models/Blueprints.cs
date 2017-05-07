using System.Collections.Generic;
using Engine;
using UnityEngine;
using System;

namespace Ships.Blueprints
{
	/// <summary>
	/// Integrated ship component types
	/// </summary>
	public enum Component
	{
		Tiles
	}

	/// <summary>
	/// Model for Blueprints.
	/// 
	/// Has a somewhat complicated Container system. 
	/// Blueprints have a collection of `Component Types`: Tiles, Rooms, etc. 
	///		- This is represented as a List called Containers 
	///	Each `Component Type` has an associated BlueprintComponentContainer
	///		- This includes the Type, ex. "Tiles"
	///		- This includes a List of BlueprintComponents
	///	A BlueprintComponent represents a single component on a single gridtile
	///	All "Tiles" are placed in a BlueprintComponentContainer, which is placed in the Container List.
	/// </summary>
	public class Blueprints
	{
		private string m_fileName { get; set; }
		private string m_name;

		public string Name
		{
			get { return string.IsNullOrEmpty(m_name) ? "Blueprint" : m_name; }
			set { m_name = value; }
		}
		public List<BlueprintComponentContainer> Containers { get; set; } // A collection of Containers
		public Dictionary<Component, BlueprintComponentContainer> ContainerMap { get; set; } // For fast lookup
		
		public Blueprints()
		{
			InitializeComponents(null);
			SetFileName();
		}

		public Blueprints(BlueprintSaveObject data, string fileName)
		{
			if (!string.IsNullOrEmpty(fileName))
				m_fileName = fileName;

			Name = data.Name;
			InitializeComponents(data.Containers);
		}

		void InitializeComponents(List<BlueprintComponentContainer> containers)
		{
			if (containers != null)
			{
				// We don't just replace the List so that entries can be added to the map
				for (int i = containers.Count -1; i>= 0; i--)
				{
					AddToComponentContainer(containers[i]);
				}
			} else // Create new container with each component type
			{
				AddToComponentContainer(new BlueprintComponentContainer(Component.Tiles));
			}
		}

		void AddToComponentContainer(BlueprintComponentContainer container)
		{
			if (Containers == null)
				Containers = new List<BlueprintComponentContainer>();
			if (ContainerMap == null)
				ContainerMap = new Dictionary<Component, BlueprintComponentContainer>();
			if (container == null)
				return;

			Containers.Add(container);
			ContainerMap.Add(container.Key, container);
		}

		/// <summary>
		/// Get a Filename for the blueprint. Intended to be used for filename when saved to disk
		/// </summary>
		/// <returns></returns>
		public string GetFileName()
		{
			if (string.IsNullOrEmpty(m_fileName))
				SetFileName();
			return m_fileName;
		}

		/// <summary>
		/// Updates filename to be used when the blueprint is saved to disk
		/// </summary>
		public void SetFileName()
		{
			string prefix = string.IsNullOrEmpty(Name) ? Name + "_" : "Blueprint_";
			string utcToSeconds = DateTime.Now.ToFileTimeUtc().ToString().Substring(0, 10);
			string newName = string.Format("{0}_{1}.json", prefix, utcToSeconds);
			m_fileName = newName;
		}

		/// <summary>
		/// Returns the blueprint object to be saved to disk.
		/// </summary>
		/// <returns>BlueprintSaveObject containing only the data that will be saved to disk</returns>
		public BlueprintSaveObject GetSaveObject()
		{
			return new BlueprintSaveObject(Name, Containers);
		}

		/// <summary>
		/// Actions to take on Game Initialization
		/// </summary>
		public static void OnGameStart()
		{
			GameData.Instance.Blueprint = BlueprintFactory.CreateBlueprint(null);
		}
	}
}
