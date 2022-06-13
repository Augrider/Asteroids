using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateWeaponStates : IPlayerOperation
{
    public void Run(IPlayerOperationInput input, IPlayerOperationOutput output, float deltaTime)
    {
        input.primary.SetCurrentCharges(input.primary.chargeState + deltaTime / input.primary.chargeCooldown);
        input.special.SetCurrentCharges(input.special.chargeState + deltaTime / input.special.chargeCooldown);
    }
}
