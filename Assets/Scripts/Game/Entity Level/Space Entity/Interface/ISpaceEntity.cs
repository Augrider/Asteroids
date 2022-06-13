using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpaceEntity
{
    SpaceEntityType entityType { get; }
    int scoreValue { get; }

    IPositionProvider position { get; }
    IDirectionProvider direction { get; }

    IMovement movement { get; }
    IStateProvider state { get; }
    IInteractionsProvider interactions { get; }

    IEntityBehavior[] behaviors { get; }
    IOnDeathBehavior[] onDeath { get; }
}