using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    [SerializeField] private GameContext gameContext;
    [SerializeField] private SceneContext sceneContext;
    [SerializeField] private GameSessionState gameState;

    [SerializeField] private float waveDelay;

    private IGameRule newWave;
    private IGameRule gameOver;


    void Awake()
    {
        newWave = new NewWaveOnEntityRemoved(waveDelay);
        gameOver = new GameOverOnPlayerRemoved();

        EventQueueLocator.service.OnEntityRemoved += OnEntityRemoved;
    }

    void OnDestroy()
    {
        EventQueueLocator.service.OnEntityRemoved -= OnEntityRemoved;
    }


    public void StartGame()
    {
        newWave.Check(gameState, gameContext, sceneContext);
    }


    private void OnEntityRemoved()
    {
        if (!gameOver.Check(gameState, gameContext, sceneContext))
            newWave.Check(gameState, gameContext, sceneContext);
    }
}