using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EntitySpawnData
{
    public IEntitySpawnProvider entitySpawn;
    public Vector3 position;
    public Vector2 direction;


    public EntitySpawnData(IEntitySpawnProvider entitySpawn, Vector3 position, Vector2 direction)
    {
        this.entitySpawn = entitySpawn;
        this.position = position;
        this.direction = direction;
    }
}
