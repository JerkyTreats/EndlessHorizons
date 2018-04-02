using System;
using NUnit.Framework;
using Ships;
using System.Collections.Generic;

namespace ShipDesignerUnitTests
{
	[TestFixture]
	public class Triangle_Test
	{
		int[] TriangleArray = new int[]
		{
			0, 1, 2,
			0, 1, 3
		};

		List<Triangle> TriangleList = new List<Triangle>();

		[OneTimeSetUp]
		public void Init()
		{
			TriangleList.Add(new Triangle(0, 1, 2, 0));
			TriangleList.Add(new Triangle(0, 1, 3, 3));
		}

		[Test]
		public void Triangle_GetArrayContentsCorrect()
		{
			int[] transformed = Triangle.GetTriangleArray(TriangleList);
			Assert.AreEqual(TriangleArray.Length, transformed.Length);
			for (int i = 0; i < transformed.Length; i++)
			{
				Assert.AreEqual(TriangleArray[i], transformed[i]);
			}
		}

		[Test]
		public void Triangle_GetListContentsCorrect()
		{
			List<Triangle> transformed = Triangle.GetTriangleList(TriangleArray);

			Assert.AreEqual(TriangleList.Count, transformed.Count);

			for (int i = 0; i < transformed.Count; i++)
			{
				Assert.AreEqual(TriangleList[i].Index, transformed[i].Index);
				Assert.AreEqual(TriangleList[i].Vertices[0], transformed[i].Vertices[0]);
				Assert.AreEqual(TriangleList[i].Vertices[1], transformed[i].Vertices[1]);
				Assert.AreEqual(TriangleList[i].Vertices[2], transformed[i].Vertices[2]);
			}
		}
	}
}
