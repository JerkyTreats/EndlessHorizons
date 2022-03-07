using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class CameraMovementSystem : JobComponentSystem
{

    struct CameraMovement : IJobProcessComponentData<PlayerInput, Boundary, Position, Rotation, CameraComponent>
    {
        public BlittableBool horizontal;
        public BlittableBool vertical;
        public float maxX;
        public float maxY;
        public float minX;
        public float minY;
        public float moveSpeed;
        public float deltaTime;
        public Position position;
        public Rotation rotation;

        public void Execute(ref PlayerInput playerInput, ref Boundary boundary, ref Position position, ref Rotation rotation, ref CameraComponent camComponent)
        {

            playerInput.Horizontal = horizontal;
            playerInput.Vertical = vertical;
            boundary.MaxX = maxX;
            boundary.MaxY = maxY;
            boundary.MinX = minX;
            boundary.MaxY = minY;
            position = this.position;
            rotation = this.rotation;
        }

    }

    // Main thread
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {

        var job = new CameraMovement
        {
            deltaTime = Time.deltaTime,
            horizontal = Input.GetButton("Horizontal"),
            vertical = Input.GetButton("Vertical"),
            maxX = 3.5f,
            maxY = 3.5f,
            minX = 3.5f,
            minY = 3.5f,


        };
        return job.Schedule(this, inputDeps);
    }
}
