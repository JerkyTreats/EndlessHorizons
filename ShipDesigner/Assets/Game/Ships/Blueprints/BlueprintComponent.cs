using UnityEngine;

namespace Ships.Blueprints
{
	/// <summary>
	/// Represents a single component in a blueprint
	/// </summary>
	public class BlueprintComponent
	{
		public static string GRID_LOCATION_KEY = "GridLocation";
		public static string NAME_KEY = "Name";

		public GridLocation GridLocation { get; set; }
		public string Name { get; set; }

		/// <summary>
		/// BlueprintComponent constructer. Name is used to retrieve an actual `ObjectData` object
		/// </summary>
		/// <param name="gridLocation">GridLocation object representing the GridTile.Origin the Component is placed in</param>
		/// <param name="name">Name of the Component</param>
		public BlueprintComponent(GridLocation gridLocation, string name)
		{
			GridLocation = gridLocation;
			Name = name;
		}

		/// <summary>
		/// BlueprintComponent constructer. Name is used to retrieve an actual `ObjectData` object
		/// </summary>
		/// <param name="gridLocation">Vector3 GridTile.Origin the Component is placed in</param>
		/// <param name="name">Name of the Component</param>
		public BlueprintComponent(Vector3 gridLocation, string name)
		{
			GridLocation = new GridLocation(gridLocation.x, gridLocation.y, gridLocation.z);
			Name = name;
		}

		public Vector3 GetGridLocation()
		{
			return new Vector3(GridLocation.x, GridLocation.y, GridLocation.z);
		}
	}
}
