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
			GridFactory gi = new GridFactory();
			Assert.AreEqual(5.0f, gi.TileLength);
		}

		[TestMethod]
		public void GridInformation_GridTileWidthRetrievedFromJsonFile()
		{
			GridFactory gi = new GridFactory();
			Assert.AreEqual(5.0f, gi.TileWidth);
		}

		[TestMethod]
		public void GridInformation_GridTileLengthCannotBeSetToZero()
		{
			GridFactory gi = new GridFactory();
			gi.TileLength = 0;
			Assert.AreNotEqual(0, gi.TileLength);
		}

		[TestMethod]
		public void GridInformation_GridTileWidthCannotBeSetToZero()
		{
			GridFactory gi = new GridFactory();
			gi.TileWidth = 0;
			Assert.AreNotEqual(0, gi.TileWidth);
		}

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

		[TestMethod]
		public void GridInformation_TileSpritePulledFromJsonFile()
		{
			GridFactory gi = new GridFactory();
			string root = Path.Combine(Helpers.GetRootDirectory(), "Assets\\Resources");
			string path = Util.Common.CombinePath(root, gi.Sprite.Split('/'));
			Assert.IsTrue(File.Exists(path + ".png"));
		}
	}
}
