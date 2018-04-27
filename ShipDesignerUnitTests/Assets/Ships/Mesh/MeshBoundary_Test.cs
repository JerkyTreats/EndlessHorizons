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
		CustomMesh CustomMesh;

		[SetUp()]
		public void MyTestInitialize()
		{
			CustomMesh = new CustomMesh();
		}

		[Test]
		public void MeshBoundary_ConstructorCreatesCorrectNumberOfBoundaryEdges()
		{
			List<Edge> mb = MeshUtils.GetBoundaryEdges(CustomMesh.MeshPart.Triangles);
			List<Edge> correct = new List<Edge>();
			for (int i = 0; i < 15; i++)
			{
				Vertex one = new Vertex(), two = new Vertex();
				one.Index = i;
				two.Index = i + 1;
				correct.Add(new Edge(one, two));
			}
			Vertex first = new Vertex(), second = new Vertex();
			first.Index = 0;
			second.Index = 15; 
			correct.Add(new Edge(first, second));

			Assert.AreEqual(correct.Count, mb.Count);

			for (int i = 0; i < correct.Count; i++)
			{
				bool foundEdge = false;
				int[] correctEdge = new int[2] { correct[i].Vertices[0].Index, correct[i].Vertices[1].Index };

				for (int n = 0; n < mb.Count; n++)
				{
					int [] builtEdge = new int[2] { mb[n].Vertices[0].Index, mb[n].Vertices[1].Index };
					if (builtEdge[0] == correctEdge[0] && builtEdge[1] == correctEdge[1])
						foundEdge = true;
				}
				Assert.True(foundEdge);
			}
		}
	}
}
