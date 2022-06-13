using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    Vector2 acceleration { get; set; }
    Vector2 speed { get; set; }

    float rotationSpeed { get; set; }

    PhysicsData physicsData { get; }
}