using System.Collections.Generic;

namespace Ships
{
	public struct Edge
	{
		public Vertex[] Vertices;

		public Edge(Vertex v1, Vertex v2)
		{
			if (v1.Index > v2.Index)
				Vertices = new Vertex[2] { v2, v1 };
			else
				Vertices = new Vertex[2] { v1, v2 };
		}
	}
}
