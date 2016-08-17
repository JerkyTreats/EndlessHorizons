using SimpleJSON;
using Engine;
using Engine.Utility;
using UnityEngine;
using UI.Inventory.Item;

namespace Ships.Components
{
	public class TileData
	{
		JSONNode JsonValues;
		string m_name;
		float m_weight;
		float m_durability;
		float m_cost;

		ItemData m_itemData;
		Quad m_spriteData;

		public string Name { get { return m_name; } }
		public float Weight { get { return m_weight; } }
		public float Durability { get { return m_durability; } }
		public float Cost { get { return m_cost; } }
		public Quad MainSpriteData { get { return m_spriteData; } }
		public ItemData ItemData {  get { return m_itemData; } }

		public TileData(string tileJsonPath)
		{
			JsonValues = JSONTools.GetJSONNode(tileJsonPath);
			SetName();
			SetWeight();
			SetDurability();
			SetCost();
			SetMainSprite();
			SetItemData();
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

		private void SetItemData()
		{
			m_itemData = new ItemData(Name, new Quad(JsonValues["Sprite"]["Inventory"]["Texture"]));
		}

		private void SetMainSprite()
		{
			m_spriteData = BuildQuad(JsonValues["Sprite"]["Main"]);
		}

		private Quad BuildQuad(JSONNode node)
		{
			Quad quad = new Quad(node["Texture"]);

			m_spriteData = new Quad(node["Texture"].Value);
			m_spriteData.SetVertices(new Vector3(), new Vector3(node["MaxSize"]["x"].AsFloat, node["MaxSize"]["y"].AsFloat));
			return quad;
		}
	}
}
