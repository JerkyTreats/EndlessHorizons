using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ships;
using Engine;

namespace ShipDesignerUnitTests
{
	[TestClass]
	public class MeshBoundaryTest
	{
		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		Quad Quad;
		List<Triangle> Triangles;

		[TestInitialize()]
		public void MyTestInitialize()
		{
			Quad = new Quad(16);
			Triangles = Triangle.GetTriangleList(Quad.Triangles);
		}

		[TestMethod]
		public void MeshBoundary_ConstructorCreatesCorrectNumberOfBoundaryEdges()
		{
			List<Edge> mb = MeshUtils.GetBoundaryEdges(Triangles);
			List<Edge> correct = new List<Edge>();
			for (int i = 1; i < mb.Count; i++)
			{
				correct.Add(new Edge(i, i + 1));
			}
			correct.Add(new Edge(1, mb.Count));

			Assert.AreEqual(correct.Count, mb.Count);

			int foundEdges = 0;
			foreach(Edge correctEdge in correct)
			{
				foreach(Edge mbEdge in mb)
				{
					if (mbEdge.Vertices[0] == correctEdge.Vertices[0] &&
						mbEdge.Vertices[1] == correctEdge.Vertices[1])
						foundEdges++;
				}

			}
				Assert.AreEqual(correct.Count, foundEdges, string.Format("Expected [{0}] to be found. Amount actually found: [{1}]", correct.Count, foundEdges));
		}
	}
}
