using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullEntityStorage : IEntityStorage
{
    public ISpaceEntity CreateEntity(IEntitySpawnProvider entitySpawn, Vector3 position, Vector2 direction)
    {
        throw new System.NotImplementedException();
    }

    public ISpaceEntity[] GetSpaceEntities()
    {
        throw new System.NotImplementedException();
    }

    public void RemoveEntity(ISpaceEntity entity)
    {
        throw new System.NotImplementedException();
    }
}