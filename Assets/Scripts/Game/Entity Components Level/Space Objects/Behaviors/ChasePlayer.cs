using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Object AI/Chase Player")]
public class ChasePlayer : BaseEntityBehavior
{
    [SerializeField] private float speedAbsolute;
    [SerializeField] private float speedMultiplier;


    public override void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime)
    {
        var vector = playerData.position - self.position.value;
        self.movement.speed = (speedAbsolute + speedMultiplier * vector.magnitude) * vector.normalized;
    }
}
