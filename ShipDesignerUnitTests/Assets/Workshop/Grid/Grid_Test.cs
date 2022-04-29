﻿using System;
using NUnit.Framework;
using Workshop.Grid;
using UnityEngine;
using System.IO;
using Engine;

namespace ShipDesignerUnitTests
{
	[TestFixture]
	public class Grid_Test
	{
		[OneTimeSetUp]
		public void Init()
		{
			Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);
		}

		[Test]
		public void GridInformation_TileStartLocationRetrievedByJsonFile()
		{
			Grids gi = new Grids();
			Assert.AreEqual(new Vector3(1.0f, 1.0f, 1.0f), gi.TileStartLocation);
		}

		[Test]
		public void GridInformation_TileCountXRetrievedByJsonFile()
		{
			Grids gi = new Grids();
			Assert.AreEqual(10, gi.TileCountX);
		}

		[Test]
		public void GridInformation_TileCountYRetrievedByJsonFile()
		{
			Grids gi = new Grids();
			Assert.AreEqual(10, gi.TileCountY);
		}

		//[Test]
		//public void GridInformation_TileSpritePulledFromJsonFile()
		//{
		//	GridData gi = new GridData();
		//	string root = Path.Combine(Helpers.GetRootDirectory(), "Assets\\Resources");
		//	string path = Util.Common.CombinePath(root, gi.SpriteData.Texture..Split('/'));
		//	Assert.IsTrue(File.Exists(path + ".png"));
		//}
	}
}
