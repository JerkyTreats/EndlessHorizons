using System.Collections.Generic;

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
	}

	public struct SharedEdge
	{
		public int SharedIndex;
		public List<Edge> Edges;

		public SharedEdge(int sharedIndex, Edge edge)
		{
			SharedIndex = sharedIndex;
			Edges = new List<Edge>();
			Edges.Add(edge);
		} 
	}

	public struct BoundaryEdge
	{
		public List<int> Vertices;

		public BoundaryEdge(Edge edge)
		{
			Vertices = new List<int>(edge.Vertices);
		}
	}
}
