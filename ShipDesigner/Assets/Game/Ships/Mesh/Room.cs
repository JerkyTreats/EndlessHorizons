using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ships
{
	public enum RoomPart
	{
		Wall,
		Floor,
		Ceiling
	}

	public class Room
	{
		MeshCombiner m_combiner;

		public Room()
		{
			RoomParts = new List<MeshPart>();
			m_combiner = new MeshCombiner();
		}

		public void Add(MeshPart meshPart)
		{
			m_combiner.Add(meshPart);
			RoomParts.Add(meshPart);
		}

		public List<MeshPart> RoomParts;
		public Vector3 RoomCenter { get { return m_combiner.Origin.Center; } }

	}
}
