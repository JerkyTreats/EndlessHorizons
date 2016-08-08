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
			m_texture = LoadTexture(resourcePath);
			m_vertices = GetDefaultVertices();
			m_uvs = GetDefaultUVs();
			m_normals = GetDefaultNormals();
			m_tris = GetDefaultTriangles();
		}

		public Quad(string resourcePath, Vector3[] vertices, Vector3[] normals, Vector2[] uvs, int[] tris)
		{
			m_texture = LoadTexture(resourcePath);
			if (m_texture != null)
				m_texture.wrapMode = TextureWrapMode.Repeat;
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
			renderer.material.mainTexture = m_texture;

			Mesh mesh = new Mesh();
			mesh.vertices = m_vertices;
			mesh.normals = m_normals;
			mesh.uv = m_uvs;
			mesh.triangles = m_tris;

			var meshFilter = gameObject.AddComponent<MeshFilter>();
			meshFilter.mesh = mesh;
			mesh.RecalculateNormals();
		}

		public float Width
		{
			get
			{
				return m_vertices[2].x / m_uvs[2].x;
			}
		}
		public float Height
		{
			get
			{
				return m_vertices[2].y / m_uvs[2].y;
			}
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

		Texture LoadTexture(string resourcePath)
		{
			return Resources.Load<Texture>(resourcePath) as Texture;
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
		public Vector3[] Vertices {  get { return m_vertices; } }
		public Vector3[] Normals {  get { return m_normals; } }
		public Vector2[] UVs {  get { return m_uvs; } }
		public int[] Triangles {  get { return m_tris; } }
	}
}
