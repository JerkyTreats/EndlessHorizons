using SimpleJSON;
using Engine;
using Engine.Utility;
using UnityEngine;
using UI.Inventory.Item;
using System.IO;
using System;
using Ships.Blueprints;

namespace Ships.Components
{
	/// <summary>
	/// Model for Tile Ship Component
	/// </summary>
	public class TileData : iComponentSpawner
	{
		public static string TILE_DATA_PATH = Util.CombinePath(Directory.GetCurrentDirectory(), "Assets", "Game", "Ships", "Components", "Tile", "Data", "Raw");

		JSONNode JsonValues;
		string m_name;
		float m_weight;
		float m_durability;
		float m_cost;
		ItemData m_itemData;
		Quad m_spriteData;
		string m_fileName;

		public string Name { get { return m_name; } }
		public float Weight { get { return m_weight; } }
		public float Durability { get { return m_durability; } }
		public float Cost { get { return m_cost; } }
		public Quad MainSpriteData { get { return m_spriteData; } }
		public ItemData ItemData {  get { return m_itemData; } }
		public string FileName {  get { return m_fileName; } }

		public TileData(string tileJsonPath)
		{
			JsonValues = JSONTools.GetJSONNode(tileJsonPath);
			m_cost = JsonValues["Cost"].AsFloat;
			m_durability = JsonValues["Durability"].AsFloat;
			m_weight = JsonValues["Weight"].AsFloat;
			m_name = JsonValues["Name"].Value;
			m_itemData = new ItemData(JsonValues["Inventory"]["Name"].Value, JsonValues["Inventory"]["Sprite"]["Texture"].Value);
			m_spriteData = BuildQuad(JsonValues["Sprite"]);
			m_fileName = Path.GetFileName(tileJsonPath);
		}

		/// <summary>
		/// Interface compliant method to spawn a Tile GameObject 
		/// </summary>
		/// <param name="startPosition"></param>
		public GameObject SpawnObject(Vector3 startPosition)
		{
			GameObject tile = TileFactory.BuildTile(this);
			tile.transform.position = startPosition;
			tile.name = Name;
			return tile;
		}

		/// <summary>
		/// Compare the gridPosition to the currently active blueprint
		/// </summary>
		/// <param name="gridPosition"></param>
		/// <returns></returns>
		public bool IsOccupied(Vector3 gridPosition)
		{
			Blueprint blueprint = GameData.Instance.Blueprint.GetComponent<Blueprint>();
			return blueprint.isOccupied(Blueprints.Component.Tiles, gridPosition);
		}

		// Add the component to the blueprint, and add the GameObject as a child of the blueprint Gameobject
		public void AddToBlueprint(GameObject gameObject)
		{
			GameObject bp = GameData.Instance.Blueprint;
			Blueprint blueprint = bp.GetComponent<Blueprint>();
			BlueprintComponent component = new BlueprintComponent(gameObject.transform.position, FileName);
			blueprint.Add(Blueprints.Component.Tiles, component);
			gameObject.transform.parent = bp.transform;
		}

		Quad BuildQuad(JSONNode node)
		{
			Quad quad = new Quad(node["Texture"]);

			m_spriteData = new Quad(node["Texture"].Value);
			m_spriteData.SetVertices(new Vector3(), new Vector3(node["MaxSize"]["x"].AsFloat, node["MaxSize"]["y"].AsFloat));
			return quad;
		}

		
	}
}
