using System.Collections.Generic;

namespace Ships
{
	public struct Edge
	{
		public Vertex[] Vertices;

		public Edge(Vertex v1, Vertex v2)
		{
			if (v1.MeshIndex > v2.MeshIndex)
				Vertices = new Vertex[2] { v2, v1 };
			else
				Vertices = new Vertex[2] { v1, v2 };
		}
	}
}
