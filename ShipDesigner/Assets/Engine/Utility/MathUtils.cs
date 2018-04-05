using UnityEngine;

namespace Engine.Utility
{
  public static class MathUtils
  {
    public static float DistanceLineSegmentPoint(Vector3 a, Vector3 b, Vector3 p)
    {
      // If a == b line segment is a point and will cause a divide by zero in the line segment test.
      // Instead return distance from a
      if (a == b)
          return Vector3.Distance(a, p);
      
      // Line segment to point distance equation
      Vector3 ba = b - a;
      Vector3 pa = a - p;
      return (pa - ba * (Vector3.Dot(pa, ba) / Vector3.Dot(ba, ba))).magnitude;
    }
  }
}