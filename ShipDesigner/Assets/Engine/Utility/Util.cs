using UnityEngine;
using System.IO;

namespace Engine.Utility
{
	public static class Util
	{
		/// <summary>
		/// Attaches necessary components to a GameObject to render a mesh 
		/// </summary>
		/// <param name="gameObject"></param>
		/// <param name="materialData"></param>
		public static void RenderMesh(GameObject gameObject, MaterialData materialData)
		{
			var renderer = gameObject.AddComponent<MeshRenderer>();
			renderer.material.mainTexture = materialData.Texture;

			var meshFilter = gameObject.AddComponent<MeshFilter>();
			Mesh mesh = new Mesh();
			mesh.vertices = materialData.Vertices;
			mesh.normals = materialData.Normals;
			mesh.uv = materialData.UVs;
			mesh.triangles = materialData.Triangles;
			meshFilter.mesh = mesh;
			mesh.RecalculateNormals();
		}

		/// <summary>
		/// Custom path combiner because .NET 3.5 doesn't have it- Unity only works on 3.5 ¯\_(ツ)_/¯
		/// </summary>
		/// <param name="first"></param>
		/// <param name="others"></param>
		public static string CombinePath(string first, params string[] others)
		{
			string path = first;
			foreach (string section in others)
			{
				path = Path.Combine(path, section);
			}
			return path;
		}
	}
}
