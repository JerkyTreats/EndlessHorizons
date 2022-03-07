using Unity.Entities;
using System;

[Serializable]
public struct Boundary : IComponentData
{
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
}

// ComponentDataProxy is for creating a MonoBehaviour representation of this component (for editor support).
[UnityEngine.DisallowMultipleComponent]
public class BoundaryProxy : ComponentDataProxy<Boundary> { }
