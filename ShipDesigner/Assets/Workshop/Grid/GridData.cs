﻿using SimpleJSON;
using System.IO;
using Engine.Utility;
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
		Quad m_quad;

		public GridData()
		{
			JsonValues = JSONTools.GetJSONNode(GetGridInformationPath());
			SetStartLocation();
			SetTileCount();
			SetQuad();
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

		private void SetQuad()
		{
			m_quad = new Quad(GetStringFromJson("SpritePath"));

			m_quad.SetVertices(new Vector3(), new Vector3(m_gridCountX, m_gridCountY));
			m_quad.SetUVs(new Vector2(), new Vector2(TileCountX, TileCountY));
		}

		private string GetGridInformationPath()
		{
			return Util.CombinePath(Directory.GetCurrentDirectory(), "Assets", "Workshop", "Grid", FILE_NAME);
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
		public Quad Quad { get { return m_quad; } }
	}
}