using Engine;
using NUnit.Framework;
using Ships;
using System.Collections.Generic;
using UnityEngine;

namespace ShipDesignerUnitTests
{
	public class SharedEdgeFactory_Test
	{
		// TODO SharedEdge Add/Insert test

		[Test]
		public void SharedEdgeFactory_ReturnSharedEdges()
		{
			//var expectedEdges = new int[][]
			//{
			//	new int[] { 0, 1, 2 },
			//	new int[] { 2, 3 },
			//	new int[] { 3, 4 },
			//	new int[] { 4, 5, 6 },
			//	new int[] { 6, 7 },
			//	new int[] { 7, 8 },
			//	new int[] { 8, 9, 10 },
			//	new int[] { 10, 11 },
			//	new int[] { 11, 12 },
			//	new int[] { 12, 13, 14 },
			//	new int[] { 14, 15 },
			//	new int[] { 15, 0 }
			//};

			CustomMesh cm = new CustomMesh();

			List<Edge> boundaryEdges = MeshUtils.GetBoundaryEdges(cm.MeshPart.Triangles);
			var sharedEdges = SharedEdge.SharedEdgeFactory(boundaryEdges, cm.MeshPart.Vertices);

			Assert.AreEqual(12, sharedEdges.Count);
			
		}
	}
}
