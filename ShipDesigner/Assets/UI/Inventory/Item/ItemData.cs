using Engine;
using Engine.Utility;
using System.IO;
using SimpleJSON;
using UnityEngine;

namespace UI.Inventory.Item
{
	public class ItemData
	{
		static string FILE_NAME = "ItemData.json";

		float m_textDivisionAmount;
		Vector2 m_pivot = new Vector2(0, 1);
		Vector2 m_itemSize;
		Sprite m_sprite;
		Quad m_itemPreview;

		public string Name { get; set; }
		public TextData TextData { get; set; }
		public float TextDivisionAmount { get { return m_textDivisionAmount; } }
		public Vector2 ItemSize { get { return m_itemSize; } }
		public Sprite Sprite {  get { return m_sprite; } }
		public Vector2 Pivot { get { return m_pivot; } }
		public Quad ItemPreview { get { return m_itemPreview; } }

		public ItemData(string name, string spritePath)
		{
			Name = name;
			SetTextData();
			SetItemSize();
			SetSprite(spritePath);
			SetItemPreviewData(spritePath);
		}

		private JSONNode GetJsonNode()
		{
			string path = Util.CombinePath(Directory.GetCurrentDirectory(), "Assets", "UI", "Inventory", "Item", FILE_NAME);
			return JSONTools.GetJSONNode(path);
		}

		private void SetTextData()
		{
			TextData = new TextData();
			JSONNode node = GetJsonNode()["TextLabel"];

			TextData.Text = Name;
			TextData.Font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
			TextData.TextAnchor = Util.ParseEnum<TextAnchor>(node["TextAnchor"].Value);
			TextData.VerticalWrapMode = Util.ParseEnum<VerticalWrapMode>(node["VerticalWrapMode"]);
			TextData.BestFit = node["BestFit"].AsBool;

			m_textDivisionAmount = node["TextLabelDivisionAmount"].AsFloat;
		}

		private void SetSprite(string spritePath)
		{
			m_sprite = Engine.Common.BuildSprite(spritePath, new Vector2(0.5f, 0.5f));
		}

		private void SetItemSize()
		{
			JSONNode node = GetJsonNode()["SpriteSize"];
			float width = node["x"].AsFloat;
			float length = node["y"].AsFloat;
			m_itemSize = new Vector2(width, length);
		}

		private void SetItemPreviewData(string spritePath)
		{
			m_itemPreview = new Quad(spritePath);
			m_itemPreview.SetVertices(new Vector3(), new Vector3(1,1));
		}
	}
}
