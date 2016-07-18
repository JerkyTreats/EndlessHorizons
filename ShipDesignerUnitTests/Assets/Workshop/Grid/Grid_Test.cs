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
			Assert.IsTrue(File.Exists(gi.Sprite));
		}

		[TestMethod]
		public void GridFactory_ReturnsNonNullObject()
		{
			Grid g = GridFactory.BuildGrid();
			Assert.IsNotNull(g);
		}

		[TestMethod]
		public void GridFactory_ReturnedObjectHasCorrectStartLocation()
		{
			Grid g = GridFactory.BuildGrid();
			Assert.AreEqual(new Vector3(1.0f,1.0f,1.0f),g.StartLocation);
		}

		[TestMethod]
		public void GridFactory_ReturnedObjectHasCorrectGridCountX()
		{
			Grid g = GridFactory.BuildGrid();
			Assert.AreEqual(10, g.GridCountX);
		}

		[TestMethod]
		public void GridFactory_ReturnedObjectHasCorrectGridCountY()
		{
			Grid g = GridFactory.BuildGrid();
			Assert.AreEqual(10, g.GridCountY);
		}

		[TestMethod]
		public void Grid_ConstructorBuildsTileList()
		{
			Grid g = GridFactory.BuildGrid();
			Assert.IsTrue(g.Tiles.Count > 0);
		}

		[TestMethod]
		public void Grid_SpritePathExists()
		{
			Grid g = GridFactory.BuildGrid();
			Assert.IsTrue(File.Exists(g.Tiles[0].Sprite));
		}

		[TestMethod]
		public void GridTile_VisibilityPropertyDefaultsToTrue()
		{
			Grid g = GridFactory.BuildGrid();
			bool allValuesTrue = true;
			foreach(GridTile tile in g.Tiles)
			{
				if (!tile.Visible)
					allValuesTrue = false;
			}
			Assert.IsTrue(allValuesTrue);
		}

		[TestMethod]
		public void GridTile_VisibilityCanBeSetToFalse()
		{
			Grid g = GridFactory.BuildGrid();
			g.Tiles[0].Visible = false;
			int falseCount = 0;
			foreach (GridTile grid in g.Tiles)
			{
				if (grid.Visible == false)
					falseCount++;
			}
			Assert.IsTrue(falseCount == 1);
		}
	}
}
