using NUnit.Framework;
using System;
using Ships;
using Engine;
using System.Collections.Generic;

namespace ShipDesignerUnitTests
{
    [TestFixture]
    public class MeshBoundaryTest
    {

        Quad Quad;
        List<int> Triangles;

        [SetUp()]
        public void MyTestInitialize()
        {
            Quad = new Quad(16);
            Triangles = new List<int>(Quad.Triangles);
        }

        [Test()]
        public void MeshBoundary_ConstructorCreatesCorrectNUmberOfBoundaryEdges()
        {
            MeshBoundary mb = new MeshBoundary(Triangles);

            List<Edge> correct = new List<Edge>();
            for (int i = 1; i < mb.BoundaryEdges.Count; i++)
            {
                correct.Add(new Edge(i, i + 1));
            }
            correct.Add(new Edge(1, mb.BoundaryEdges.Count));

            Assert.AreEqual(correct.Count, mb.BoundaryEdges.Count);

            int foundEdges = 0;
            foreach (Edge correctEdge in correct)
            {
                foreach (Edge mbEdge in mb.BoundaryEdges)
                {
                    if (mbEdge.Vertices[0] == correctEdge.Vertices[0] &&
                        mbEdge.Vertices[1] == correctEdge.Vertices[1])
                        foundEdges++;
                }

            }
            Assert.AreEqual(correct.Count, foundEdges, string.Format("Expected [{0}] to be found. Amount actually found: [{1}]", correct.Count, foundEdges));
        }
    }
}
