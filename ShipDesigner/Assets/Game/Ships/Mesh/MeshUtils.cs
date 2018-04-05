using System.Collections.Generic;
using UnityEngine;
using Engine.Utility;
using Engine;

namespace Ships
{
	public static class MeshUtils
	{
		public static List<Edge> GetBoundaryEdges (List<Triangle> tris)
		{
			List<Edge> boundaryEdges = new List<Edge>();
			Dictionary<string, int> edgeFinder = new Dictionary<string, int>();

			for (int i = 0; i < tris.Count; i++ )
			{
				// For the three edges in the triangle, Add or increment the number of times this edge occurs
				for (int n = 0; n < tris[i].Edges.Length; n++)
				{
					string key = "" +  tris[i].Edges[n].Vertices[0] + '|' + tris[i].Edges[n].Vertices[1];
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
					boundaryEdges.Add(new Edge(int.Parse(key[0]), int.Parse(key[1])));
				}
			}

			return boundaryEdges;
		}

		/// <summary>
		/// Get all the instances a vertex index is shared by an edge
		/// </summary>
		/// <param name="inputEdges">List of edges</param>
		/// <returns>SharedEdge List</returns>
		public static List<SharedEdge> GetSharedEdges(List<Edge> inputEdges, List<Vector3> meshVertices)
		{
			// Dictionary<int, int> map = new Dictionary<int, int>(); // map to sharedEdges.Index for fast lookup
			Dictionary<int, List<BoundaryEdge>> map = new Dictionary<int, List<BoundaryEdge>>();
			List<SharedEdge> sharedEdges = new List<SharedEdge>(); 

			for (int i = 0; i < inputEdges.Count; i++)
			{
				int v1 = inputEdges[i].Vertices[0];
				int v2 = inputEdges[i].Vertices[1];

				if (!map.ContainsKey(v1) && !map.ContainsKey(v2))
				{
					List<BoundaryEdge> be = new List<BoundaryEdge>();
					be.Add(new BoundaryEdge(inputEdges[i]));
					map.Add(v1, be);
					map.Add(v2, be);
					continue;
				}

				if(map.ContainsKey(v1) && !map.ContainsKey(v2))
				{
					List<BoundaryEdge> edges = map[v1];
					for (int n = 0; n < edges.Count; n++)
					{
						Vector3 start = meshVertices[edges[n].Vertices[0]];
						Vector3 end = meshVertices[edges[n].Vertices.Count - 1];
						Vector3 newVertStart = meshVertices[inputEdges[i].Vertices[0]];
						Vector3 newVertEnd = meshVertices[inputEdges[i].Vertices[1]];

						if (IsStraightLine(start, end, newVertStart, newVertEnd))
							MergeBoundaryEdge(edges[n], new BoundaryEdge(inputEdges[i]));
					}
				}
			}
			return sharedEdges;
		}

		private static bool IsStraightLine(Vector3 start, Vector3 end, Vector3 vertexToAdd1, Vector3 vertexToAdd2)
		{
			float result1 = MathUtils.DistanceLineSegmentPoint(start, end, vertexToAdd1);
			float result2 = MathUtils.DistanceLineSegmentPoint(start, end, vertexToAdd2);
			if (!Mathf.Approximately(0, result1) || !Mathf.Approximately(0, result2))
				return false;
			return true;
		}

		private static BoundaryEdge MergeBoundaryEdge(BoundaryEdge edge1, BoundaryEdge edge2)
		{
			BoundaryEdge newBE = new BoundaryEdge();

			// Add edge2 to the end of Edge1
			if (edge1.Vertices[0] == edge2.Vertices[edge2.Vertices.Count-1])
			{
				newBE.Vertices = edge2.Vertices;
				newBE.Vertices.AddRange(edge1.Vertices);
				return newBE;
			}

			// Add edge1 to the end of edge2
			if (edge1.Vertices[edge1.Vertices.Count-1] == edge2.Vertices[0])
			{
				newBE.Vertices = edge1.Vertices;
				newBE.Vertices.AddRange(edge2.Vertices);
				return newBE;
			}
			Engine.Logger.Error("MergeBoundaryEdge did not find matching edges, returning empty BoundaryEdge");
			return newBE;
		}
	}
}
