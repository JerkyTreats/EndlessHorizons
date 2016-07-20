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

	}
}
