using Engine;
using NUnit.Framework;
using Ships;
using System.Collections.Generic;
using UnityEngine;

namespace ShipDesignerUnitTests
{
	[TestFixture]
	public class MeshCombiner_Test
	{
		CustomMesh CustomMesh = new CustomMesh();
		MeshCombiner MeshCombiner = new MeshCombiner();

		[OneTimeSetUp]
		public void Init()
		{
		}

		[Test]
		public void MeshCombiner_AddMeshPartUpdatesAffectedAttributes()
		{
			MeshCombiner.Add(CustomMesh.MeshPart);

			Assert.AreEqual(CustomMesh.MeshPart.Vertices.Count, MeshCombiner.CombinedVertices.Count);
			Assert.AreEqual(CustomMesh.MeshPart.Triangles.Count, MeshCombiner.Triangles.Count);

			MeshCombiner.Add(CustomMesh.MeshPart);
			Assert.AreEqual(CustomMesh.MeshPart.Vertices.Count * 2, MeshCombiner.CombinedVertices.Count);
			Assert.AreEqual(CustomMesh.MeshPart.Triangles.Count * 2, MeshCombiner.Triangles.Count);
		}
	}
}