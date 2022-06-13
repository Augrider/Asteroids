using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityStorage
{
    ISpaceEntity CreateEntity(IEntitySpawnProvider entitySpawn, Vector3 position, Vector2 direction);
    void RemoveEntity(ISpaceEntity entity);

    ISpaceEntity[] GetSpaceEntities();
}