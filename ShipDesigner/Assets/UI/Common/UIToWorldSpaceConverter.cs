using UnityEngine;

namespace UI.Common
{
	public static class UIToWorldSpaceConverter
	{
		//Converts Canvas UI object to WorldPosition
		public static Vector3 GetWorldPosition(Vector3 distance)
		{
			Camera camera = Camera.main;

			Vector2 frustumSize = GetFrustumSize(camera);
			Vector3 frustumOrigin = GetFrustumOriginInWorldSpace(distance, frustumSize.x, frustumSize.y);
			Vector3 distanceOfMousePositionToFrustumOrigin = GetDistanceOfMousePositionToFrustumOrigin(frustumSize.x, frustumSize.y);
			Vector3 GridLocation = frustumOrigin + distanceOfMousePositionToFrustumOrigin;
			//Debug.Log(string.Format(" GridLocation : [{2}], \n frustumOrigin : [{0}], \n distanceOfMousePosition : [{1}]", frustumOrigin, distanceOfMousePositionToFrustumOrigin, GridLocation));
			return GridLocation;
		}

		//blindly ripped from https://docs.unity3d.com/Manual/FrustumSizeAtDistance.html
		private static Vector2 GetFrustumSize(Camera camera)
		{
			float frustumHeight = 2.0f * (camera.transform.position.z * -1) * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
			float frustumWidth = frustumHeight * camera.aspect;
			return new Vector2(frustumWidth, frustumHeight);
		}

		//Distance from GridOrigin to LowerLeft point of frustum. 
		private static Vector3 GetFrustumOriginInWorldSpace(Vector3 distance, float frustumWidth, float frustumHeight)
		{
			float frustumOriginX = distance.x - (frustumWidth / 2);
			float frustumOriginY = distance.y - (frustumHeight / 2);
			return new Vector3(frustumOriginX, frustumOriginY);
		}

		//World unit amount of space between the mouse position and the frustum origin. 
		private static Vector3 GetDistanceOfMousePositionToFrustumOrigin(float frustumWidth, float frustumHeight)
		{
			float distanceOfButtonToFrustumX = frustumWidth * (Input.mousePosition.x / Screen.width);
			float distanceOfButtonToFrustumY = frustumHeight * (Input.mousePosition.y / Screen.height);
			return new Vector3(distanceOfButtonToFrustumX, distanceOfButtonToFrustumY);
		}

	}
}
