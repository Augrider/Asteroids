using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityOperationInput
{
    PlayerState playerState { get; }
    Bounds bounds { get; }

    ISpaceEntity[] entities { get; }

    EntitySpawnData[] DequeueEntitySpawns();
}