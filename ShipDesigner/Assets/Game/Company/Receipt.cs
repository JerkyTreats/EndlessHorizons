using System;
using System.Collections.Generic;
using Ships;

namespace Company
{
	public class Receipt
	{
		public Ships.Ship ShipSold { get; set; }
		public int SellPrice { get; set; }
	}
}