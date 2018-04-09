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
	}
}
