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
			var sharedEdges = SharedEdge.SharedEdgeFactory(boundaryEdges, cm.MeshPart.Vertices);

			Assert.AreEqual(12, sharedEdges.Count);
			
			for (int i = 0; i < sharedEdges.Count; i++)
			{
				SharedEdge actual = sharedEdges[i];
				bool intersect = false;
				for (int n = 0; n < expectedVerticeIndices.Length; n++)
				{
					if (actual.VerticeIndex.Intersect(expectedVerticeIndices[n]).Any())
						intersect = true;
				}
				Assert.True(intersect);
			}
		}

		[Test]
		public void SharedEdge_MergeUpdatesVerticeIndexCorrectly()
		{
			SharedEdge se = new SharedEdge(new Edge(1, 2));
			SharedEdge mergeAtBeginning = new SharedEdge(new Edge(0, 1));
			SharedEdge mergeAtEnd = new SharedEdge(new Edge(2, 3));

			Assert.AreEqual(1, se.First);
			Assert.AreEqual(2, se.Last);
			Assert.True(se.VerticeIndex.Contains(1));
			Assert.True(se.VerticeIndex.Contains(2));
			Assert.AreEqual(2, se.VerticeIndex.Count);

			se.Merge(mergeAtBeginning);

			Assert.AreEqual(0, se.First);
			Assert.AreEqual(2, se.Last);
			Assert.AreEqual(3, se.VerticeIndex.Count);
			for (int i = 0; i < 3; i++)
			{
				Assert.True(se.VerticeIndex.Contains(i));
			}

			se.Merge(mergeAtEnd);

			Assert.AreEqual(0, se.First);
			Assert.AreEqual(3, se.Last);
			Assert.AreEqual(4, se.VerticeIndex.Count);
			for (int i = 0; i < 4; i++)
			{
				Assert.True(se.VerticeIndex.Contains(i));
			}
		}
	}
}
