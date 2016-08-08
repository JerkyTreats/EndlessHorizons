using SimpleJSON;
using Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using System.IO;
using System;
using UnityEngine;

namespace Ships.Components
{
	public class TileData
	{
		JSONNode JsonValues;
		string m_name;
		float m_weight;
		float m_durability;
		float m_cost;

		MaterialData m_inventorySpriteData;
		MaterialData m_spriteData;

		public string Name { get { return m_name; } }
		public float Weight { get { return m_weight; } }
		public float Durability { get { return m_durability; } }
		public float Cost { get { return m_cost; } }
		public MaterialData MainSpriteData { get { return m_spriteData; } }

		public TileData(string tileJsonPath)
		{
			JsonValues = JSONTools.GetJSONNode(tileJsonPath);
			SetName();
			SetWeight();
			SetDurability();
			SetCost();
			SetSprite();
		}

		private void SetSprite()
		{
			var main = JsonValues["Sprite"]["Main"];
			var inventory = JsonValues["Sprite"]["Inventory"];

			Vector3[] vertices = GetVertices(main);
			Vector3[] normals = GetNormals();
			Vector2[] uvs = GetUVs();
			int[] tris = GetTris();

			m_spriteData = new MaterialData(
				main["Texture"].Value,
				vertices,
				normals,
				uvs,
				tris
			);

			m_inventorySpriteData = new MaterialData(
				inventory["Texture"].Value,
				GetVertices(inventory),
				GetNormals(),
				GetUVs(),
				GetTris()
			);
		}

		private int[] GetTris()
		{
			return new int[6]
			{
				0, 1, 2,
				0, 2, 3
			};
		}

		private Vector2[] GetUVs()
		{
			return new Vector2[4]
			{
				new Vector2(),
				new Vector2(0,1),
				new Vector2(1,1),
				new Vector2(1,0),
			};
		}

		private Vector3[] GetNormals()
		{
			return new Vector3[4]
			{
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward
			};
		}

		private static Vector3[] GetVertices(JSONNode node)
		{
			return new Vector3[4]
			{
				new Vector3(),
				new Vector3(0, node["MaxSize"]["y"].AsFloat),
				new Vector3(node["MaxSize"]["x"].AsFloat, node["MaxSize"]["y"].AsFloat),
				new Vector3(node["MaxSize"]["x"].AsFloat,0),
			};
		}

		private void SetCost()
		{
			m_cost = JsonValues["Cost"].AsFloat;
		}

		private void SetDurability()
		{
			m_durability = JsonValues["Durability"].AsFloat;
		}

		private void SetWeight()
		{
			m_weight = JsonValues["Weight"].AsFloat;
		}

		void SetName()
		{
			m_name = JsonValues["Name"].Value;
		}
	}
}
