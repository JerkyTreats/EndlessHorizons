using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class TextData
	{
		public string Text { get; set; }
		public VerticalWrapMode VerticalWrapMode { get; set; }
		public Font Font { get; set; }
		public TextAnchor TextAnchor { get; set; }
		public bool BestFit { get; set; }
	}
}
