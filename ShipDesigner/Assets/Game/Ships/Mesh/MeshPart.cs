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
		Log m_logger = new Log(GameAreas.Mesh);

		List<Vector3> m_vertices;
		List<Vector3> m_normals;
		List<Vector2> m_uvs;
		List<Triangle> m_tris;

		public MeshPart()
		{
			m_vertices = new List<Vector3>();
			m_normals = new List<Vector3>();
			m_uvs = new List<Vector2>();
			m_tris = new List<Triangle>();
		}

		public MeshPart(Mesh mesh)
		{
			m_vertices = new List<Vector3>(mesh.vertices);
			m_normals = new List<Vector3>(mesh.normals);
			m_uvs = new List<Vector2>(mesh.uv);
			m_tris = Triangle.GetTriangleList(mesh.triangles);

			Origin = new Origins(m_vertices);
		}

		public MeshPart(Vector3[] vertices, Vector3[] normals, Vector2[] uvs, int[] triangles)
		{
			m_vertices = new List<Vector3>(vertices);
			m_normals = new List<Vector3>(normals);
			m_uvs = new List<Vector2>(uvs);
			m_tris = Triangle.GetTriangleList(triangles);

			Origin = new Origins(m_vertices);
		}



		#region public variables

		public List<Vector3> Vertices { get { return m_vertices; } }
		public List<Vector3> Normals { get { return m_normals; } }
		public List<Vector2> UVs { get { return m_uvs; } }
		public List<Triangle> Triangles { get { return m_tris; } }

		public Origins Origin { get; set; }
		
		#endregion
	}
}
