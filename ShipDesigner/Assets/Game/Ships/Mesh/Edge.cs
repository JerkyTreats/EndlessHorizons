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

	public class SharedEdge
	{
		public List<int> VerticeIndex { get; set; }
		public int First { get { return VerticeIndex[0]; } }
		public int Last {  get { return VerticeIndex[VerticeIndex.Count - 1]; } }

		public SharedEdge() { }

		public SharedEdge(Edge edge)
		{
			VerticeIndex = new List<int>(edge.Vertices);
		}
	}
}
