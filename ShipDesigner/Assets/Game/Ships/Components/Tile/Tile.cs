using Engine;
using UnityEngine;

namespace Ships.Components
{
	public class Tile : MonoBehaviour
	{
		Quad m_spriteData;

		public string Name { get; set; }
		public float Weight { get; set; }
		public float Durability { get; set; }
		public float Cost { get; set; }
		public Quad Sprite { get { return m_spriteData; } }

		/// <summary>
		/// Constructor to assign GameObject necessary variable values and call OnStart methods
		/// </summary>
		/// <param name="name">Name of the Tile</param>
		/// <param name="weight">Weight of the Tile</param>
		/// <param name="durability">Durability value of the Tile</param>
		/// <param name="cost">Cost of the Tile</param>
		/// <param name="mainSprite">Quad rendering the Tile</param>
		public void Initialize(string name, float weight, float durability, float cost, Quad mainSprite)
		{
			Name = name;
			Weight = weight;
			Durability = durability;
			Cost = cost;

			m_spriteData = mainSprite;
			Sprite.RenderQuad(gameObject);
		}
	}
}


