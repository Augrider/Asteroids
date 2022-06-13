using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntityBehavior : ScriptableObject, IEntityBehavior
{
    public virtual void OnSpawned(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies) { }
    public abstract void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime);
}