using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysics
{
    Vector2 GetSpeed(Vector2 acceleration, PhysicsData physicsData, Vector2 current, float deltaTime);
    Vector2 GetPosition(Vector2 speed, Vector2 current, float deltaTime);

    Vector2 GetDirection(Vector2 direction, float rotationSpeed, float deltaTime);
}
