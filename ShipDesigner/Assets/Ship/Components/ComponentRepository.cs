using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ships.Components
{
	public class ComponentRepository
	{
		public TileDataRepository TileData;
		public RoomDataRepository RoomData;
		public EquipmentDataRepository EquipmentData;
		public DoorDataRepository DoorData;

		public ComponentRepository()
		{
			TileData = new TileDataRepository();
			RoomData = new RoomDataRepository();
			EquipmentData = new EquipmentDataRepository();
			DoorData = new DoorDataRepository();
		}
	}
}
