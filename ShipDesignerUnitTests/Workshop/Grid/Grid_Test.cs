using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshop;

namespace ShipDesignerUnitTests
{
	[TestClass]
	public class Grid_Test
	{
		[TestMethod]
		public void GridInformation_GridTileLengthRetrievedFromJsonFile()
		{
			GridInformation gi = new GridInformation();
			Assert.AreEqual(5.0f, gi.GridTileLength);
		}

		[TestMethod]
		public void GridInformation_GridTileWidthRetrievedFromJsonFile()
		{
			GridInformation gi = new GridInformation();
			Assert.AreEqual(5.0f, gi.GridTileWidth);
		}

		[TestMethod]
		public void GridInformation_GridTileLengthCannotBeSetToZero()
		{
			GridInformation gi = new GridInformation();
			gi.GridTileLength = 0;
			Assert.AreNotEqual(0, gi.GridTileLength);
		}

		[TestMethod]
		public void GridInformation_GridTileWidthCannotBeSetToZero()
		{
			GridInformation gi = new GridInformation();
			gi.GridTileWidth = 0;
			Assert.AreNotEqual(0, gi.GridTileWidth);
		}
	}
}
