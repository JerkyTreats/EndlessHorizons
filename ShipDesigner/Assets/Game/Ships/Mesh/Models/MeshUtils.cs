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

			Dictionary<string, EdgeFinder> edgeFinder = new Dictionary<string, EdgeFinder>();

			for (int i = 0; i < tris.Count; i++ )
			{
				// For the three edges in the triangle, Add or increment the number of times this edge occurs
				for (int n = 0; n < tris[i].Edges.Length; n++)
				{
					string key = "" +  tris[i].Edges[n].Vertices[0].Index + '|' + tris[i].Edges[n].Vertices[1].Index;
					if (edgeFinder.ContainsKey(key))
					{
						EdgeFinder toModify = edgeFinder[key];
						toModify.TimesFound += 1;
						edgeFinder[key] = toModify;
					}
					else
						edgeFinder.Add(key, new EdgeFinder(1, tris[i].Edges[n]));
				}
			}

			// Only edges that have a single edge are added to the Boundary
			foreach(KeyValuePair<string, EdgeFinder> pair in edgeFinder)
			{
				if (pair.Value.TimesFound == 1)
					boundaryEdges.Add(pair.Value.Edge);
			}

			return boundaryEdges;
		}

	}
	
	public struct EdgeFinder
	{
		public int TimesFound;
		public Edge Edge;

		public EdgeFinder(int timesFound, Edge edge)
		{
			TimesFound = timesFound;
			Edge = edge;
		}
	}
}
