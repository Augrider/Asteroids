using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDisabledEntities : IEntityOperation
{
    public void Run(IEntityOperationInput input, IEntityOperationOutput output, float deltaTime)
    {
        foreach (var entity in input.entities)
            if (entity.state.destroyed)
                output.RemoveEntity(entity);
    }
}