using UnityEngine;

namespace Engine
{
	public class MaterialData
	{
		Texture m_texture;
		Vector3[] m_vertices;
		Vector3[] m_normals;
		Vector2[] m_uvs;
		int[] m_tris;
 
		public MaterialData(string resourcePath, Vector3[] vertices, Vector3[] normals, Vector2[] uvs, int[] tris)
		{
			m_texture = Resources.Load<Texture>(resourcePath) as Texture;
			m_texture.wrapMode = TextureWrapMode.Repeat;
			m_normals = normals;
			m_vertices = vertices;
			m_uvs = uvs;
			m_tris = tris;
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

		public Texture Texture { get { return m_texture; } }
		public Vector3[] Vertices {  get { return m_vertices; } }
		public Vector3[] Normals {  get { return m_normals; } }
		public Vector2[] UVs {  get { return m_uvs; } }
		public int[] Triangles {  get { return m_tris; } }
	}
}
