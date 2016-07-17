using System.Collections.Generic;


namespace Workshop
{
	public class GridTile
	{
		private float Length { get; set; }
		private float Width { get; set; }

		public GridTile(float length, float width)
		{
			Length = length;
			Width = width;
		}
	}
}
