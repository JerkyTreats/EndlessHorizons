using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Ships;
using Engine;

namespace ShipDesignerUnitTests
{
	[TestFixture]
	public class MeshBoundaryTest
	{
		Quad Quad;
		List<Triangle> Triangles;

		[SetUp()]
		public void MyTestInitialize()
		{
			Quad = new Quad(16);
			Triangles = Triangle.GetTriangleList(Quad.Triangles);
		}

		[Test]
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
