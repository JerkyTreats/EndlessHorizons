using System;
using Unity.Entities;
using UnityEngine;

[Serializable]
public struct CameraComponent : IComponentData
{
    public float MoveSpeed;
}

// ComponentDataProxy is for creating a MonoBehaviour representation of this component (for editor support).
[UnityEngine.DisallowMultipleComponent]
public class CameraComponentProxy : ComponentDataProxy<CameraComponent> { }