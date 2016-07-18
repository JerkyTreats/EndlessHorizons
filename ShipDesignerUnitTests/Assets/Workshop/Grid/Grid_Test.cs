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

		[TestMethod]
		public void GridInformation_TileStartLocationRetrievedByJsonFile()
		{
			GridInformation gi = new GridInformation();
			Assert.AreEqual(new Vector3(1.0f, 1.0f, 1.0f), gi.TileStartLocation);
		}

		[TestMethod]
		public void GridInformation_TileCountXRetrievedByJsonFile()
		{
			GridInformation gi = new GridInformation();
			Assert.AreEqual(10, gi.TileCountX);
		}

		[TestMethod]
		public void GridInformation_TileCountYRetrievedByJsonFile()
		{
			GridInformation gi = new GridInformation();
			Assert.AreEqual(10, gi.TileCountY);
		}

		[TestMethod]
		public void GridInformation_TileSpritePulledFromJsonFile()
		{
			GridInformation gi = new GridInformation();
			Assert.IsTrue(File.Exists(gi.Sprite));
		}
	}
}
