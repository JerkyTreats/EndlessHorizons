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
				if (edges[i].Vertices[0].MeshIndex > 15 || edges[i].Vertices[1].MeshIndex > 15)
				{
					msg = string.Format("Edges with verts [{0}][{1}] not a boundary edge", edges[i].Vertices[0], edges[i].Vertices[1]);
					passed = false;
				}
			}
			Assert.True(passed, msg);
		}
	}
}
