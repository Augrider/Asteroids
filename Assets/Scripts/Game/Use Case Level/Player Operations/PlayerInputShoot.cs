using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputShoot : IPlayerOperation
{
    private float shootCooldown;


    public void Run(IPlayerOperationInput input, IPlayerOperationOutput output, float deltaTime)
    {
        shootCooldown = Mathf.Clamp(shootCooldown - deltaTime, 0, float.MaxValue);

        if (shootCooldown > 0)
            return;

        if (input.inputData.shootSpecial)
            TryShootWeapon(input.player, input.special, output);
        else if (input.inputData.shootPrimary)
            TryShootWeapon(input.player, input.primary, output);
    }



    private void TryShootWeapon(ISpaceEntity player, WeaponState weapon, IPlayerOperationOutput output)
    {
        Debug.Log($"Weapon {weapon}, charges {weapon.chargeState}");

        if (weapon.chargeState < 1)
            return;

        shootCooldown = weapon.fireCooldown;
        output.Fire(weapon, player.position.value, player.direction.forward);
    }
}
