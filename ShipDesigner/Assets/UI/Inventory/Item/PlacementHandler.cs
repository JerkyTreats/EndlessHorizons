using UnityEngine;
using UnityEngine.EventSystems;
using Engine;
using System;

namespace UI.Inventory.Item
{
	/// <summary>
	/// Controls a GameObject placement on the TileMap
	/// </summary>
	public class PlacementHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		public Canvas Canvas;
		public GameObject Grid;
		public float ZAxis { get; set; }
		public Quad Quad { get; set; }
		GameObject TilePreview;

		void Start()
		{
			Grid = GameData.Instance.Grid;
			ZAxis = Grid.GetComponent<Workshop.Grid.GridComponent>().ZAxisItemPlacement;
			Canvas = GameData.Instance.Canvas;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			TilePreview = new GameObject("Item_Preview");
			Quad.RenderQuad(TilePreview);
			TilePreview.transform.position = GetWorldPosition();
		}

		public void OnDrag(PointerEventData eventData)
		{
			TilePreview.transform.position = GetWorldPosition();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			//Destroy(TilePreview);
			//TilePreview = null;
		}

		//Converts Canvas UI object to WorldPosition
		Vector3 GetWorldPosition()
		{
			Camera camera = Camera.main;

			Vector2 frustumSize = GetFrustumSize(camera);
			Vector3 frustumOrigin = GetFrustumOriginInWorldSpace(camera, frustumSize.x, frustumSize.y);
			Vector3 distanceOfMousePositionToFrustumOrigin = GetDistanceOfMousePositionToFrustumOrigin(frustumSize.x, frustumSize.y);
			Vector3 GridLocation = frustumOrigin + distanceOfMousePositionToFrustumOrigin;
			GridLocation.z = ZAxis;
			//Debug.Log(string.Format(" GridLocation : [{2}], \n frustumOrigin : [{0}], \n distanceOfMousePosition : [{1}]", frustumOrigin, distanceOfMousePositionToFrustumOrigin, GridLocation));
			return GridLocation;
		}

		//blindly ripped from https://docs.unity3d.com/Manual/FrustumSizeAtDistance.html
		private Vector2 GetFrustumSize(Camera camera)
		{
			float frustumHeight = 2.0f * (camera.transform.position.z * -1) * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
			float frustumWidth = frustumHeight * camera.aspect;
			return new Vector2(frustumWidth, frustumHeight);
		}

		//Distance from GridOrigin to LowerLeft point of frustum. 
		private Vector3 GetFrustumOriginInWorldSpace(Camera camera, float frustumWidth, float frustumHeight)
		{
			Vector3 cameraDistanceToGridOrigin = camera.transform.position - Grid.transform.position;
			float frustumOriginX = cameraDistanceToGridOrigin.x - (frustumWidth / 2);
			float frustumOriginY = cameraDistanceToGridOrigin.y - (frustumHeight / 2);
			return new Vector3(frustumOriginX, frustumOriginY);
		}

		//World unit amount of space between the mouse position and the frustum origin. 
		private Vector3 GetDistanceOfMousePositionToFrustumOrigin(float frustumWidth, float frustumHeight)
		{
			float distanceOfButtonToFrustumX = frustumWidth * (Input.mousePosition.x / Screen.width);
			float distanceOfButtonToFrustumY = frustumHeight * (Input.mousePosition.y / Screen.height);
			return new Vector3(distanceOfButtonToFrustumX, distanceOfButtonToFrustumY);
		}
	}
}

