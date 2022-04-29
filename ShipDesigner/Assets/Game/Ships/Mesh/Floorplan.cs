using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
	public class Floorplan
	{
		public static float QUAD_SIZE = 1.0f;
		public static float FLOORPLAN_MAX_SIZE_X = 30.0f;
		public static float FLOORPLAN_MAX_SIZE_Z = 30.0f;

		List<Room> m_rooms;

		public Floorplan()
		{
			m_rooms = new List<Room>();
		}

		private void Seed()
		{
			Vector3 startPosition = new Vector3(FLOORPLAN_MAX_SIZE_X / 2, 0, FLOORPLAN_MAX_SIZE_Z / 2);

			//Triangle initTri = new Triangle();
			MeshPart initMP = new MeshPart();
			Room initRoom = new Room();

			//m_rooms.Add();
		}
	}
}
