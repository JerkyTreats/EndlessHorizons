using Engine;
using NUnit.Framework;
using Ships;
using System.Collections.Generic;
using System.Linq;

namespace ShipDesignerUnitTests
{
	public class SharedEdgeFactory_Test
	{
		// TODO SharedEdge Add/Insert test

		[Test]
		public void SharedEdge_FactoryReturnSharedEdges()
		{
			var expectedVerticeIndices = new int[][]
			{
				new int[] { 0, 1, 2 },
				new int[] { 2, 3 },
				new int[] { 3, 4 },
				new int[] { 4, 5, 6 },
				new int[] { 6, 7 },
				new int[] { 7, 8 },
				new int[] { 8, 9, 10 },
				new int[] { 10, 11 },
				new int[] { 11, 12 },
				new int[] { 12, 13, 14 },
				new int[] { 14, 15 },
				new int[] { 15, 0 }
			};

			CustomMesh cm = new CustomMesh();

			List<Edge> boundaryEdges = MeshUtils.GetBoundaryEdges(cm.MeshPart.Triangles);
			var sharedEdges = SharedEdge.SharedEdgeFactory(boundaryEdges);

			Assert.AreEqual(12, sharedEdges.Count);
			
			for (int i = 0; i < sharedEdges.Count; i++)
			{
				List<int> actual = new List<int>();

				for (int v = 0; v < sharedEdges[i].Vertices.Count; v++)
				{
					actual.Add(sharedEdges[i].Vertices[v].MeshIndex);
				}

				bool intersect = false;
				for (int n = 0; n < expectedVerticeIndices.Length; n++)
				{
					if (actual.Intersect(expectedVerticeIndices[n]).Any())
						intersect = true;
				}
				Assert.True(intersect);
			}
		}

		[Test]
		public void SharedEdge_MergeUpdatesVerticeIndexCorrectly()
		{
			Vertex zero = new Vertex(), one = new Vertex(), two = new Vertex(), three = new Vertex();
			zero.MeshIndex = 0;
			one.MeshIndex = 1;
			two.MeshIndex = 2;
			three.MeshIndex = 3;

			SharedEdge se = new SharedEdge(new Edge(one, two));
			SharedEdge mergeAtBeginning = new SharedEdge(new Edge(zero, one));
			SharedEdge mergeAtEnd = new SharedEdge(new Edge(two, three));

			Assert.AreEqual(1, se.First.MeshIndex);
			Assert.AreEqual(2, se.Last.MeshIndex);
			Assert.True(se.Vertices.Contains(one));
			Assert.True(se.Vertices.Contains(two));
			Assert.AreEqual(2, se.Vertices.Count);

			se.Merge(mergeAtBeginning);

			Assert.AreEqual(0, se.First.MeshIndex);
			Assert.AreEqual(2, se.Last.MeshIndex);
			Assert.AreEqual(3, se.Vertices.Count);
			int[] required = new int[] { 0, 1, 2 };
			for (int i = 0; i < se.Vertices.Count; i++)
			{
				Assert.True(required.Contains(se.Vertices[i].MeshIndex));
			}

			se.Merge(mergeAtEnd);

			Assert.AreEqual(0, se.First.MeshIndex);
			Assert.AreEqual(3, se.Last.MeshIndex);
			Assert.AreEqual(4, se.Vertices.Count);
			required = new int[] { 0, 1, 2, 3 };
			for (int i = 0; i < se.Vertices.Count; i++)
			{
				Assert.True(required.Contains(se.Vertices[i].MeshIndex));
			}
		}
	}
}
