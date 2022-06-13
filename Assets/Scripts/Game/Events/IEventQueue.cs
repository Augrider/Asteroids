using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventQueue
{
    event System.Action OnEntityRemoved;

    void EnqueueEntitySpawn(EntitySpawnData spawnData);
    EntitySpawnData[] DequeueEntitySpawns();

    void RaiseOnEntityRemoved();
}