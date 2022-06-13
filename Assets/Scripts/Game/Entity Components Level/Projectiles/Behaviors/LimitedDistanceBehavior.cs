using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Projectiles/Limited Distance")]
public class LimitedDistanceBehavior : BaseEntityBehavior
{
    [SerializeField] private float maxDistance;

    private float currentDistance = 0;


    public override void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime)
    {
        currentDistance += self.movement.speed.magnitude * deltaTime;

        if (currentDistance > maxDistance)
            self.state.destroyed = true;
    }
}