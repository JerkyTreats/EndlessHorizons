using UnityEngine;
using System.Collections.Generic;
namespace Workshop
{
	public class Grid
	{
		private Vector3 StartLocation = new Vector3();
		private int m_gridCountX;
		private int m_gridCountY;

		public List<GridTile> Tiles;

		public Grid(int x, int y, Vector3 startLocation)
		{
			m_gridCountX = x;
			m_gridCountY = y;
			StartLocation = startLocation;
		}
	}
}
