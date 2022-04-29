using System.Collections.Generic;
using UnityEngine;
using Engine.Utility;

namespace Ships
{
	public class SharedEdge
	{
		private List<Vertex> m_verticeIndex;
		private List<Edge> m_edges;

		public List<Edge> Edges { get { return m_edges; } }
		public List<Vertex> Vertices { get { return m_verticeIndex; } }
		public Vertex First { get { return m_verticeIndex[0]; } }
		public Vertex Last { get { return m_verticeIndex[m_verticeIndex.Count - 1]; } }

		public SharedEdge(Edge edge)
		{
			m_edges = new List<Edge>();
			m_edges.Add(edge);
			SetVerticeIndex();
		}

		public bool Merge(SharedEdge toMerge)
		{
			if (First.Index == toMerge.Last.Index)
				m_edges.InsertRange(0, toMerge.m_edges);
			else if (Last.Index == toMerge.First.Index)
				m_edges.AddRange(toMerge.m_edges);
			else
				return false;
			SetVerticeIndex();
			return true;
		}

		void SetVerticeIndex()
		{
			HashSet<Vertex> vertices = new HashSet<Vertex>();
			for (int i = 0; i < m_edges.Count; i++)
			{
				vertices.Add(m_edges[i].Vertices[0]);
				vertices.Add(m_edges[i].Vertices[1]);
			}
			m_verticeIndex = new List<Vertex>(vertices);
		}


		public static List<SharedEdge> SharedEdgeFactory(List<Edge> inputEdges)
		{
			List<SharedEdge> SharedEdges = new List<SharedEdge>();
			for (int i = 0; i < inputEdges.Count; i++)
			{
				List<SharedEdge> markedForRemoval = new List<SharedEdge>();
				SharedEdge newEdge = new SharedEdge(inputEdges[i]);

				for (int s = 0; s < SharedEdges.Count; s++)
				{
					if (TwoEdgesAreOnSameLine(SharedEdges[s], inputEdges[i]))
					{
						if (newEdge.Merge(SharedEdges[s]))
							markedForRemoval.Add(SharedEdges[s]);
					}
				}

				for (int e = 0; e < markedForRemoval.Count; e++)
				{
					SharedEdges.Remove(markedForRemoval[e]);
				}

				SharedEdges.Add(newEdge);
			}
			return SharedEdges;
		}

		static bool TwoEdgesAreOnSameLine(SharedEdge toCheckAgainst, Edge toCheck)
		{
			Vector3 edge1First = toCheckAgainst.First.Position;
			Vector3 edge1Last = toCheckAgainst.Last.Position;

			if (MathUtils.DistanceLineSegmentPoint(edge1First, edge1Last, toCheck.Vertices[0].Position) == 0 &&
				MathUtils.DistanceLineSegmentPoint(edge1First, edge1Last, toCheck.Vertices[1].Position) == 0)
				return true;
			return false;
		}
	}
}
