using System;
using System.Collections.Generic;

namespace Planet
{
	/// <summary>
	/// Planet supports resources sharing a value up to 100. 
	/// Generate random values for each resource, all values summing to less than 100 
	/// </summary>
	class PlanetResourceFactory
	{
		private int ResourceMax = 100;

		public int Mining { get; set; }
		public int Manufacturing { get; set; }
		public int Intellectual { get; set; }

		public PlanetResourceFactory(Random rnd)
		{
			GenerateResourceLevels(rnd);
		}

		/// <summary>
		/// Determine resource levels randomly, assign a level between 0-max
		/// starting at 100,  reducing the max each assignment.
		/// Max is highest for first level, always lower for subsequent levels. 
		/// Randomize the fields to assign before assignment.
		/// </summary>
		private void GenerateResourceLevels(Random rnd)
		{
			List<string> resourceOrder = new List<string> {
				"mining",
				"manufacturing",
				"intellectual"
			};

			while (resourceOrder.Count > 0)
			{
				int i = rnd.Next(0, (resourceOrder.Count-1));
				int resourceValue = GenerateResourceLevel(rnd);

				switch (resourceOrder[i])
				{
					case "mining":
						Mining = resourceValue;
						break;
					case "manufacturing":
						Manufacturing = resourceValue;
						break;
					case "intellecutal":
						Intellectual = resourceValue;
						break;
				}

				resourceOrder.RemoveAt(i);
			}
		}


		/// <summary>
		///		Pull random value from ResourceMax, subtract that value from ResourceMax and return the value;
		/// </summary>
		private int GenerateResourceLevel(Random rnd)
		{
			int next = rnd.Next(0, ResourceMax);
			ResourceMax -= next;
			return next;
		}
	}
}
