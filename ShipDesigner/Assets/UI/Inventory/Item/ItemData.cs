using Engine;
using Engine.UI;
using Engine.Utility;
using System.IO;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory.Item
{
	public class ItemData
	{
		static string FILE_NAME = "ItemData.json";
		Vector2 m_spriteSize;
		float m_textDivisionAmount;
		Vector2 m_pivot = new Vector2(0, 1);

		public string Name { get; set; }
		public Quad Quad { get; set; }
		public TextData TextData { get; set; }
		public Vector2 SpriteSize {  get { return m_spriteSize; } }
		public float TextDivisionAmount { get { return m_textDivisionAmount; } }
		public Vector2 Pivot { get { return m_pivot;  } }

		public ItemData(string name, Quad quad)
		{
			Name = name;
			Quad = quad;
			TextData = new TextData();
			SetTextData();
			SetSprite();
		}

		private JSONNode GetJsonNode()
		{
			string path = Util.CombinePath(Directory.GetCurrentDirectory(), "Assets", "UI", "Inventory", "Item", FILE_NAME);
			return JSONTools.GetJSONNode(path);
		}

		private void SetTextData()
		{
			JSONNode node = GetJsonNode()["TextLabel"];

			TextData.Text = Name;
			TextData.Font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
			TextData.TextAnchor = Common.ParseEnum<TextAnchor>(node["TextAnchor"].Value);
			TextData.VerticalWrapMode = Common.ParseEnum<VerticalWrapMode>(node["VerticalWrapMode"]);
			TextData.BestFit = node["BestFit"].AsBool;

			m_textDivisionAmount = node["TextLabelDivisionAmount"].AsFloat;
		}

		private void SetSprite()
		{
			JSONNode node = GetJsonNode()["SpriteSize"];
			float width = node["x"].AsFloat;
			float length = node["y"].AsFloat;
			m_spriteSize = new Vector2(width, length);
		}
	}
}
