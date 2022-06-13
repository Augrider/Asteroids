using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerOperationOutput
{
    void Fire(WeaponState weapon, Vector3 position, Vector2 direction);
    void SetPlayerMovement(Vector2 acceleration, float rotationSpeed);
}
