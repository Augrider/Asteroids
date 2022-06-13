using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIOAdapter : OperationIOComponent, IPlayerOperationInput, IPlayerOperationOutput
{
    public InputData inputData => InputLocator.service.GetInputData(gameContext.playerData.maxAcceleration, gameContext.playerData.maxRotationSpeed, gameState.GetPlayerState());

    public ISpaceEntity player => gameState.player;
    public bool isPlayerAlive => gameState.isPlayerAlive;

    public WeaponState primary => gameState.primary;
    public WeaponState special => gameState.special;


    public PlayerIOAdapter(GameContext gameContext, SceneContext sceneContext, GameSessionState gameState) : base(gameContext, sceneContext, gameState)
    {
    }


    public void Fire(WeaponState weapon, Vector3 position, Vector2 direction)
    {
        var projectiles = weapon.GetProjectileSpawns(position, direction);

        weapon.SetCurrentCharges(weapon.chargeState - 1);

        foreach (var projectile in projectiles)
            EntityStorageLocator.service.CreateEntity(projectile.entitySpawn, projectile.position, projectile.direction);
    }

    public void SetPlayerMovement(Vector2 acceleration, float rotationSpeed)
    {
        player.movement.acceleration = acceleration;
        player.movement.rotationSpeed = rotationSpeed;
    }
}
