using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEntities : IEntityOperation
{
    public void Run(IEntityOperationInput input, IEntityOperationOutput output, float deltaTime)
    {
        foreach (var spawnData in input.DequeueEntitySpawns())
            output.CreateEntity(spawnData.entitySpawn, spawnData.position, spawnData.direction);
    }
}