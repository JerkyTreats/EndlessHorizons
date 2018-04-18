using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
	public class MeshCombiner
	{
		List<MeshPart> m_meshParts;

		List<Triangle> m_triangles;
		List<Vector3> m_vertices;
		List<Vector3> m_normals;
		List<Vector2> m_uvs;

		Origins m_origin;

		public MeshCombiner()
		{
			m_triangles = new List<Triangle>();
			m_meshParts = new List<MeshPart>();
			m_vertices = new List<Vector3>();
			m_normals = new List<Vector3>();
			m_uvs = new List<Vector2>();

			m_origin = new Origins(m_vertices);
		}

		public void Add(MeshPart meshPart)
		{
			m_meshParts.Add(meshPart);
			m_vertices.AddRange(meshPart.Vertices);
			m_normals.AddRange(meshPart.Normals);
			m_uvs.AddRange(meshPart.UVs);
			m_triangles.AddRange(meshPart.Triangles);

			m_origin = new Origins(m_vertices);
		}

		public void Remove(MeshPart meshPart)
		{
			if (!m_meshParts.Contains(meshPart)) { return; }
			m_meshParts.Remove(meshPart);

			// Dereference everything and build everything without removed part
			m_vertices = new List<Vector3>();
			m_normals = new List<Vector3>();
			m_uvs = new List<Vector2>();
			List<MeshPart> oldMeshParts = m_meshParts;

			m_meshParts = new List<MeshPart>();
			for (int i = 0; i < oldMeshParts.Count; i++)
			{
				Add(oldMeshParts[i]);
			}
		}

		//public List<Vector3> GetCorners()
		//{
		//	List<Vector3> corners = new List<Vector3>();
		//	List<SharedEdge> edges = MeshUtils.GetSharedEdges(Boundary, m_vertices);

		//	for (int i = 0; i < edges.Count; i++)
		//	{
		//		SharedEdge se = edges[i];

		//		Vector3 index = m_vertices[se.SharedIndex];
		//		bool xAxisIterating = true;
		//		bool yAxisIterating = true;

		//		for (int n = 0; n < se.Edges.Count; n++)
		//		{
		//			int connectedVertice;
		//			if (se.SharedIndex == se.Edges[n].Vertices[0])
		//				connectedVertice = se.Edges[n].Vertices[1];
		//			else
		//				connectedVertice = se.Edges[n].Vertices[0];

		//			Vector3 edge = m_vertices[connectedVertice];
		//			if (edge.x != index.x)
		//				xAxisIterating = false;
		//			if (edge.y != index.y)
		//				yAxisIterating = false;
		//		}

		//		if (!xAxisIterating && !yAxisIterating)
		//			corners.Add(index);
		//	}

		//	return corners;
		//}

		public List<Edge> Boundary
		{
			get
			{
				return MeshUtils.GetBoundaryEdges(m_triangles);
			}
		}

		public List<MeshPart> MeshParts { get { return m_meshParts; } }
		public List<Vector3> Vertices { get { return m_vertices; } }
		public List<Vector3> Normals { get { return m_normals; } }
		public List<Vector2> UV { get { return m_uvs; } }
		public List<Triangle> Triangles{ get { return m_triangles; } }

		public Origins Origin { get { return m_origin; } }
	}
}
