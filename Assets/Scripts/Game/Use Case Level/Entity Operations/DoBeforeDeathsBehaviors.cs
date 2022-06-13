using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoBeforeDeathsBehaviors : IEntityOperation
{
    public void Run(IEntityOperationInput input, IEntityOperationOutput output, float deltaTime)
    {
        foreach (var entity in input.entities)
            if (entity.state.destroyed)
            {
                output.AddScore(entity.scoreValue);
                InvokeOnDeath(entity);
            }
    }



    private static void InvokeOnDeath(ISpaceEntity entity)
    {
        foreach (var behavior in entity.onDeath)
            behavior.Invoke(entity);
    }
}
