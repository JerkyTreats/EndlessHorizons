using Engine;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Ships
{
	/// <summary>
	/// Contains information about a part of a Mesh. Parts are combined to build complete Mesh builds via a MeshCombiner 
	/// </summary>
	public class MeshPart
	{
		#region Private Variables

		Log m_logger = new Log(GameAreas.Mesh);
		List<Vertex> m_vertices; 
		List<Triangle> m_tris;

		#endregion

		#region public variables

		public List<Vertex> Vertices { get { return m_vertices; } }
		public List<Triangle> Triangles { get { return m_tris; } }
		public Origins Origin { get; set; }

		#endregion

		#region Constructors

		public MeshPart()
		{
			m_vertices = new List<Vertex>();
			m_tris = new List<Triangle>();
		}

		public MeshPart(Mesh mesh)
		{
			m_vertices = VertexFactory.GetVertexList(mesh.vertices, mesh.normals, mesh.uv);
			m_tris = Triangle.GetTriangleList(mesh.triangles, m_vertices);
			Origin = new Origins(m_vertices);
		}

		public MeshPart(Vector3[] vertices, Vector3[] normals, Vector2[] uvs, int[] tris)
		{
			m_vertices = VertexFactory.GetVertexList(vertices, normals, uvs);
			m_tris = Triangle.GetTriangleList(tris, m_vertices);
		}

		public MeshPart(List<Triangle> triangles)
		{
			m_vertices = Triangle.GetVertices(triangles);
			m_tris = triangles;
		}

		#endregion

		#region Public Methods

		public void Add(Triangle newTriangle)
		{
			m_tris.Add(newTriangle);
			m_vertices.AddRange(newTriangle.Vertices);
		}

		#endregion

	}
}
