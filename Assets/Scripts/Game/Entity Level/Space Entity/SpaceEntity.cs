using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all game entities
/// </summary>
public class SpaceEntity : MonoBehaviour, ISpaceEntity, IPositionProvider, IDirectionProvider
{
    public SpaceEntityType entityType { get; internal set; }
    public int scoreValue { get; internal set; }

    public Vector2 value => transform.position;
    public Vector2 forward => transform.up;

    public IPositionProvider position => this;
    public IDirectionProvider direction => this;

    public IMovement movement { get; internal set; }
    public IStateProvider state { get; internal set; }
    public IInteractionsProvider interactions { get; internal set; }

    public IOnDeathBehavior[] onDeath { get; internal set; }
    public IEntityBehavior[] behaviors { get; internal set; }


    public void SetPosition(Vector2 value) => transform.position = value;
    public void SetDirection(Vector2 value) => transform.up = value;
}