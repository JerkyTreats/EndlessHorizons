
namespace View
{
	/// <summary>
	/// Describes a rectangle of Vectors
	/// </summary>
	public class Boundary
	{
		public enum State { WithinBounds, AboveMax, BelowMin };

		private Bound m_boundX;
		private Bound m_boundY;
		private Bound m_boundZ;

		public Bound X { get { return m_boundX; } }
		public Bound Y { get { return m_boundY; } }
		public Bound Z { get { return m_boundZ; } }

		public Boundary(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
		{
			m_boundX = new Bound(minX, maxX);
			m_boundY = new Bound(minY, maxY);
			m_boundZ = new Bound(minZ, maxZ);
		}

		public State WithinBounds (Bound bound, float newPosition)
		{
			if (newPosition < bound.Min)
				return State.BelowMin;
			if (newPosition > bound.Max)
				return State.AboveMax;
			return State.WithinBounds;
		}
	}

	public class Bound
	{
		public float Min { get; set; }
		public float Max { get; set; }

		public Bound(float min, float max)
		{
			Min = min;
			Max = max;
		}
	}
}
