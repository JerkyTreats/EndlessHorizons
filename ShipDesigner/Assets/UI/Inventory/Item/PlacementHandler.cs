using UnityEngine;
using UnityEngine.EventSystems;
using Engine;
using UI.Common;
using Workshop.Grid;
using Ships.Components;
using Workshop.Grid.Tiles;

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
		public GameObject SpawnObject { get; set; }

		Vector3 CurrentPosition;
		GameObject TilePreview;

		void Start()
		{
			Grid = GameData.Instance.Grid.GetComponent<GridComponent>();
			ZAxis = Grid.ZAxisItemPlacement;
			Canvas = GameData.Instance.Canvas;
		}

		/// <summary>
		/// Create a TilePreview sprite attached to the mouse pointer
		/// </summary>
		/// <param name="eventData"></param>
		public void OnBeginDrag(PointerEventData eventData)
		{
			TilePreview = new GameObject("Item_Preview");
			Quad.RenderQuad(TilePreview);
			GetTilePosition();
			TilePreview.transform.position = CurrentPosition;
		}
		
		/// <summary>
		/// The TilePreview follows the mouse pointer
		/// </summary>
		/// <param name="eventData"></param>
		public void OnDrag(PointerEventData eventData)
		{
			GetTilePosition();
			TilePreview.transform.position = CurrentPosition;
		}

		/// <summary>
		/// The TilePreview is destroyed, a copy of the attached inventory object is placed there instead.
		/// </summary>
		/// <param name="eventData"></param>
		public void OnEndDrag(PointerEventData eventData)
		{
			GameObject instantiated = Instantiate(SpawnObject);
			instantiated.name = SpawnObject.name;
			GetTilePosition();
			instantiated.transform.position = CurrentPosition;
			instantiated.SetActive(true);

			Destroy(TilePreview);
			TilePreview = null;
			CurrentPosition = Vector3.zero;
		}

		//Convert the mouse point space from UI space to world space
		//Then get the tile that is in that worldspace
		//If that tile is occupied, do nothing
		//But if not occupied, update the current position with the origin of the tile.
		private void GetTilePosition()
		{
			Vector3 vector = Camera.main.transform.position - Grid.transform.position;
			vector = UIToWorldSpaceConverter.GetWorldPosition(vector);
			Tile tile = Grid.GetTileByVector3(vector);
			if (tile.Occupied)
			{
				return;
			} else
			{
				CurrentPosition.x = tile.MinX;
				CurrentPosition.y = tile.MinY;
				CurrentPosition.z = ZAxis;
			}
		}
	}
}

