using Engine;
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
		Log m_logger = new Log(GameAreas.Camera);

		public Quad(string resourcePath)
		{
			m_texture = Common.LoadTexture(resourcePath);
			m_vertices = GetDefaultVertices(4);
			m_uvs = GetDefaultUVs();
			m_normals = GetDefaultNormals();
			m_tris = GetDefaultTriangles();
		}

		public Quad(int verts)
		{
			m_logger.Header("Creating New Quad");
			m_vertices = GetDefaultVertices(verts);
			m_uvs = GetDefaultUVs();
			m_normals = GetDefaultNormals();
			m_tris = GetDefaultTriangles();
			m_logger.Header("Finished Creating Quad");
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
			Vector3[] normals = new Vector3[m_vertices.Length];

			for (int i = 0; i < normals.Length; i++)
			{
				normals[i] = -Vector3.forward;
			}

			return normals;
		}

		int[] GetDefaultTriangles()
		{
			m_logger.Header("Creating Triangles");
			int verts = m_vertices.Length - 1;
			int[] tris = new int[verts * 3];
			m_logger.Write(string.Format("Creating triangles:\nVerts: [{0}]\ntris: [{1}]", verts, tris.Length));

			int index = 1;
			for (int i = 0; i <= (3 * (verts - 1)); i+=3)
			{
				tris[i] = 0;
				tris[i + 1] = index;
				tris[i + 2] = index + 1;
				index += 1;
			}

			tris[tris.Length - 1] = 1;
			tris[tris.Length - 2] = verts;
			tris[tris.Length - 3] = 0;
			
			return tris;
		}

		//Verts per side should be divisible by 4
		Vector3[] GetDefaultVertices(int vertices)
		{
			m_logger.Header("Creating Quad Vertices");
			m_logger.Write(string.Format("Input vertices: [{0}]", vertices));
			Vector3[] verts = new Vector3[vertices + 1]; // +1 to include the center vertex

			int vertsPerSide = (vertices - 4) / 4; //number of vertices per side not including corners
			float vertIncrement = 1f / (vertsPerSide + 1); // Each side vertex evenly divided
			m_logger.Write(string.Format("vertsPerSide: [{0}]\nvertIncrement: [{1}]", vertsPerSide, vertIncrement));
			verts[0] = new Vector3(0.5f, 0.5f); // Center vert first

			Vector3 currentVert = new Vector3();
			for (int i = 1; i < vertices + 1; i++) //-1 because we add the last vert manually
			{
				m_logger.Write(string.Format("Vertex[{1}]: [{0}]", currentVert, i), 2);
				verts[i] = currentVert;
	
				currentVert = incrementVert(i <= (vertices / 2), currentVert, vertIncrement);
			}

			return verts;
		}

		Vector3 incrementVert(bool isAscending, Vector3 vert, float increment)
		{
			if (!isAscending)
				increment *= -1;

			if ((vert.y == 1 && isAscending) || (vert.y == 0 && !isAscending))
				vert.x += increment;
			else
				vert.y += increment;
			return vert;
		}

		Vector2[] GetDefaultUVs()
		{
			Vector2[] uvs = new Vector2[m_vertices.Length];
			for (int i = 0; i < m_vertices.Length; i++)
			{
				uvs[i] = new Vector2(m_vertices[i].x, m_vertices[i].y);
			}

			return uvs;
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
