using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueue : IEventQueue
{
    private Stack<EntitySpawnData> entitySpawns = new Stack<EntitySpawnData>();

    public event Action OnEntityRemoved;


    public void EnqueueEntitySpawn(EntitySpawnData spawnData)
    {
        entitySpawns.Push(spawnData);
    }

    public EntitySpawnData[] DequeueEntitySpawns()
    {
        var result = entitySpawns.ToArray();
        entitySpawns.Clear();

        return result;
    }

    public void RaiseOnEntityRemoved() => OnEntityRemoved?.Invoke();
}
