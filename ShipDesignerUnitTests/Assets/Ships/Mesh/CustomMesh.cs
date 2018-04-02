using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Ships;

namespace ShipDesignerUnitTests
{
	public class CustomMesh
	{
		public MeshPart MeshPart;
		public Vector3[] Vertices = new Vector3[]
		{
			new Vector3(1,0),
			new Vector3(2,0),
			new Vector3(3,0),
			new Vector3(3,1),
			new Vector3(4,1),
			new Vector3(4,2),
			new Vector3(4,3),
			new Vector3(3,3),
			new Vector3(3,4),
			new Vector3(2,4),
			new Vector3(1,4),
			new Vector3(1,3),
			new Vector3(0,3),
			new Vector3(0,2),
			new Vector3(0,1),
			new Vector3(1,1),
			new Vector3(2,1),
			new Vector3(1,2),
			new Vector3(2,2),
			new Vector3(2,3),
			new Vector3(3,2)

		};

		public int[] Triangles = new int[]
		{
			0, 15, 1,
			1, 15, 16,
			1, 2, 3,
			1, 3, 16,
			14, 13, 15,
			13, 15, 17,
			15, 17, 18,
			15, 16, 18,
			16, 18, 3,
			18, 20, 3,
			3, 20, 5,
			3, 4, 5,
			5, 20, 7,
			5, 6, 7,
			7, 8, 9,
			7, 19, 9,
			11, 19, 9,
			9, 10, 11,
			11, 12, 13,
			13, 17, 11,
			11, 17, 18,
			11, 18, 19,
			7, 20, 18,
			7, 18, 19
		};

		public Vector3[] Normals;
		public Vector2[] UVs;

		public CustomMesh()
		{

			Normals= new Vector3[Vertices.Length];
			UVs = new Vector2[Vertices.Length];

			for (int i = 0; i < Vertices.Length; i++)
			{
				Normals[i] = Vector3.forward;
				UVs[i] = Vector2.zero;
			}

			MeshPart = new MeshPart(Vertices, Normals, UVs, Triangles);
		}
	}
}
