using UnityEngine;
using Engine;

namespace Workshop.Grid
{
	public static class GridFactory
	{
		private static string GRID_OBJECT_NAME = "Grid";

		public static void InitializeGrid()
		{
			GameObject grid = new GameObject(GRID_OBJECT_NAME);
			CustomGrid component = grid.AddComponent<CustomGrid>();
			component.Initialize(new Grids());

			GameData.Instance.SetGrid(grid);
		}
	}
}
