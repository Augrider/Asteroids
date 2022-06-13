using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityIOAdapter : OperationIOComponent, IEntityOperationInput, IEntityOperationOutput
{
    public PlayerState playerState => gameState.GetPlayerState();
    public Bounds bounds => sceneContext.bounds;

    public ISpaceEntity[] entities => EntityStorageLocator.service.GetSpaceEntities();


    public EntityIOAdapter(GameContext gameContext, SceneContext sceneContext, GameSessionState gameState) : base(gameContext, sceneContext, gameState)
    {
    }


    public EntitySpawnData[] DequeueEntitySpawns() => EventQueueLocator.service.DequeueEntitySpawns();


    public void CreateEntity(IEntitySpawnProvider entitySpawn, Vector3 position, Vector2 direction)
    {
        EntityStorageLocator.service.CreateEntity(entitySpawn, position, direction);
    }

    public void RemoveEntity(ISpaceEntity entity)
    {
        EntityStorageLocator.service.RemoveEntity(entity);

        EventQueueLocator.service.RaiseOnEntityRemoved();
    }


    public void AddScore(int scoreValue)
    {
        gameState.AddScore(scoreValue);
    }
}
