using System.Collections.Generic;
using UnityEngine;

namespace Ships.Blueprints
{
	public class Blueprint : MonoBehaviour
	{
		private BlueprintData m_model;

		public List<BlueprintComponent> Tiles;
		public List<BlueprintComponent> Doors;
		public List<BlueprintComponent> Equipment;
		public List<BlueprintComponent> Rooms;

		public void Initialize(BlueprintData model)
		{
			m_model = model;

			Tiles = m_model.Tiles;
			Doors = m_model.Doors;
			Equipment = m_model.Equipment;
			Rooms = m_model.Rooms;
		}
	}
}
