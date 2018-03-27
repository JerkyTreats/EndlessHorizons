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
		public Origins Origin { get { return m_origin; } }
	}
}
