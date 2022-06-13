using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgesSpawnHandler : ISpawnPlacementProvider
{
    private Bounds gameArea;


    public EdgesSpawnHandler(Bounds gameArea)
    {
        this.gameArea = gameArea;
    }


    public (Vector3, Vector2) GetPositionAndDirection()
    {
        var spawnPoint = GetRandomPoint(gameArea);
        var direction = GetRandomDirection(gameArea, spawnPoint);

        return (spawnPoint, direction);
    }



    private Vector3 GetRandomPoint(Bounds gameArea)
    {
        var circlePoint = Random.insideUnitCircle.normalized * gameArea.size.magnitude;
        return gameArea.ClosestPoint(circlePoint);
    }

    private Vector3 GetRandomDirection(Bounds gameArea, Vector3 spawnPoint)
    {
        var circlePoint = (Vector3)Random.insideUnitCircle.normalized * gameArea.extents.magnitude * 0.1f;
        return (circlePoint - spawnPoint).normalized;
    }
}