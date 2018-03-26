using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
	public struct Edge
	{
		public int[] Vertices;

		public Edge(int v1, int v2)
		{
			if (v1 > v2)
				Vertices = new int[2] { v2, v1 };
			else
				Vertices = new int[2] { v1, v2 };
		}

		public Edge(int[] verts)
		{
			Vertices = verts;
		}
	}

	public struct Triangle
	{
		public Edge[] Edges;

		public Triangle(int vertex1, int vertex2, int vertex3)
		{
			Edges = new Edge[] 
			{
				new Edge( vertex1, vertex2 ),
				new Edge( vertex2, vertex3 ),
				new Edge( vertex1, vertex3 )
			};
		}
	}

	public class MeshBoundary
	{
		public List<Edge> Edges { get; set; }
		public List<Edge> BoundaryEdges { get; set; }

		Dictionary<string, int> edgeFinder;

		public MeshBoundary(List<int> tris)
		{
			BoundaryEdges = new List<Edge>();
			edgeFinder = new Dictionary<string, int>();

			for (int i = 0; i < tris.Count; i += 3)
			{
				Triangle triangle = new Triangle(tris[i], tris[i + 1], tris[i + 2]);

				// For the three edges in the triangle, Add or increment the number of times this edge occurs
				for (int n = 0; n < triangle.Edges.Length; n++)
				{
					string key = "" +  triangle.Edges[n].Vertices[0] + '|' + triangle.Edges[n].Vertices[1];
					if (edgeFinder.ContainsKey(key))
						edgeFinder[key] += 1;
					else
						edgeFinder.Add(key, 1);
				}
			}

			// Only edges that have a single edge are added to the Boundary
			foreach(KeyValuePair<string, int> pair in edgeFinder)
			{
				if (pair.Value == 1)
				{
					string[] key = pair.Key.Split('|');
					BoundaryEdges.Add(new Edge(int.Parse(key[0]), int.Parse(key[1])));
				}
			}
		}
	}
}
