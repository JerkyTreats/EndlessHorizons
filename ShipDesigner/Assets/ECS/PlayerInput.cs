using System.Collections;
using System.Collections.Generic;
using Unity.Entities;

public struct PlayerInput : IComponentData
{
    public BlittableBool Horizontal;
    public BlittableBool Vertical;
}
