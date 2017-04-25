using UnityEngine;
using UnityEngine.EventSystems;
using Engine;
using UI.Common;
using Workshop.Grid;
using Ships.Components;
using Ships.Blueprints;

namespace UI.Inventory.Item
{
	/// <summary>
	/// Attaches to a InventoryItem GameObject to handle placement on the TileMap
	/// </summary>
	public class PlacementHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		public Canvas Canvas;
		public Grid Grid;
		public Quad Quad { get; set; }
		public iInventoryObjectSpawner ObjectSpawner { get; internal set; }
		public iBlueprintOccupier BlueprintObject { get; internal set; }

		Vector3 CurrentPosition;
		GameObject ItemPreview;

		void Start()
		{
			Grid = GameData.Instance.Grid.GetComponent<Grid>();
			Canvas = GameData.Instance.Canvas;
		}

		/// <summary>
		/// Create a TilePreview sprite attached to the mouse pointer
		/// </summary>
		/// <param name="eventData"></param>
		public void OnBeginDrag(PointerEventData eventData)
		{
			ItemPreview = new GameObject("Item_Preview");
			Quad.RenderQuad(ItemPreview);
			UpdateCurrentPosition();
			ItemPreview.transform.position = CurrentPosition;
		}
		
		/// <summary>
		/// The TilePreview follows the mouse pointer
		/// </summary>
		/// <param name="eventData"></param>
		public void OnDrag(PointerEventData eventData)
		{
			UpdateCurrentPosition();
			ItemPreview.transform.position = CurrentPosition;
		}

		/// <summary>
		/// The TilePreview is destroyed, a copy of the attached inventory object is placed there instead.
		/// </summary>
		/// <param name="eventData"></param>
		public void OnEndDrag(PointerEventData eventData)
		{
			UpdateCurrentPosition();
			if(!BlueprintObject.IsOccupied(CurrentPosition))
				ObjectSpawner.SpawnObject(CurrentPosition);

			Destroy(ItemPreview);
			ItemPreview = null;
		}

		//update CurrentPosition if the tile is unoccupied
		private void UpdateCurrentPosition()
		{
			GridTile tile = GetTileByPosition();

			CurrentPosition = tile.Origin;
			CurrentPosition.z = Grid.ZAxisItemPlacement;
		}

		//Convert the mouse point space from UI space to world space
		//Then get the tile that is in that worldspace
		private GridTile GetTileByPosition()
		{
			Vector3 vector = Camera.main.transform.position - Grid.transform.position;
			vector = UIToWorldSpaceConverter.GetWorldPosition(vector);
			return Grid.GetTileByVector3(vector);
		}
	}
}

