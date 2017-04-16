using UnityEngine;
using UnityEngine.EventSystems;
using Engine;
using UI.Common;
using Workshop.Grid;
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
			UpdateCurrentPosition();
			TilePreview.transform.position = CurrentPosition;
		}
		
		/// <summary>
		/// The TilePreview follows the mouse pointer
		/// </summary>
		/// <param name="eventData"></param>
		public void OnDrag(PointerEventData eventData)
		{
			UpdateCurrentPosition();
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
			UpdateCurrentPosition();
			instantiated.transform.position = CurrentPosition;
			instantiated.SetActive(true);
			OccupyTile();

			Destroy(TilePreview);
			TilePreview = null;
			//CurrentPosition = Vector3.zero;
		}

		//update CurrentPosition if the tile is unoccupied
		private void UpdateCurrentPosition()
		{
			Tile tile = GetTileByPosition();
			if (tile.Occupied)
				return;
			else
			{
				CurrentPosition.x = tile.MinX;
				CurrentPosition.y = tile.MinY;
				CurrentPosition.z = ZAxis;
			}
		}

		private void OccupyTile()
		{
			Tile tile = GetTileByPosition();
			tile.Occupied = true;
		}

		//Convert the mouse point space from UI space to world space
		//Then get the tile that is in that worldspace
		private Tile GetTileByPosition()
		{
			Vector3 vector = Camera.main.transform.position - Grid.transform.position;
			vector = UIToWorldSpaceConverter.GetWorldPosition(vector);
			return Grid.GetTileByVector3(vector);
		}
	}
}

