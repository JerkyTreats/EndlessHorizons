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
			GridData data = new GridData();
			GridController controller = new GridController(data.TileCountX, data.TileCountY, data.TileStartLocation, data.Quad);
			component.SetController(controller);

			GameData.Instance.SetGrid(grid);
		}
	}
}
