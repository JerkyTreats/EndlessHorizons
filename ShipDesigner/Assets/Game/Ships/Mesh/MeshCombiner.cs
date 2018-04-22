using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
	public class MeshCombiner
	{
		#region Private Variables

		List<MeshPart> m_meshParts;
		List<Triangle> m_triangles;
		List<Vertex> m_combinedVertices;
		Origins m_origin;

		#endregion

		#region Public Variables

		public List<MeshPart> MeshParts { get { return m_meshParts; } }
		public List<Vertex> CombinedVertices { get { return m_combinedVertices; } }
		public List<Triangle> Triangles { get { return m_triangles; } }
		public Origins Origin { get { return m_origin; } }
		public List<Edge> Boundary { get { return MeshUtils.GetBoundaryEdges(m_triangles); } }
		public List<SharedEdge> SharedEdges { get { return SharedEdge.SharedEdgeFactory(Boundary); } }

		#endregion

		#region Constructors

		public MeshCombiner()
		{
			m_triangles = new List<Triangle>();
			m_meshParts = new List<MeshPart>();
			m_combinedVertices = new List<Vertex>();
			m_origin = new Origins(new List<Vertex>());
		}

		#endregion

		#region Public Methods

		public void Add(MeshPart meshPart)
		{
			m_meshParts.Add(meshPart);
			m_triangles.AddRange(meshPart.Triangles);
			m_combinedVertices.AddRange(meshPart.Vertices);
			m_origin = new Origins(m_combinedVertices);
		}

		public void Remove(MeshPart meshPart)
		{
			if (!m_meshParts.Contains(meshPart)) { return; }
			m_meshParts.Remove(meshPart);

			// Dereference everything and build everything without removed part
			m_combinedVertices = new List<Vertex>();
			List<MeshPart> oldMeshParts = m_meshParts;

			m_meshParts = new List<MeshPart>();
			for (int i = 0; i < oldMeshParts.Count; i++)
			{
				Add(oldMeshParts[i]);
			}
		}

		#endregion


	}
}
