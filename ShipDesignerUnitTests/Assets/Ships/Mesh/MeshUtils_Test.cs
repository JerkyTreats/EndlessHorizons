using Engine;
using NUnit.Framework;
using Ships;
using System.Collections.Generic;
using UnityEngine;

namespace ShipDesignerUnitTests
{
	[TestFixture]
	public class MeshUtils_Test
	{
		CustomMesh Mesh;
		
		[OneTimeSetUp]
		public void Init()
		{
			Mesh = new CustomMesh();
		}

		[Test]
		public void MeshUtils_GetBoundaryEdgesReturnsUniqueEdgesOnly()
		{
			string msg = "";
			bool passed = true;
			List<Edge> edges = MeshUtils.GetBoundaryEdges(Mesh.MeshPart.Triangles);
			for (int i = 0; i < edges.Count; i++)
			{
				// The CustomMesh object is constructed so indexs 0-15 are the only boundary edge indices
				if (edges[i].Vertices[0] > 15 || edges[i].Vertices[1] > 15)
				{
					msg = string.Format("Edges with verts [{0}][{1}] not a boundary edge", edges[i].Vertices[0], edges[i].Vertices[1]);
					passed = false;
				}
			}
			Assert.True(passed, msg);
		}

		[Test]
		public void MeshUtils_GetSharedEdgesReturnsExpectedResult()
		{
			List<Edge> uniqueEdges = MeshUtils.GetBoundaryEdges(Mesh.MeshPart.Triangles);
			List<SharedEdge> sharedEdges = MeshUtils.GetSharedEdges(uniqueEdges);

			for (int i = 0; i < sharedEdges.Count; i++)
			{
				for (int n = 0; n < sharedEdges[i].Edges.Count; n++)
				{
					int[] verts = sharedEdges[i].Edges[n].Vertices;
					if (verts[0] != sharedEdges[i].SharedIndex && verts[1] != sharedEdges[i].SharedIndex)
						Assert.IsTrue(false, string.Format("Edge [{0}][{1}] did not contain SharedIndex[{2}]", verts[0], verts[1], sharedEdges[i].SharedIndex));
				}
			}
		}
	}
}
