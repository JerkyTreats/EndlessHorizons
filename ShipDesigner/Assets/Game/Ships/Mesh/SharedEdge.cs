using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Engine.Utility;

namespace Ships
{
	public class SharedEdge
	{
		private List<int> m_verticeIndex;
		private List<Edge> m_edges;

		public List<Edge> Edges { get { return m_edges; } }
		public List<int> VerticeIndex { get { return m_verticeIndex; } }
		public int First { get { return m_verticeIndex[0]; } }
		public int Last { get { return m_verticeIndex[m_verticeIndex.Count - 1]; } }

		public SharedEdge()
		{
			m_edges = new List<Edge>();
		}

		public SharedEdge(Edge edge)
		{
			m_edges = new List<Edge>();
			m_edges.Add(edge);
			SetVerticeIndex();
		}

		public void Add(SharedEdge sharedEdge)
		{
			m_edges.AddRange(sharedEdge.Edges);
			SetVerticeIndex();
		}

		public void Insert(SharedEdge sharedEdge)
		{
			m_edges.InsertRange(0, sharedEdge.Edges);
			SetVerticeIndex();
		}

		void SetVerticeIndex()
		{
			HashSet<int> vertices = new HashSet<int>();
			for (int i = 0; i < m_edges.Count; i++)
			{
				vertices.Add(m_edges[i].Vertices[0]);
				vertices.Add(m_edges[i].Vertices[1]);
			}
			m_verticeIndex = new List<int>(vertices);
		}


		public static List<SharedEdge> SharedEdgeFactory(List<Edge> inputEdges, List<Vector3> vertices)
		{
			List<SharedEdge> SharedEdges = new List<SharedEdge>();
			for (int i = 0; i < inputEdges.Count; i++)
			{
				List<SharedEdge> markedForRemoval = new List<SharedEdge>();
				SharedEdge newEdge = new SharedEdge(inputEdges[i]);

				for (int s = 0; s < SharedEdges.Count; s++)
				{
					if (TwoEdgesAreOnSameLine(vertices, SharedEdges[s], inputEdges[i]))
					{
						if (SharedEdges[s].First == inputEdges[i].Vertices[1])
						{
							newEdge.Add(SharedEdges[s]);
							markedForRemoval.Add(SharedEdges[s]);
						}
						else if (SharedEdges[s].Last == inputEdges[i].Vertices[0])
						{
							newEdge.Insert(SharedEdges[s]);
							markedForRemoval.Add(SharedEdges[s]);
						}
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

		static bool TwoEdgesAreOnSameLine(List<Vector3> vertices, SharedEdge toCheckAgainst, Edge toCheck)
		{
			Vector3 edge1First = vertices[toCheckAgainst.First];
			Vector3 edge1Last = vertices[toCheckAgainst.Last];
			Vector3 edge2First = vertices[toCheck.Vertices[0]];
			Vector3 edge2Last = vertices[toCheck.Vertices[1]];

			if (MathUtils.DistanceLineSegmentPoint(edge1First, edge1Last, edge2First) == 0 &&
				MathUtils.DistanceLineSegmentPoint(edge1First, edge1Last, edge2Last) == 0)
				return true;
			return false;
		}
	}
}
