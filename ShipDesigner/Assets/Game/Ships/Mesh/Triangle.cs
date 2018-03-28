﻿using System.Collections.Generic;

namespace Ships
{
	public class Triangle
	{
		public int[] Vertices;
		public Edge[] Edges;
		public int Index;

		public Triangle(int vertex1, int vertex2, int vertex3, int index)
		{
			Index = index;
			Edges = new Edge[3]
			{
				new Edge( vertex1, vertex2 ),
				new Edge( vertex2, vertex3 ),
				new Edge( vertex1, vertex3 )
			};
			Vertices = new int[3]
			{
				vertex1,
				vertex2,
				vertex3
			};
		}
	

		public static List<Triangle> GetTriangleList(int[] triangles)
		{
			List<Triangle> tris = new List<Triangle>();
			for (int i = 0; i < triangles.Length; i += 3)
			{
				tris.Add(new Triangle(triangles[i], triangles[i + 1], triangles[i + 2], i));
			}
			return tris;
		}
	}
}