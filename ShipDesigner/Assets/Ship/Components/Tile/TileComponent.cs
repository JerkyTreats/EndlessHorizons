using UnityEngine;
using UnityEngine.EventSystems;

namespace Ships.Components
{
	public class TileComponent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		TileController Controller;
		GameObject DragItem;

		public void SetController (TileController controller)
		{
			Controller = controller;
		}

		public GameObject SpawnItem()
		{
			return Instantiate(gameObject);
		}

		public void Render()
		{
			Controller.Sprite.RenderQuad(gameObject);
		}


		public void OnBeginDrag(PointerEventData eventData)
		{
			DragItem.transform.position = GetWorldPosition(transform.position);
		}

		public void OnDrag(PointerEventData eventData)
		{
			Debug.Log(GetWorldPosition(Input.mousePosition));
			DragItem.transform.position = GetWorldPosition(Input.mousePosition);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			Debug.Log(string.Format("Exit: [{0}]", GetWorldPosition(Input.mousePosition)));
			//Destroy(DragItem);
			//DragItem = null;
		}

		private Vector3 GetWorldPosition(Vector3 position)
		{
			Vector3 worldPosition = Camera.allCameras[0].ScreenToWorldPoint(position);
			return worldPosition;
		}
	}
}


