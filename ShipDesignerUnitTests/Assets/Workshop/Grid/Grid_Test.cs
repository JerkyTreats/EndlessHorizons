using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Workshop.Grid;
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
			GridData gi = new GridData();
			Assert.AreEqual(new Vector3(1.0f, 1.0f, 1.0f), gi.TileStartLocation);
		}

		[TestMethod]
		public void GridInformation_TileCountXRetrievedByJsonFile()
		{
			GridData gi = new GridData();
			Assert.AreEqual(10, gi.TileCountX);
		}

		[TestMethod]
		public void GridInformation_TileCountYRetrievedByJsonFile()
		{
			GridData gi = new GridData();
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
