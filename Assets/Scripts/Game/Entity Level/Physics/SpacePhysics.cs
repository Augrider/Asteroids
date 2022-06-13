using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePhysics : IPhysics
{
    public Vector2 GetSpeed(Vector2 acceleration, PhysicsData physicsData, Vector2 current, float deltaTime)
    {
        return current + (acceleration - GetDragValue(physicsData, current)) * deltaTime;
    }

    public Vector2 GetPosition(Vector2 speed, Vector2 current, float deltaTime)
    {
        return current + speed * deltaTime;
    }


    public Vector2 GetDirection(Vector2 direction, float rotationSpeed, float deltaTime)
    {
        return Rotate(direction, rotationSpeed * deltaTime);
    }



    private Vector2 GetDragValue(PhysicsData physicsData, Vector2 speed)
    {
        return (physicsData.dragValue + physicsData.dragSpeedMultiplier * speed.magnitude) * speed.normalized;
    }


    /// <summary>
    /// Rotate vector on specified angle
    /// </summary>
    /// <param name="value">Vector to rotate</param>
    /// <param name="degrees">Angle in degrees</param>
    /// <returns>Rotated vector</returns>
    private Vector2 Rotate(Vector2 value, float degrees)
    {
        var result = value;

        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        result.x = (cos * value.x) - (sin * value.y);
        result.y = (sin * value.x) + (cos * value.y);

        return result;
    }
}