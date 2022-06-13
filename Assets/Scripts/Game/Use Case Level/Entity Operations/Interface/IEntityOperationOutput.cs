using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityOperationOutput
{
    void CreateEntity(IEntitySpawnProvider entitySpawn, Vector3 position, Vector2 direction);
    void RemoveEntity(ISpaceEntity entity);

    void AddScore(int scoreValue);
}
