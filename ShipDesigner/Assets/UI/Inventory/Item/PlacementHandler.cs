using UnityEngine;
using UnityEngine.EventSystems;
using Engine;
using UI.Common;
using Workshop.Grid;
using Ships.Components;

namespace UI.Inventory.Item
{
	/// <summary>
	/// Controls a GameObject placement on the TileMap
	/// </summary>
	public class PlacementHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		public Canvas Canvas;
		public GridComponent Grid;
		public float ZAxis { get; set; }
		public Quad Quad { get; set; }
		GameObject TilePreview;

		void Start()
		{
			Grid = GameData.Instance.Grid.GetComponent<GridComponent>();
			ZAxis = Grid.ZAxisItemPlacement;
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
			TileData data = gameObject.GetComponent<ItemComponent>().GetTileData();
			GameObject builtItem = TileFactory.BuildTile(data);
			builtItem.transform.position = GetTilePosition();

			Destroy(TilePreview);
			TilePreview = null;

		}

		private Vector3 GetTilePosition()
		{
			Vector3 vector = Camera.main.transform.position - Grid.transform.position;
			vector = UIToWorldSpaceConverter.GetWorldPosition(vector);
			vector = Grid.GetClosestGridTile(vector);
			vector.z = ZAxis;
			return vector;
		}
	}
}

