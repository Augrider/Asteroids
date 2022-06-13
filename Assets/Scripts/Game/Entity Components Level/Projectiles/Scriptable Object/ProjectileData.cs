using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Entity Data/Projectile")]
public class ProjectileData : SpaceObjectData
{
    [SerializeField] protected bool pierce;


    protected override IInteractionsProvider GetInteractionsComponent() => new ProjectileInteractions(pierce);
}