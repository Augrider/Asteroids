using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEntityBuilder
{
    private SpaceEntity spaceEntity;


    public SpaceEntityBuilder(SpaceEntity spaceEntity)
    {
        this.spaceEntity = spaceEntity;
    }


    public void SetPositionAndDirection(Vector3 position, Vector2 direction)
    {
        spaceEntity.position.SetPosition(position);
        spaceEntity.direction.SetDirection(direction);
    }


    public void SetEntityType(SpaceEntityType entityType) => spaceEntity.entityType = entityType;
    public void SetScoreValue(int value) => spaceEntity.scoreValue = value;

    public void SetMovement(IMovement movement) => spaceEntity.movement = movement;
    public void SetStateComponent(IStateProvider state) => spaceEntity.state = state;

    public void ProvideInteractions(IInteractionsProvider interactions) => spaceEntity.interactions = interactions;
    public void ProvideBehavior(params IEntityBehavior[] behaviors) => spaceEntity.behaviors = behaviors;
    public void ProvideOnDeathBehavior(params IOnDeathBehavior[] onDeath) => spaceEntity.onDeath = onDeath;
}
