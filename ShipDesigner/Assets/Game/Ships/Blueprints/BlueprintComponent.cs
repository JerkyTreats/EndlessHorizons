using UnityEngine;

namespace Ships.Blueprints
{
	/// <summary>
	/// Represents a single component in a blueprint
	/// </summary>
	public struct BlueprintComponent
	{
		public Vector3 GridLocation { get; set; }
		public string Name { get; set; }

		/// <summary>
		/// BlueprintComponent constructer. Name is used to retrieve an actual `ObjectData` object
		/// </summary>
		/// <param name="gridLocation">[Column, Row] of the Component on the Grid</param>
		/// <param name="name">Name of the Component</param>
		public BlueprintComponent(Vector3 gridLocation, string name)
		{
			GridLocation = gridLocation;
			Name = name;
		}
	}
}
