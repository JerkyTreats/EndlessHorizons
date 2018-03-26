using Engine;
using System.Collections.Generic;
using UnityEngine;

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
		List<int> m_tris;

		public MeshPart()
		{
			m_vertices = new List<Vector3>();
			m_normals = new List<Vector3>();
			m_uvs = new List<Vector2>();
			m_tris = new List<int>();
		}

		public MeshPart(Mesh mesh)
		{
			m_vertices = new List<Vector3>(mesh.vertices);
			m_normals = new List<Vector3>(mesh.normals);
			m_uvs = new List<Vector2>(mesh.uv);
			m_tris = new List<int>(mesh.triangles);

			Origin = new Origins(m_vertices);
		}

		#region public variables

		public List<Vector3> Vertices { get { return m_vertices; } }
		public List<Vector3> Normals { get { return m_normals; } }
		public List<Vector2> UVs { get { return m_uvs; } }
		public List<int> Triangles { get { return m_tris; } }

		public RoomPart RoomPart { get; set; }
		public Origins Origin { get; set; }
		
		#endregion
	}
}
