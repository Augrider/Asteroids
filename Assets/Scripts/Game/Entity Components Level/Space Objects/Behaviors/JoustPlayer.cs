using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Components/Object AI/Joust Player")]
public class JoustPlayer : BaseEntityBehavior
{
    [SerializeField] private float chargeAcceleration;
    [SerializeField] private float stopAccelerationMultiplier;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float chargeRotationSpeed;

    [SerializeField] private float angleMargin = 0.05f;
    [SerializeField] private float chargeAngleMargin = 20f;

    bool charge = false;


    public override void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime)
    {
        var targetDirection = GetTargetDirection(self.position.value, playerData.position);

        if (charge)
            Charge(self, targetDirection, deltaTime);
        else
            RotateTowardsTarget(self, targetDirection, deltaTime);
    }



    private void RotateTowardsTarget(ISpaceEntity self, Vector2 targetDirection, float deltaTime)
    {
        self.direction.SetDirection(GetRotatedDirection(self.direction.forward, targetDirection, rotationSpeed, deltaTime));
        self.movement.acceleration = -stopAccelerationMultiplier * self.movement.speed;

        charge = Vector2.Angle(targetDirection, self.direction.forward) < angleMargin;
    }

    private void Charge(ISpaceEntity self, Vector2 targetDirection, float deltaTime)
    {
        self.direction.SetDirection(GetRotatedDirection(self.direction.forward, targetDirection, chargeRotationSpeed, deltaTime));
        self.movement.acceleration = chargeAcceleration * self.direction.forward;

        charge = Vector2.Angle(targetDirection, self.direction.forward) < chargeAngleMargin;
    }


    private Vector2 GetTargetDirection(Vector2 self, Vector2 target) => (target - self).normalized;

    private Vector2 GetRotatedDirection(Vector2 currentDirection, Vector2 targetDirection, float rotationSpeed, float deltaTime)
    {
        return Vector3.RotateTowards(currentDirection, targetDirection, rotationSpeed * Mathf.Deg2Rad * deltaTime, 2);
    }
}
