using UnityEngine;
using System.Collections;

namespace Workshop
{
	public class Grid_GameObject : MonoBehaviour
	{
		private Grid controller;

		public void Initialize(Grid grid)
		{
			controller = grid;
		}

		void BuildTiles()
		{
			for (int i = 0; i < controller.Tiles.Count; i++)
			{
				controller.Tiles[i].TileGameObject.transform.SetParent(gameObject.transform);
			}
		}

	}
}
