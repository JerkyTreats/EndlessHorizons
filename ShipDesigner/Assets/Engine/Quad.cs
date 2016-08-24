using System;
using UnityEngine;

namespace Engine
{
	public class Quad
	{
		Texture m_texture;
		Vector3[] m_vertices;
		Vector3[] m_normals;
		Vector2[] m_uvs;
		int[] m_tris;
 
		public Quad(string resourcePath)
		{
			m_texture = Common.LoadTexture(resourcePath);
			m_vertices = GetDefaultVertices();
			m_uvs = GetDefaultUVs();
			m_normals = GetDefaultNormals();
			m_tris = GetDefaultTriangles();
		}

		public Quad(string resourcePath, Vector3[] vertices, Vector3[] normals, Vector2[] uvs, int[] tris)
		{
			m_texture = Common.LoadTexture(resourcePath);
			m_normals = normals;
			m_vertices = vertices;
			m_uvs = uvs;
			m_tris = tris;
		}

		/// <summary>
		/// Attaches necessary components to a GameObject to render a mesh 
		/// </summary>
		/// <param name="gameObject"></param>
		public void RenderQuad(GameObject gameObject)
		{
			var renderer = gameObject.AddComponent<MeshRenderer>();
			Material material = renderer.material;
			material.name = string.Format("Material_{0}", gameObject.name);
			material.mainTexture = m_texture;

			renderer.material = material;

			Mesh mesh = new Mesh();
			mesh.vertices = m_vertices;
			mesh.normals = m_normals;
			mesh.uv = m_uvs;
			mesh.triangles = m_tris;

			var meshFilter = gameObject.AddComponent<MeshFilter>();
			meshFilter.mesh = mesh;
			mesh.RecalculateNormals();
		}

		/// <summary>
		/// Set the Vertices of the quad based on the minimum and maximum point of the quad
		/// </summary>
		/// <param name="min">Bottom left point of the quad</param>
		/// <param name="max">Top right point of the quad </param>
		public void SetVertices(Vector3 min, Vector3 max)
		{
			m_vertices = new Vector3[4]
			{
				new Vector3(min.x, min.y),
				new Vector3(min.x, max.y),
				new Vector3(max.x, max.y),
				new Vector3(max.x, min.y)
			};
		}

		/// <summary>
		/// Set the UV coordinates of the quad
		/// </summary>
		/// <param name="min">Bottom left UV coordinate</param>
		/// <param name="max">Top right UV coordinate</param>
		public void SetUVs(Vector2 min, Vector2 max)
		{
			m_uvs = new Vector2[4]
			{
				new Vector2(min.x,min.y),
				new Vector2(min.x,max.y),
				new Vector2(max.x,max.y),
				new Vector2(max.x,min.y)
			};
		}

		Vector3[] GetDefaultNormals()
		{
			Vector3[] normals = new Vector3[4];

			normals[0] = -Vector3.forward;
			normals[1] = -Vector3.forward;
			normals[2] = -Vector3.forward;
			normals[3] = -Vector3.forward;

			return normals;
		}
		int[] GetDefaultTriangles()
		{
			return new int[]
			{
				0, 1, 2,
				0, 2, 3
			};
		}
		Vector3[] GetDefaultVertices()
		{
			return new Vector3[4]
			{
				new Vector3(),
				new Vector3(0,1),
				new Vector3(1,1),
				new Vector3(1,0)
			};
		}
		Vector2[] GetDefaultUVs()
		{
			return new Vector2[4]
			{
				new Vector2(),
				new Vector2(0,1),
				new Vector2(1,1),
				new Vector2(1,0)
			};
		}

		public Texture Texture { get { return m_texture; } }
		public Texture2D Texture2D { get { return m_texture as Texture2D; } }
		public Vector3[] Vertices {  get { return m_vertices; } }
		public Vector3[] Normals {  get { return m_normals; } }
		public Vector2[] UVs {  get { return m_uvs; } }
		public int[] Triangles {  get { return m_tris; } }
		public float UVMappingWidth
		{
			get
			{
				return m_vertices[2].x / m_uvs[2].x;
			}
		}
		public float UVMappingHeight
		{
			get
			{
				return m_vertices[2].y / m_uvs[2].y;
			}
		}
		public float Width { get { return Vertices[2].x - Vertices[0].x; } }
		public float Height { get { return Vertices[2].y - Vertices[0].y; } }
	}
}
