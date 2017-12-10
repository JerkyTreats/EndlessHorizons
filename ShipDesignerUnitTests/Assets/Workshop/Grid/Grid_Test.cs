using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Workshop.Grid;
using UnityEngine;
using System.IO;
using Engine;

namespace ShipDesignerUnitTests
{
	[TestClass]
	public class Grid_Test
	{
		private Mock<Grids> test;

		[TestMethod]
		public void GridInformation_TileStartLocationRetrievedByJsonFile()
		{
			Grids gi = new Grids();
			Assert.AreEqual(new Vector3(1.0f, 1.0f, 1.0f), gi.TileStartLocation);
		}

		[TestMethod]
		public void GridInformation_TileCountXRetrievedByJsonFile()
		{
			Grids gi = new Grids();
			Assert.AreEqual(10, gi.TileCountX);
		}

		[TestMethod]
		public void GridInformation_TileCountYRetrievedByJsonFile()
		{
			Grids gi = new Grids();
			Assert.AreEqual(10, gi.TileCountY);
		}

		//[TestMethod]
		//public void GridInformation_TileSpritePulledFromJsonFile()
		//{
		//	GridData gi = new GridData();
		//	string root = Path.Combine(Helpers.GetRootDirectory(), "Assets\\Resources");
		//	string path = Util.Common.CombinePath(root, gi.SpriteData.Texture..Split('/'));
		//	Assert.IsTrue(File.Exists(path + ".png"));
		//}
	}
}
