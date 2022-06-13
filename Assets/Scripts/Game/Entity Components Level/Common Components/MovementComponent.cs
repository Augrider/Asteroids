using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : IMovement
{
    public Vector2 acceleration { get; set; }
    public Vector2 speed { get; set; }

    public float rotationSpeed { get; set; }

    public PhysicsData physicsData { get; private set; }


    public MovementComponent(PhysicsData physicsData)
    {
        this.physicsData = physicsData;
    }
}
