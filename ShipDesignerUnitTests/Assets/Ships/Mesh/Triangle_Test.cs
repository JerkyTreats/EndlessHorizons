using System;
using NUnit.Framework;
using Ships;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
		List<Vertex> Vertices = new List<Vertex>();

		[OneTimeSetUp]
		public void Init()
		{
			Vertex zero = new Vertex(), one = new Vertex(), two = new Vertex(), three = new Vertex();
			zero.Index = 0;
			one.Index = 1;
			two.Index = 2;
			three.Index = 3;

			Vertices.Add(zero);
			Vertices.Add(one);
			Vertices.Add(two);
			Vertices.Add(three);

			TriangleList.Add(new Triangle(zero, one, two, 0));
			TriangleList.Add(new Triangle(zero, one, three, 3));
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
			List<Triangle> transformed = Triangle.GetTriangleList(TriangleArray, Vertices);

			Assert.AreEqual(TriangleList.Count, transformed.Count);

			for (int i = 0; i < transformed.Count; i++)
			{
				Assert.AreEqual(TriangleList[i].Index, transformed[i].Index);
				Assert.AreEqual(TriangleList[i].Vertices[0], transformed[i].Vertices[0]);
				Assert.AreEqual(TriangleList[i].Vertices[1], transformed[i].Vertices[1]);
				Assert.AreEqual(TriangleList[i].Vertices[2], transformed[i].Vertices[2]);
			}
		}

		[Test]
		public void Triangle_SimpleConstructorPopulatesValuesCorrectly()
		{
			Vector3[] positions = new Vector3[3];
			for (int i = 0; i < 3; i++)
			{
				positions[i] = new Vector3(i, i, i);
			}

			Triangle tri = new Triangle(positions, Vector3.up, Vector2.zero);
			Assert.IsNotNull(tri);			
			Assert.IsNotNull(tri.Edges);
			Assert.IsNotNull(tri.Vertices);
			Assert.IsNotNull(tri.Index);

			Assert.AreEqual(0, tri.Index);

			foreach (Edge edge in tri.Edges)
			{
				Assert.True(positions.Contains(edge.Vertices[0].Position));
				Assert.True(positions.Contains(edge.Vertices[1].Position));
			}
		}
	}
}
