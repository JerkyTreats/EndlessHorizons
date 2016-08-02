using UnityEngine;

namespace Workshop
{
	public static class GridFactory
	{
		private static string GRID_OBJECT_NAME = "Grid";
		private static string TILE_OBJECT_NAME = "Tile";

		public static void InitializeGrid()
		{
			GridData data = new GridData();
			GameObject grid = CreateGridPlane(data.TileStartLocation, data.Vertices, data.UVs, data.SpriteData.Texture, data.Normals);
			GridComponent component = grid.AddComponent<GridComponent>();
			GridController controller = GetGridController(data);
			component.SetController(controller);
		}

		static GameObject CreateGridPlane(Vector3 startLocation, Vector3[] verts, Vector2[] uvs, Texture texture, Vector3[] normals)
		{
			GameObject grid = new GameObject(GRID_OBJECT_NAME);
			grid.transform.position = startLocation;

			//Mesh mesh = new Mesh();

			var meshFilter = grid.AddComponent<MeshFilter>();
			var renderer = grid.AddComponent<MeshRenderer>();
			renderer.material.mainTexture = texture;



			Mesh mesh = new Mesh();
			mesh.vertices = verts;
			mesh.normals = normals;
			mesh.uv = uvs;
			//mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(1.5f, 0), new Vector2(1.5f, 1.5f), new Vector2(0, 1.5f) };
			mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
			meshFilter.mesh = mesh;
			mesh.RecalculateNormals();
			return grid;
		}

		static GridController GetGridController(GridData gi)
		{
			return new GridController(gi.TileCountX, gi.TileCountY, gi.TileStartLocation, gi.SpriteData);
		}
	}
}
