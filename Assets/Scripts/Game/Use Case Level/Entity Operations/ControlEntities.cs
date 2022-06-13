using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControlEntities : IEntityOperation
{
    public void Run(IEntityOperationInput input, IEntityOperationOutput output, float deltaTime)
    {
        var playerState = input.playerState;
        var entities = input.entities;
        var enemies = entities.Where(t => t.entityType == SpaceEntityType.Enemy).ToArray();

        foreach (var entity in entities)
        {
            foreach (IEntityBehavior control in entity.behaviors)
                control.OnUpdate(entity, playerState, enemies, deltaTime);
        }
    }
}