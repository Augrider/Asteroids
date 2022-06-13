using System;
using System.Collections;
using System.Collections.Generic;
using Developed.ScriptableObjects.Variables;
using UnityEngine;

public class GameInitialization : MonoBehaviour
{
    [SerializeField] private GameContext gameContext;
    [SerializeField] private SceneContext sceneContext;
    [SerializeField] private GameSessionState gameState;

    [SerializeField] private GameLoop gameLoop;
    [SerializeField] private GameRules gameRules;

    [SerializeField] private FloatVariable loadingState;


    void Awake()
    {
        StartCoroutine(LoadGameSession());
    }



    private IEnumerator LoadGameSession()
    {
        InitializeGameLoop();

        yield return null;
        loadingState.SetValue(0.5f);

        SpawnPlayer();

        yield return null;
        loadingState.SetValue(1);

        gameLoop.enabled = true;
        gameRules.StartGame();
    }


    private void InitializeGameLoop()
    {
        var entitySequence = new IEntityOperation[]
        {
            new DoBeforeDeathsBehaviors(),
            new DestroyDisabledEntities(),
            new CreateEntities(),
            new ControlEntities(),

            new MoveEntities(new SpacePhysics()),
            new LoopEntities()
        };

        var playerSequence = new IPlayerOperation[]
        {
            new PlayerInputMovement(),
            new PlayerInputShoot(),
            new UpdateWeaponStates()
        };

        gameLoop.entityOperations = entitySequence;
        gameLoop.playerOperations = playerSequence;

        var entityAdapter = new EntityIOAdapter(gameContext, sceneContext, gameState);
        var playerAdapter = new PlayerIOAdapter(gameContext, sceneContext, gameState);

        gameLoop.entityOperationInput = entityAdapter;
        gameLoop.entityOperationOutput = entityAdapter;

        gameLoop.playerOperationInput = playerAdapter;
        gameLoop.playerOperationOutput = playerAdapter;
    }


    private void SpawnPlayer()
    {
        var player = EntityStorageLocator.service.CreateEntity(gameContext.playerData.playerSpawnProvider, Vector3.zero, Vector2.up);
        gameState.player = player;

        gameState.primary = new WeaponState(gameContext.playerData.primary);
        gameState.special = new WeaponState(gameContext.playerData.special);
    }
}
