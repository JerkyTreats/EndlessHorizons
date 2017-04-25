using Engine;
using UnityEngine;

namespace Ships.Components
{
	/// <summary>
	/// GameObject component representing a Tile Ship Component
	/// </summary>
	public class Tile : MonoBehaviour
	{
		TileData m_model;

		/// <summary>
		/// Constructor to assign GameObject necessary variable values and call OnStart methods
		/// </summary>
		/// <param name="model">TileData Model containing Tile variable values</param>
		public void Initialize(TileData model)
		{
			m_model = model; 
			m_model.MainSpriteData.RenderQuad(gameObject);
		}
	}
}


