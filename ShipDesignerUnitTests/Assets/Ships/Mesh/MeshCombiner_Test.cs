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

		//[Test]
		//public void MeshCombiner_GetCornersReturnsOnlyCorners()
		//{
		//	Vector3[] forbidden = new Vector3[]
		//	{
		//		new Vector3(2,0),
		//		new Vector3(4,2),
		//		new Vector3(2,4),
		//		new Vector3(0,2)
		//	};

		//	Vector3[] allowed = new Vector3[]
		//	{
		//		new Vector3(1,0),
		//		new Vector3(3,0),
		//		new Vector3(3,1),
		//		new Vector3(4,1),
		//		new Vector3(4,3),
		//		new Vector3(3,3),
		//		new Vector3(3,4),
		//		new Vector3(1,4),
		//		new Vector3(1,3),
		//		new Vector3(0,3),
		//		new Vector3(0,1),
		//		new Vector3(1,1)
		//	};

		//	CustomMesh mesh = new CustomMesh();
		//	MeshCombiner mc = new MeshCombiner();
		//	mc.Add(mesh.MeshPart);

		//	List<Vector3> corners = mc.GetCorners();

		//	Assert.AreEqual(allowed.Length, corners.Count);
		//	for (int a = 0; a < allowed.Length; a++)
		//	{
		//		Assert.True(corners.Contains(allowed[a]));
		//	}

		//	for (int i = 0; i < forbidden.Length; i++)
		//	{
		//		Assert.False(corners.Contains(forbidden[i]));
		//	}
		//}



	}
}
