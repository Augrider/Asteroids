using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Projectiles/Enemy Magnet")]
public class EnemyMagnet : BaseEntityBehavior
{
    [SerializeField] private float baseAcceleration;
    [SerializeField] private float distanceMultiplier;
    [SerializeField] private float inverseDistanceMultiplier;


    public override void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime)
    {
        var acceleration = Vector2.zero;

        foreach (var enemy in enemies)
            acceleration += GetAcceleration(self, enemy);

        self.movement.acceleration = acceleration;
        self.direction.SetDirection(self.movement.speed);
    }



    private Vector2 GetAcceleration(ISpaceEntity self, ISpaceEntity target)
    {
        var targetRelative = target.position.value - self.position.value;
        var distance = targetRelative.magnitude;

        return (baseAcceleration + distanceMultiplier * distance + inverseDistanceMultiplier / distance) * targetRelative.normalized;
    }
}
