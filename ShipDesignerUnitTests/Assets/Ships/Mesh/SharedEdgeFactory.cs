using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using Engine.Utility;

namespace Ships
{
	public class SharedEdgeFactory
	{
		Dictionary<int, List<SharedEdge>> Map;
		List<Vector3> MeshVertices;

		public SharedEdgeFactory(List<Vector3> meshVertices)
		{
			Map = new Dictionary<int, List<SharedEdge>>();
			MeshVertices = meshVertices;
		}

		/// <summary>
		/// Connect an unsorted list of Edges into a unique set of SharedEdges if they are part of the same line
		/// </summary>
		/// <param name="inputEdges"></param>
		/// <param name="meshVertices"></param>
		/// <returns></returns>
		public HashSet<SharedEdge> GetSharedEdges(List<Edge> inputEdges, List<Vector3> meshVertices)
		{
			// This is a bit of a monster, and might be expensive/poorly thought out.
			// We determine what straight, unbroken lines (SharedEdge) each Edge Vertex are part of
			// We add those vertices to a dictionary, its value a list of SharedEdges it belongs to
			// As we iterate, we modify  
			for (int i = 0; i < inputEdges.Count; i++)
			{
				int mapKey1 = inputEdges[i].Vertices[0];
				int mapKey2 = inputEdges[i].Vertices[1];

				if (!Map.ContainsKey(mapKey1) && !Map.ContainsKey(mapKey2))
				{
					AddNewMapEntry(inputEdges[i], mapKey1);
					AddNewMapEntry(inputEdges[i], mapKey2);
				}

				// One of the two verts of the inputedge are in the map
				// Determine if the newVert is part of a line or a new edge to add to the map
				if (Map.ContainsKey(mapKey1) && !Map.ContainsKey(mapKey2))
					FindAndMergeNewVertex(mapKey1, mapKey2);
				// And vice-versa
				else if (Map.ContainsKey(mapKey2) && !Map.ContainsKey(mapKey1))
					FindAndMergeNewVertex(mapKey2, mapKey1);
				// Compare all values in both, merge if straight
				else if (Map.ContainsKey(mapKey1) && Map.ContainsKey(mapKey2))
				{
					SharedEdge mergedEdge = null;
					SharedEdge oldEdge1 = null;
					SharedEdge oldEdge2 = null;
					bool breakout = false; // We only need one match, if we find it, bust out of the loops
					for (int be1 = 0; be1 < Map[mapKey1].Count; be1++)
					{
						for (int be2 = 0; be2 < Map[mapKey2].Count; be2++)
						{
							if (AreTwoEdgesInSameLine(Map[mapKey1][be1], Map[mapKey2][be2]))
							{
								oldEdge1 = Map[mapKey1][be1];
								oldEdge2 = Map[mapKey2][be2];
								mergedEdge = MergeBoundaryEdge(Map[mapKey1][be1], Map[mapKey2][be2]);
								breakout = true;
							}
							if (breakout) { break; }
						}
						if (breakout) { break; }
					}

					// update references in the Map to the new mergedEdge
					if (mergedEdge != null)
					{
						for (int n = 0; n < mergedEdge.VerticeIndex.Count; n++)
						{
							int vertex = mergedEdge.VerticeIndex[n];
							if (Map.ContainsKey(vertex))
							{
								Map[vertex].Remove(oldEdge1);
								Map[vertex].Remove(oldEdge2);
								Map[vertex].Add(mergedEdge);
							}
						}
					}
				}
			}

			HashSet<SharedEdge> setOfUniqueSharedEdges = new HashSet<SharedEdge>();
			for (int i = 0; i < Map.Count; i++)
			{
				for (int n = 0; n < Map[i].Count; n++)
				{
					setOfUniqueSharedEdges.Add(Map[i][n]);
				}
			}

			return setOfUniqueSharedEdges;
		}

		private void FindAndMergeNewVertex(int existingVertex, int newVertex)
		{
			// The value of the map is a list of all BoundaryEdges the existing vertex is a part of 
			List<SharedEdge> existingEdges = Map[existingVertex];

			//Loop through the those boundaryEdges and see if the newVertex is a part of that Edge 
			for (int i = 0; i < existingEdges.Count; i++)
			{
				// The first and last entry of each boundary edge are the 'end's of the edge
				// Find the associated Vector3 from the meshVertexs and determine straightness
				if (IsPointOnLine(MeshVertices[existingEdges[i].First], MeshVertices[existingEdges[i].Last], MeshVertices[newVertex]))
				{
					SharedEdge edgeToAddTo = existingEdges[i];
					if (edgeToAddTo.First == existingVertex)
					{
						List<int> newVerticeIndex = new List<int>();
						newVerticeIndex.Add(newVertex);
						newVerticeIndex.AddRange(existingEdges[i].VerticeIndex);
						existingEdges[i].VerticeIndex = newVerticeIndex;
					}
					else if (edgeToAddTo.Last == existingVertex)
						existingEdges[i].VerticeIndex.Add(newVertex);
					else
						Engine.Logger.Error("Attempted to add vertex to interior of an edge");
				}
			}
		}

		
		void AddNewMapEntry(Edge toAdd, int vertex)
		{
			List<SharedEdge> be = new List<SharedEdge>();
			be.Add(new SharedEdge(toAdd));
			Map.Add(vertex, be);
		}

		// Measure the distance of a Vector3 to a line. If zero, its on the line.
		bool IsPointOnLine(Vector3 start, Vector3 end, Vector3 toCompare)
		{
			float distanceFromLine = MathUtils.DistanceLineSegmentPoint(start, end, toCompare);
			return Mathf.Approximately(0, distanceFromLine);
		}

		bool AreTwoEdgesInSameLine(SharedEdge edge1, SharedEdge edge2)
		{
			Vector3 edge1First = MeshVertices[edge1.First];
			Vector3 edge1Last = MeshVertices[edge1.Last];
			Vector3 edge2First = MeshVertices[edge2.First];
			Vector3 edge2Last = MeshVertices[edge2.Last];

			if (MathUtils.DistanceLineSegmentPoint(edge1First, edge1Last, edge2First) == 0 &&
				MathUtils.DistanceLineSegmentPoint(edge1First, edge1Last, edge2Last) == 0)
				return true;
			return false;
		}

		SharedEdge MergeBoundaryEdge(SharedEdge edge1, SharedEdge edge2)
		{
			SharedEdge newBE = new SharedEdge();

			// Add edge2 to the end of Edge1
			if (edge1.VerticeIndex[0] == edge2.VerticeIndex[edge2.VerticeIndex.Count - 1])
			{
				newBE.VerticeIndex = edge2.VerticeIndex;
				newBE.VerticeIndex.AddRange(edge1.VerticeIndex);
				return newBE;
			}

			// Add edge1 to the end of edge2
			if (edge1.VerticeIndex[edge1.VerticeIndex.Count - 1] == edge2.VerticeIndex[0])
			{
				newBE.VerticeIndex = edge1.VerticeIndex;
				newBE.VerticeIndex.AddRange(edge2.VerticeIndex);
				return newBE;
			}
			Engine.Logger.Error("MergeBoundaryEdge did not find matching edges, returning empty BoundaryEdge");
			return newBE;
		}


	}
}
