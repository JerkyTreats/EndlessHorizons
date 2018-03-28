using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ships
{
	public class Room
	{
		MeshCombiner m_floors;

		public Room()
		{
			m_floors = new MeshCombiner();

		}

		public void Add(MeshPart meshPart)
		{
			m_floors.Add(meshPart);
		}

		public List<Edge> FloorEdge
		{
			get
			{
				return m_floors.Boundary;
			}
		}
		public Vector3 RoomCenter { get { return m_floors.Origin.Center; } }

	}
}
