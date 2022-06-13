using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityBehavior
{
    void OnSpawned(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies);
    void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime);
}