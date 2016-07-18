using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshop;
using UnityEngine;
using System.IO;

namespace ShipDesignerUnitTests
{
	[TestClass]
	public class Grid_Test
	{
		[TestMethod]
		public void GridInformation_TileStartLocationRetrievedByJsonFile()
		{
			GridFactory gi = new GridFactory();
			Assert.AreEqual(new Vector3(1.0f, 1.0f, 1.0f), gi.TileStartLocation);
		}

		[TestMethod]
		public void GridInformation_TileCountXRetrievedByJsonFile()
		{
			GridFactory gi = new GridFactory();
			Assert.AreEqual(10, gi.TileCountX);
		}

		[TestMethod]
		public void GridInformation_TileCountYRetrievedByJsonFile()
		{
			GridFactory gi = new GridFactory();
			Assert.AreEqual(10, gi.TileCountY);
		}
	}
}
