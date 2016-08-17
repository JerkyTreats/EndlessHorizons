using UnityEngine;
using System.Collections.Generic;
using Engine.UI;
using UnityEngine.UI;

namespace UI.Inventory.Item
{
	public class ItemController
	{
		Vector2 m_textPanelSize;
		TextData m_textData;
		Sprite m_sprite;

		public TextData TextData { get { return m_textData; } }
		public Vector2 TextPanelSize {  get { return m_textPanelSize; } }

		public ItemController(TextData textData, Vector2 textPanelSize)
		{
			m_textData = textData;
			m_textPanelSize = textPanelSize;
		}

		public void SetTextData(Text text)
		{
			text.text = m_textData.Text;
			text.verticalOverflow = m_textData.VerticalWrapMode;
			text.font = m_textData.Font;
			text.alignment = m_textData.TextAnchor;
			text.resizeTextForBestFit = m_textData.BestFit;
		}
	}
}
