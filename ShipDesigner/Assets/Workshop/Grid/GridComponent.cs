using UnityEngine;
using System.Collections;

namespace Workshop.Grid
{
	public class GridComponent : MonoBehaviour
	{
		private GridController controller;
		private SpriteRenderer Renderer;

		public void SetController (GridController controller)
		{
			this.controller = controller;
			transform.position = controller.StartLocation;
			RenderGrid();
		}

		void RenderGrid()
		{
			var meshFilter = gameObject.AddComponent<MeshFilter>();
			var renderer = gameObject.AddComponent<MeshRenderer>();
			renderer.material.mainTexture = controller.MaterialData.Texture;

			Mesh mesh = new Mesh();
			mesh.vertices = controller.MaterialData.Vertices;
			mesh.normals = controller.MaterialData.Normals;
			mesh.uv = controller.MaterialData.UVs;
			mesh.triangles = controller.MaterialData.Triangles;
			meshFilter.mesh = mesh;
			mesh.RecalculateNormals();
		}
	}
}
