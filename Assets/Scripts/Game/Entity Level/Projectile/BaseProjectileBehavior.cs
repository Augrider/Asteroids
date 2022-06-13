using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectileBehavior : ScriptableObject, IInteractionsProvider, IEntityBehavior
{
    [SerializeField] protected bool pierce = false;


    public virtual void OnSpawned(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies) { }
    public virtual void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime) { }


    public virtual void OnCollision(ISpaceEntity self, ISpaceEntity other)
    {
        if (!pierce)
            self.state.destroyed = true;

        other.interactions.OnCollision(other, self);
    }
}