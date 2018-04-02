using System.Collections.Generic;
using UnityEngine;

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
		public static List<SharedEdge> GetSharedEdges(List<Edge> inputEdges)
		{
			Dictionary<int, int> map = new Dictionary<int, int>(); // map to sharedEdges.Index for fast lookup
			List<SharedEdge> sharedEdges = new List<SharedEdge>(); 

			for (int i = 0; i < inputEdges.Count; i++)
			{
				//verts 1 and 2
				for (int n = 0; n <= 1; n++)
				{
					int vertIndex = inputEdges[i].Vertices[n];

					if (!map.ContainsKey(vertIndex))
					{
						map.Add(vertIndex, sharedEdges.Count);
						sharedEdges.Add(new SharedEdge(vertIndex, inputEdges[i]));
					}
					else
						sharedEdges[map[vertIndex]].Edges.Add(inputEdges[i]);
				}
			}

			return sharedEdges;
		}
	}
}
