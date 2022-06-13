using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : IPlayerOperation
{
    public void Run(IPlayerOperationInput input, IPlayerOperationOutput output, float deltaTime)
    {
        output.SetPlayerMovement(input.inputData.acceleration, input.inputData.rotationSpeed);
    }
}