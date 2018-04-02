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
		Quad Quad;
		MeshPart MeshPart;
		MeshCombiner MeshCombiner;

		[OneTimeSetUp]
		public void Init()
		{
			Quad = new Quad(16);
			MeshPart = new MeshPart(Quad.Vertices, Quad.Normals, Quad.UVs, Quad.Triangles);
			MeshCombiner = new MeshCombiner();
		}

		[Test]
		public void MeshCombiner_AddMeshPartUpdatesAffectedAttributes()
		{
			MeshCombiner.Add(MeshPart);
			Assert.AreEqual(MeshPart.Vertices.Count, MeshCombiner.Vertices.Count);
			Assert.AreEqual(MeshPart.Normals.Count, MeshCombiner.Normals.Count);
			Assert.AreEqual(MeshPart.UVs.Count, MeshCombiner.UV.Count);
			Assert.AreEqual(MeshPart.Triangles.Count, MeshCombiner.Triangles.Count);

			Quad q = new Quad(8);
			MeshPart mp = new MeshPart();
			MeshCombiner.Add(mp);
			Assert.AreEqual(MeshPart.Vertices.Count + mp.Vertices.Count, MeshCombiner.Vertices.Count);
			Assert.AreEqual(MeshPart.Normals.Count + mp.Normals.Count, MeshCombiner.Normals.Count);
			Assert.AreEqual(MeshPart.UVs.Count + mp.UVs.Count, MeshCombiner.UV.Count);
			Assert.AreEqual(MeshPart.Triangles.Count + mp.Triangles.Count, MeshCombiner.Triangles.Count);
		}

		[Test]
		public void MeshCombiner_EnsureBoundaryEdgesSorted()
		{
			MeshCombiner mc = new MeshCombiner();
		}

	}
}
