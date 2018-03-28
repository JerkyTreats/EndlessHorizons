using NUnit.Framework;
using System;
using System.Text;
using System.Collections.Generic;
using Ships;
using Engine;

namespace ShipDesignerUnitTests
{

    [TestFixture]
    public class MeshPart_Test
    {
        [Test]
        public void MeshPart_ConstructorCreatesCorrectTriangleList()
        {
            int meshVertCount = 8;
            Quad quad = new Quad(meshVertCount);
            MeshPart meshPart = new MeshPart(quad.Vertices, quad.Normals, quad.UVs, quad.Triangles);

            Assert.AreEqual(meshVertCount, meshPart.Triangles.Count);
        }
    }
}
