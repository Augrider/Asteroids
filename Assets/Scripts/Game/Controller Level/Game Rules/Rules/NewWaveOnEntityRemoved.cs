using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewWaveOnEntityRemoved : IGameRule
{
    private float waveDelay;
    private bool newWaveInProgress;


    public NewWaveOnEntityRemoved(float waveDelay)
    {
        this.waveDelay = waveDelay;
    }


    public bool Check(GameSessionState gameState, GameContext gameContext, SceneContext sceneContext)
    {
        if (newWaveInProgress)
            return false;

        if (GetEnemiesAmount(EntityStorageLocator.service.GetSpaceEntities()) > 0)
            return false;

        sceneContext.StartCoroutine(NewWave(gameState, gameContext, sceneContext));
        return true;
    }



    private IEnumerator NewWave(GameSessionState gameState, GameContext gameContext, SceneContext sceneContext)
    {
        newWaveInProgress = true;

        gameState.AdvanceWave();

        yield return new WaitForSeconds(waveDelay);

        foreach (var spawnData in gameContext.gameDifficulty.GetWaveEntities(gameState.currentWave, sceneContext.bounds))
            EventQueueLocator.service.EnqueueEntitySpawn(spawnData);

        newWaveInProgress = false;
    }


    private int GetEnemiesAmount(ISpaceEntity[] entities)
    {
        return entities.Where(t => t.entityType == SpaceEntityType.Enemy).Count();
    }
}
