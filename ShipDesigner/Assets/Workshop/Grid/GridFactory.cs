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
			GridController controller = BuildGrid();
			component.SetController(controller);
			BuildTiles(component, controller);
		}

		static GridController BuildGrid()
		{
			GridData gi = new GridData();
			return new GridController(gi.TileCountX, gi.TileCountY, gi.TileStartLocation, gi.SpriteData);
		}

		static void BuildTiles(GridComponent gridComponent, GridController gridController)
		{
			for (int i = 0; i < gridController.Tiles.Count; i++)
			{
				GameObject tile = new GameObject(TILE_OBJECT_NAME);
				TileComponent component = tile.AddComponent<TileComponent>();
				component.SetController(gridController.Tiles[i]);
				tile.transform.parent = gridComponent.transform;
			}
		}

	}
}
