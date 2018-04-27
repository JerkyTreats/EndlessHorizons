using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Ships
{
	public struct Vertex
	{
		public int Index;
		public Vector3 Position;
		public Vector3 Normal;
		public Vector2 UV;

		public Vertex(int index, Vector3 position, Vector3 normal, Vector2 uv)
		{
			Index = index;
			Position = position;
			Normal = normal;
			UV = uv;
		}
	}

	public static class VertexFactory
	{
		public static List<Vertex> GetVertexList(Vector3[] positions, Vector3[] normals, Vector2[] uvs)
		{
			List<Vertex> vertices = new List<Vertex>();
			for (int i = 0; i < positions.Length; i++)
			{
				vertices.Add(new Vertex(i, positions[i], normals[i], uvs[i]));
			}
			return vertices;
		}
	}
}
