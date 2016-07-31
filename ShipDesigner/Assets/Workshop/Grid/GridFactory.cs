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
			GridController controller = GetGridController();
			component.SetController(controller);
		}

		static GridController GetGridController()
		{
			GridData gi = new GridData();
			return new GridController(gi.TileCountX, gi.TileCountY, gi.TileStartLocation, gi.SpriteData);
		}
	}
}
