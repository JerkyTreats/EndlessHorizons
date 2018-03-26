using Ships;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Engine
{
	public class ComponentManager
	{
		public GameObject go { get; set; }
		MeshPart originMesh;
		Room room;

		public ComponentManager(GameObject go)
		{
			this.go = go;
		}

		public void Start()
		{
			Vector3 position = new Vector3(12, 9);
			go.transform.position = position;
			go.transform.Rotate(new Vector3(90, 180));
			Quad quad = new Quad(verts: 16);
			quad.RenderQuad(go);
			room = new Room();

			originMesh = new MeshPart(go.GetComponent<MeshFilter>().mesh);
			originMesh.RoomPart = RoomPart.Floor;
			room.RoomParts.Add(originMesh);
		}

		public void Extend()
		{
			GameObject toExtend = new GameObject("extender");
			Quad quad = new Quad(verts: 16);
			MeshPart meshPart = new MeshPart(quad.GetMesh());
			
			originMesh.Origin.SetOrigin(Length.Short, Height.Bottom, Depth.Shallow);
			toExtend.transform.position = go.transform.position + originMesh.Origin.Origin;
			room.RoomParts.Add(meshPart);

			meshPart.RoomPart = RoomPart.Wall;

			quad.RenderQuad(toExtend);

			//MeshFilter mesh = go.GetComponent<MeshFilter>();
			//var verts = new List<Vector3>(mesh.mesh.vertices);
			//var tris = new List<int>(mesh.mesh.triangles);
			//var normals = new List<Vector3>(mesh.mesh.normals);
			//var uvs = new List<Vector2>(mesh.mesh.uv);

			//verts.Add( new Vector3(0, 0, 0));
			//verts.Add( new Vector3(0, 0, -0.5f));
			//verts.Add(new Vector3(0, 0.5f, -0.5f));

			//tris.Add(verts.Count - 3);
			//tris.Add(verts.Count - 2);
			//tris.Add(verts.Count- 1);

			//normals.Add( new Vector3(0, 0, 1));
			//normals.Add(new Vector3(0, 0, 1));
			//normals.Add(new Vector3(0, 0, 1));

			//uvs.Add(new Vector2(0, 0));
			//uvs.Add(new Vector2(0, 0));
			//uvs.Add(new Vector2(0, 0));

			//mesh.mesh.Clear();

			//mesh.mesh.vertices = verts.ToArray();
			//mesh.mesh.triangles = tris.ToArray();
			//mesh.mesh.normals = normals.ToArray();
			//mesh.mesh.uv = uvs.ToArray();
		}
	}
}
