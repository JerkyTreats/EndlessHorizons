﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ships.Components
{
	public class ComponentRepository
	{
		public TileDataRepository TileData;

		public ComponentRepository()
		{
			TileData = new TileDataRepository();
		}
	}
}