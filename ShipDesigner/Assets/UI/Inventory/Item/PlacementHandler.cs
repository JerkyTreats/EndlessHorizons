using UnityEngine;
using UnityEngine.EventSystems;
using Engine;
using UI.Common;

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
			TilePreview.transform.position = GetTilePosition();
		}

		public void OnDrag(PointerEventData eventData)
		{
			TilePreview.transform.position = GetTilePosition();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			//Destroy(TilePreview);
			//TilePreview = null;
		}

		private Vector3 GetTilePosition()
		{
			Vector3 mousePositionInWorldSpace = UIToWorldSpaceConverter.GetWorldPosition(GetDistance());
			mousePositionInWorldSpace.z = ZAxis;
			return mousePositionInWorldSpace;
		}

		private Vector3 GetDistance()
		{
			return Camera.main.transform.position - Grid.transform.position;
		}
	}
}

