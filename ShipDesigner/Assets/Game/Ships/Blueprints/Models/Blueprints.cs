using System.Collections.Generic;
using Engine;
using UnityEngine;
using System;

namespace Ships.Blueprints
{
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
		public enum ComponentKey
		{
			Tiles
		}

		private string m_fileName { get; set; }

		public string Name { get; set; }
		public List<BlueprintComponentContainer> Containers { get; set; } // A collection of Containers
		public Dictionary<ComponentKey, BlueprintComponentContainer> ContainerMap { get; set; } // For fast lookup
		
		public Blueprints()
		{
			InitializeComponents();
			SetFileName();
		}

		void InitializeComponents()
		{
			Containers = new List<BlueprintComponentContainer>();
			ContainerMap = new Dictionary<ComponentKey, BlueprintComponentContainer>();

			AddToComponentContainer(ComponentKey.Tiles);
		}

		void AddToComponentContainer(ComponentKey key)
		{
			var container = new BlueprintComponentContainer(key);
			Containers.Add(container);
			ContainerMap.Add(key, container);
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
		/// Create and attach empty Blueprint object during Game Initalization
		/// </summary>
		public static void OnGameStart()
		{
			Blueprints emptyModel = new Blueprints();
			GameObject blueprint = new GameObject();

			blueprint.name = "Blueprint";
			Blueprint component = blueprint.AddComponent<Blueprint>();
			component.Initialize(emptyModel);
			GameData.Instance.Blueprint = blueprint;
		}
	}
}
