using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEntities : IEntityOperation
{
    private IPhysics physics;


    public MoveEntities(IPhysics physics)
    {
        this.physics = physics;
    }


    public void Run(IEntityOperationInput input, IEntityOperationOutput output, float deltaTime)
    {
        foreach (var entity in input.entities)
            MoveEntity(entity, deltaTime);
    }



    private void MoveEntity(ISpaceEntity entity, float deltaTime)
    {
        entity.movement.speed = physics.GetSpeed(entity.movement.acceleration, entity.movement.physicsData, entity.movement.speed, deltaTime);
        entity.position.SetPosition(physics.GetPosition(entity.movement.speed, entity.position.value, deltaTime));

        entity.direction.SetDirection(physics.GetDirection(entity.direction.forward, entity.movement.rotationSpeed, deltaTime));
    }
}
