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
			GridComponent component = grid.AddComponent<GridComponent>();
			GridController controller = new GridController();
			component.SetController(controller);

			GameData.Instance.SetGrid(grid);
		}
	}
}
