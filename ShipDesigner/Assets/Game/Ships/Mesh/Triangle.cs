using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
	public class Triangle
	{
		public Vertex[] Vertices;
		public Edge[] Edges;
		public int Index;

		public Triangle(Vertex vertex1, Vertex vertex2, Vertex vertex3, int index)
		{
			Index = index;
			Edges = new Edge[3]
			{
				new Edge( vertex1, vertex2 ),
				new Edge( vertex2, vertex3 ),
				new Edge( vertex1, vertex3 )
			};

			Vertices = new Vertex[3]
			{
				vertex1,
				vertex2,
				vertex3
			};
		}

		public static List<Triangle> GetTriangleList(int[] triangles, List<Vertex> vertices)
		{
			List<Triangle> tris = new List<Triangle>();
			for (int i = 0; i < triangles.Length; i += 3)
			{
				tris.Add(
					new Triangle(
					vertices[triangles[i]], 
					vertices[triangles[i + 1]], 
					vertices[triangles[i + 2]], i
				));
			}
			return tris;
		}

		public static int[] GetTriangleArray(List<Triangle> triangles)
		{
			int[] tris = new int[triangles.Count * 3];

			for (int i = 0; i < triangles.Count; i++)
			{
				Triangle thisTri = triangles[i];
				int index = thisTri.Index;

				tris[index] = thisTri.Vertices[0].Index;
				tris[index + 1] = thisTri.Vertices[1].Index;
				tris[index + 2] = thisTri.Vertices[2].Index;
			}

			return tris;
		}
	}
}
