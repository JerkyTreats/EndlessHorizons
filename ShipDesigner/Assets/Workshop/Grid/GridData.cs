using SimpleJSON;
using System.IO;
using Util;
using UnityEngine;
using Engine;
using System.Collections.Generic;
using System;

namespace Workshop.Grid
{
	public class GridData
	{
		static string FILE_NAME = "GridInformation.json";
		static string JSON_ROOT_NODE = "GridInformation";

		JSONNode JsonValues;

		Vector3 m_tileStartLocation;
		int m_gridCountX;
		int m_gridCountY;
		MaterialData m_spriteData;

		Vector3[] m_vertices;
		Vector2[] m_uvs;
		Vector3[] m_normals;

		public GridData()
		{
			JsonValues = JSONTools.GetJSONNode(GetGridInformationPath());
			SetStartLocation();
			SetTileCount();
			m_spriteData = new MaterialData(GetStringFromJson("SpritePath"), GetVertices(), GetNormals(), GetUVs(), GetTriangles());
		}



		private void SetStartLocation()
		{
			m_tileStartLocation = new Vector3
				(
					JsonValues[JSON_ROOT_NODE]["TileStartLocation"]["x"].AsFloat,
					JsonValues[JSON_ROOT_NODE]["TileStartLocation"]["y"].AsFloat,
					JsonValues[JSON_ROOT_NODE]["TileStartLocation"]["z"].AsFloat
				);
		}

		private void SetTileCount()
		{
			m_gridCountX = JsonValues[JSON_ROOT_NODE]["TileCount"]["x"].AsInt;
			m_gridCountY = JsonValues[JSON_ROOT_NODE]["TileCount"]["y"].AsInt;
		}

		private Vector3[] GetVertices()
		{
			List<Vector3> verts = new List<Vector3>();

			string node = "BackgroundPlane";
			string vectorNode = "Vector3";
			for (int i = 0; i < 4; i++)
			{
				verts.Add(new Vector3(
					JsonValues[JSON_ROOT_NODE][node][i][vectorNode]["x"].AsFloat,
					JsonValues[JSON_ROOT_NODE][node][i][vectorNode]["y"].AsFloat,
					JsonValues[JSON_ROOT_NODE][node][i][vectorNode]["z"].AsFloat
				));
			}
			return verts.ToArray();
		}

		Vector2[] GetUVs()
		{
			Vector2 bottomLeft = new Vector2();
			Vector2 topLeft = new Vector2(0, TileCountY );
			Vector2 topRight = new Vector2(TileCountX, TileCountY);
			Vector2 bottomRight = new Vector2(TileCountX, 0);

			return new Vector2[] { bottomLeft, topLeft, topRight, bottomRight }; 
		}

		Vector3[] GetNormals()
		{
			Vector3[] normals = new Vector3[4];

			normals[0] = -Vector3.forward;
			normals[1] = -Vector3.forward;
			normals[2] = -Vector3.forward;
			normals[3] = -Vector3.forward;

			return normals;
		}

		private int[] GetTriangles()
		{
			return new int[]
			{
				0, 1, 2,
				0, 2, 3
			};

		}

		private string GetGridInformationPath()
		{
			return Common.CombinePath(Directory.GetCurrentDirectory(), "Assets", "Workshop", "Grid", FILE_NAME);
		}

		private float GetFloatFromJson(string value)
		{
			return JsonValues[JSON_ROOT_NODE][value].AsFloat;
		}

		private string GetStringFromJson(string value)
		{
			return JsonValues[JSON_ROOT_NODE][value].Value;
		}

		public Vector3 TileStartLocation { get { return m_tileStartLocation; } }
		public int TileCountX { get { return m_gridCountX; } }
		public int TileCountY { get { return m_gridCountY; } }
		public MaterialData MaterialData { get { return m_spriteData; } }

		public Vector3[] Vertices { get { return m_vertices; } }
		public Vector2[] UVs { get { return m_uvs; } }
		public Vector3[] Normals { get { return m_normals; } }

	}
}
