using UnityEngine;

namespace Workshop
{
	public static class GridFactory
	{
		private static string GRID_OBJECT_NAME = "Grid";
		private static string TILE_OBJECT_NAME = "Tile";

		public static void InitializeGrid()
		{
			GameObject grid = new GameObject(GRID_OBJECT_NAME);
			GridComponent component = grid.AddComponent<GridComponent>();
			GridData data = new GridData();
			GridController controller = new GridController(data.TileCountX, data.TileCountY, data.TileStartLocation, data.MaterialData);
			component.SetController(controller);
		}
	}
}
